using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Net.Mail;
using Xinerji.Dc.Model.Core;
using Xinerji.Dc.Model.Databinder;
using Xinerji.Dc.Model.Enumurations;
using Xinerji.Integration;
using Xinerji.Dc.Model.Interfaces;
using Xinerji.Exceptions;

namespace Xinerji.Dc.Services
{
    public class MessagingServiceImp : IMessagingService
    {
        #region Local Variables
        SPExecutor spExecutor;
        ILoggingService loggingService;
        #endregion

        #region Constructor
        public MessagingServiceImp()
        {

        }
        #endregion

        #region Methods
        #region GetMessagingPriority
        public MessagingPriorityEnum GetMessagingPriority(MessagingTemplateEnum messagingTemplate)
        {
            switch (messagingTemplate)
            {
                case MessagingTemplateEnum.InternetBankingOTP:
                case MessagingTemplateEnum.InternetBankingMoneyTransferConfirmationOTP:
                case MessagingTemplateEnum.NewApplyEmail:
                    return MessagingPriorityEnum.Urgent;

                case MessagingTemplateEnum.NewApplicationAcceptEmail:
                case MessagingTemplateEnum.NewApplicationRejectEmail:
                    return MessagingPriorityEnum.Urgent;


                default:
                    return MessagingPriorityEnum.Messaging;
            }
        }
        #endregion

        #region GetRetryCount
        public int GetRetryCount(MessagingPriorityEnum messagingType)
        {
            switch (messagingType)
            {
                case MessagingPriorityEnum.Urgent:
                    return 5;
                case MessagingPriorityEnum.Messaging:
                    return 3;
                case MessagingPriorityEnum.Campaign:
                    return 2;
                default:
                    return 1;
            }
        }
        #endregion

        #region GetMessagingTemplate
        public MessagingTemplate GetMessagingTemplate(MessagingTemplateEnum messagingTemplate)
        {
            using (spExecutor = new SPExecutor())
            {
                DataView dv = spExecutor.ExecSProcDV("usp_findMessagingTemplate",
                          new object[] { (int)messagingTemplate });

                return MessagingDataBinder.ToMessagingTemplate(dv);
            }
        }
        #endregion 

        #region Insert
        public bool Insert(Messaging messaging)
        {
            using (spExecutor = new SPExecutor())
            {
                var section = Xinerji.Configuration.ConfigurationManager.GetWebSiteSetting();

                MessagingTemplate messagingTemplate = GetMessagingTemplate(messaging.Template);

                if (messaging.Type == MessagingTypeEnum.EMAIL)
                {
                    string turkishMetaTag = "<meta http-equiv=\"Content-Type\" content=\"text/html; charset = UTF-8\"/>";

                    messagingTemplate.ContentTr = turkishMetaTag + messagingTemplate.ContentTr;
                    messagingTemplate.ContentEng = turkishMetaTag + messagingTemplate.ContentEng;
                }

                if (messagingTemplate == null)
                {
                    throw new MessagingTemplateNofFoundException();
                }

                for (int i = 0; i < messaging.Parameters.Length; i++)
                {
                    messagingTemplate.SubjectTr = messagingTemplate.SubjectTr.Replace("{{" + i.ToString() + "}}", messaging.Parameters[i]);
                    messagingTemplate.SubjectEng = messagingTemplate.SubjectEng.Replace("{{" + i.ToString() + "}}", messaging.Parameters[i]);

                    messagingTemplate.ContentTr = messagingTemplate.ContentTr.Replace("{{" + i.ToString() + "}}", messaging.Parameters[i]);
                    messagingTemplate.ContentEng = messagingTemplate.ContentEng.Replace("{{" + i.ToString() + "}}", messaging.Parameters[i]);
                }

                messagingTemplate.ContentTr = messagingTemplate.ContentTr.Replace("{{PUBLIC_SITE_URL}}", section.PublicWebSiteUrl);
                messagingTemplate.ContentEng = messagingTemplate.ContentEng.Replace("{{PUBLIC_SITE_URL}}", section.PublicWebSiteUrl);

                messagingTemplate.ContentTr = messagingTemplate.ContentTr.Replace("{{INTERNET_SITE_URL}}", section.InternetWebSite);
                messagingTemplate.ContentEng = messagingTemplate.ContentEng.Replace("{{INTERNET_SITE_URL}}", section.InternetWebSite);

                if (messaging.Language == LanguageEnum.TR)
                {
                    messaging.Subject = messagingTemplate.SubjectTr;
                    messaging.Content = messagingTemplate.ContentTr;
                }
                else
                {
                    messaging.Subject = messagingTemplate.SubjectEng;
                    messaging.Content = messagingTemplate.ContentEng;
                }

                messaging.Status = MessagingStatusEnum.Waiting;
                messaging.InsertDateTime = DateTime.Now;
                messaging.LastModifiedDateTime = DateTime.Now;
                messaging.IsEncrypted = false;
                messaging.Priority = GetMessagingPriority(messaging.Template);
                messaging.RetryCount = GetRetryCount(messaging.Priority);
                messaging.Type = messagingTemplate.Type;
                messaging.AttemptCount = 0;

                return spExecutor.ExecSProc("usp_insertMessaging",
                    false,
                         new object[] {
                         (int) messaging.Template,
                         (int) messaging.Type,
                         messaging.ReceiverAddress,
                         messaging.Subject,
                         messaging.Content,
                        (int)messaging.Status,
                         messaging.IsEncrypted ==true? 1:0,
                         messaging.RetryCount,
                         messaging.AttemptCount,
                         (int)messaging.Priority,
                         messaging.InsertDateTime,
                         messaging.LastModifiedDateTime
                         });
            }
        }
        #endregion

        #region FindMessagingByStatus
        public List<Messaging> FindMessagingByStatus(MessagingStatusEnum messagingStatus, int itemCount)
        {
            using (spExecutor = new SPExecutor())
            {
                DataView dv = spExecutor.ExecSProcDV("usp_findMessagingByStatus",
                      new object[] {
                          (int)messagingStatus,
                          itemCount
                      });

                return MessagingDataBinder.ToMessagingList(dv);
            }
        }
        #endregion 

        #region FindMessagingByStatus
        public bool SendEmail(Messaging messaging)
        {
            bool result = false;
            try
            {
                var section = Xinerji.Configuration.ConfigurationManager.GetMailServerSetting();

                var fromAddress = new MailAddress(section.Sender, section.SenderName);
                var toAddress = new MailAddress(messaging.ReceiverAddress, messaging.ReceiverAddress);
                string fromPassword = section.Password;


                var smtp = new SmtpClient
                {
                    Host = section.Host,
                    Port = int.Parse(section.Port),
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)

                };

                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = messaging.Subject + " Ref:(" + Guid.NewGuid() + ")",
                    Body = messaging.Content,
                    IsBodyHtml = true
                })
                {
                    smtp.Send(message);
                }

                messaging.AttemptCount++;
                messaging.Status = MessagingStatusEnum.Send;
                result = true;



            }
            catch (Exception ex)
            {
                messaging.AttemptCount++;

                if (messaging.AttemptCount == messaging.RetryCount)
                {
                    messaging.Status = MessagingStatusEnum.Failed;
                }

                result = false;

            }
            finally
            {
                UpdateMessagingAttemptCount(messaging);
            }

            return result;
        }
        #endregion

        #region SendOtp
        public bool SendOtp(Messaging messaging)
        {
            return SendSms(messaging);
        }
        #endregion

        #region FindMessagingByStatus
        public bool SendSms(Messaging messaging)
        {

            return false;
        }
        #endregion

        #region UpdateMessagingAttemptCount
        public bool UpdateMessagingAttemptCount(Messaging messaging)
        {
            using (spExecutor = new SPExecutor())
            {
                return spExecutor.ExecSProc("usp_updateMessagingAttemptCount",
                    new object[] { messaging.Id, (int)messaging.Status, messaging.AttemptCount });
            }
        }

        public void UpdateMessagingStatusAndResend(Messaging messaging)
        {
            using (spExecutor = new SPExecutor())
            {
                spExecutor.ExecSProc("usp_updateMessagingSatusAndResend",
                   new object[] { messaging.Id, (int)messaging.Status });
            }
        }

        #endregion

        #region ConvertTr2Eng
        private string ConvertTr2Eng(string content)
        {
            content = content.Replace('ö', 'o');
            content = content.Replace('ü', 'u');
            content = content.Replace('ğ', 'g');
            content = content.Replace('ş', 's');
            content = content.Replace('ı', 'i');
            content = content.Replace('ç', 'c');
            content = content.Replace('Ö', 'O');
            content = content.Replace('Ü', 'U');
            content = content.Replace('Ğ', 'G');
            content = content.Replace('Ş', 'S');
            content = content.Replace('İ', 'I');
            content = content.Replace('Ç', 'C');

            return content;
        }
        #endregion

        #region SendMessage
        public bool SendMessage(List<Messaging> messagingList)
        {
            foreach (Messaging messaging in messagingList)
            {
                if (messaging.Type == Model.Enumurations.MessagingTypeEnum.EMAIL)
                {
                    SendEmail(messaging);
                }
                else if (messaging.Type == Model.Enumurations.MessagingTypeEnum.OTP)
                {
                    SendOtp(messaging);
                }
                else if (messaging.Type == Model.Enumurations.MessagingTypeEnum.SMS)
                {
                    SendSms(messaging);
                }
            }

            return true;
        }
        #endregion

        #region FindMessagingByStatus
        public List<Messaging> GetMessagingByReceiver(int topCount, string receiverEmail, string receiverCellPhone)
        {
            using (spExecutor = new SPExecutor())
            {
                DataView dv = spExecutor.ExecSProcDV("usp_getMessagingByReceiver",
                      new object[] {
                          topCount,
                          receiverEmail,
                          receiverCellPhone
                      });

                return MessagingDataBinder.ToMessagingList(dv);
            }
        }
        #endregion 

        #region Dispose
        public void Dispose()
        {

        }
        #endregion
        #endregion
    }
}
