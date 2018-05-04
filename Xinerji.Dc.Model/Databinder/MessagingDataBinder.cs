using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Model.Core;
using Xinerji.Dc.Model.Enumurations;
using Xinerji.Utilities;

namespace Xinerji.Dc.Model.Databinder
{
    public static class MessagingDataBinder
    {

        private static MessagingTemplate GetMessagingTemplateFields(DataRowView drv)
        {
            return new MessagingTemplate
            {
                Id = long.Parse(UtilMethods.StripHTML(drv["Id"].ToString())),
                Type = (MessagingTypeEnum)UtilMethods.ToEnum<ChannelCodeEnum>(UtilMethods.StripHTML(drv["Type"].ToString())),
                SubjectTr = UtilMethods.StripHTML(drv["SubjectTr"].ToString()),
                ContentTr = drv["ContentTr"].ToString(),
                SubjectEng = UtilMethods.StripHTML(drv["SubjectEng"].ToString()),
                ContentEng = drv["ContentEng"].ToString(),
                InsertDateTime = UtilMethods.ConvertSqlToDateTime(UtilMethods.StripHTML(drv["InsertDateTime"].ToString())),
                LastModifiedDateTime = UtilMethods.ConvertSqlToDateTime(UtilMethods.StripHTML(drv["LastModifiedDateTime"].ToString()))
            };
        }


        private static Messaging getMessagingFields(DataRowView drv)
        {
            return new Messaging
            {
                Id = long.Parse(UtilMethods.StripHTML(drv["Id"].ToString())),
                Template = (MessagingTemplateEnum)UtilMethods.ToEnum<MessagingTemplateEnum>(UtilMethods.StripHTML(drv["TemplatedId"].ToString())),
                Type = (MessagingTypeEnum)UtilMethods.ToEnum<MessagingTypeEnum>(UtilMethods.StripHTML(drv["Type"].ToString())),
                ReceiverAddress = UtilMethods.StripHTML(drv["ReceiverAddress"].ToString()),
                Subject = UtilMethods.StripHTML(drv["Subject"].ToString()),
                Content = drv["Content"].ToString(),//UtilMethods.StripHTML(drv["Content"].ToString()),
                Status = (MessagingStatusEnum)UtilMethods.ToEnum<MessagingStatusEnum>(UtilMethods.StripHTML(drv["Status"].ToString())),
                IsEncrypted = UtilMethods.StripHTML(drv["IsEncrypted"].ToString()) == "0" ? false : true,
                RetryCount = int.Parse(UtilMethods.StripHTML(drv["RetryCount"].ToString())),
                AttemptCount = int.Parse(UtilMethods.StripHTML(drv["AttemptCount"].ToString())),
                Priority = (MessagingPriorityEnum)UtilMethods.ToEnum<MessagingPriorityEnum>(UtilMethods.StripHTML(drv["Priority"].ToString())),
                InsertDateTime = UtilMethods.ConvertSqlToDateTime(UtilMethods.StripHTML(drv["InsertDateTime"].ToString())),
                LastModifiedDateTime = UtilMethods.ConvertSqlToDateTime(UtilMethods.StripHTML(drv["LastModifiedDateTime"].ToString()))
            };
        }


        public static MessagingTemplate ToMessagingTemplate(DataView dv)
        {
            if (dv.Count > 0)
            {
                return GetMessagingTemplateFields(dv[0]);
            }

            return null;
        }

        public static List<MessagingTemplate> ToMessagingTemplateList(DataView dv)
        {
            List<MessagingTemplate> channelLogList = new List<MessagingTemplate>();
            for (int i = 0; i < dv.Count; i++)
            {
                channelLogList.Add(GetMessagingTemplateFields(dv[i]));
            }

            return channelLogList;
        }



        public static Messaging ToMessaging(DataView dv)
        {
            if (dv.Count > 0)
            {
                return getMessagingFields(dv[0]);
            }

            return null;
        }

        public static List<Messaging> ToMessagingList(DataView dv)
        {
            List<Messaging> channelLogList = new List<Messaging>();
            for (int i = 0; i < dv.Count; i++)
            {
                channelLogList.Add(getMessagingFields(dv[i]));
            }

            return channelLogList;
        }


    }
}
