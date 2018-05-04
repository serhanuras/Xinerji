using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Model.Base;
using Xinerji.Dc.Model.Core;
using Xinerji.Dc.Model.Enumurations;
using Xinerji.Dc.Model.Interfaces;
using Xinerji.Integration;

namespace Xinerji.Dc.Services
{
    public class LoggingServiceImpl : ILoggingService
    {
        #region Local Variables
        SPExecutor spExecutor;
        ISessionService sessionService;
        #endregion

        #region Constructor
        public LoggingServiceImpl()
        {

        }
        #endregion


        #region LogChannelRequest(string url, string method, string returnCode, string request, string response, ChannelCodeEnum channelCode)
        public int LogChannelRequest(string url, string method, string returnCode, string request, string response, ChannelCodeEnum channelCode)
        {
            ChannelLog channelLog = new ChannelLog
            {
                SessionId = 0,
                MethodName = method,
                Request = request,
                Response = "ReturnCode :" + returnCode + "- Response:" + response,
                ChannelCode = channelCode,
                InsertDateTime = DateTime.Now,
                ReturnCode = 0,
                ExceptionStackTrace = "",
                IsOutgoingCall = true,
                Url = url
            };

            LogChannelRequest(channelLog);

            return 1;
        }
        #endregion

        #region LogChannelRequest(AbstractRequest request, AbstractResponse response)
        public int LogChannelRequest(AbstractRequest request, AbstractResponse response)
        {
            return LogChannelRequest(request, response, null);
        }
        #endregion

        #region LogChannelRequest(AbstractRequest request, AbstractResponse response, Exception ex)
        public int LogChannelRequest(AbstractRequest request, AbstractResponse response, Exception ex)
        {
            using (sessionService = new SessionServiceImp())
            {
                var javaScriptSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();

                string exceptionStackTrace = "";

                if (ex != null)
                {
                    exceptionStackTrace = ex.Message + ":::" + ex.StackTrace;
                }

                Session session = sessionService.ParseToken(request.Token);

                ChannelLog channelLog = new ChannelLog
                {
                    SessionId = request.Token == null ? 0 : session.Id,
                    MethodName = request.MethodName,
                    Request = javaScriptSerializer.Serialize(request),
                    Response = javaScriptSerializer.Serialize(response),
                    ChannelCode = request.ChannelCode,
                    InsertDateTime = DateTime.Now,
                    ReturnCode = response.Header.Error.ErrorCode,
                    ExceptionStackTrace = exceptionStackTrace,
                    IsOutgoingCall = false,
                    Url = request.Url
                };

                if (!LogChannelRequest(channelLog))
                {
                    //TODO:INSERT INTO QUEUE
                }


                return 1;
            }
        }
        #endregion

     
        #region int LogWindowServiceTick(string serviceName, string method, string returnCode, string serviceDescription, string result, Exception ex)
        public int LogWindowServiceTick(string serviceName, string method, string serviceDescription, string resultDescription, Exception ex)
        {
            using (sessionService = new SessionServiceImp())
            {
                var javaScriptSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();

                string exceptionStackTrace = "";

                if (ex != null)
                {
                    exceptionStackTrace = ex.Message + ":::" + ex.StackTrace;
                }

                ChannelLog channelLog = new ChannelLog
                {
                    SessionId = 0,
                    MethodName = method,
                    Request = serviceDescription,
                    Response = resultDescription,
                    ChannelCode = ChannelCodeEnum.Batch,
                    InsertDateTime = DateTime.Now,
                    ReturnCode = 0,
                    ExceptionStackTrace = exceptionStackTrace,
                    IsOutgoingCall = false,
                    Url = ""
                };

                if (!LogChannelRequest(channelLog))
                {
                    //TODO:INSERT INTO QUEUE
                }

                return 1;
            }
        }
        #endregion

        

        #region LogChannelRequest(ChannelLog channelLog)
        private bool LogChannelRequest(ChannelLog channelLog)
        {
            using (spExecutor = new SPExecutor())
            {
                return spExecutor.ExecSProc("usp_logChannelRequest",
                      new object[] {
                      (int)channelLog.ChannelCode,
                      channelLog.SessionId,
                      channelLog.IsOutgoingCall==true? 1:0,
                      channelLog.Url,
                      channelLog.MethodName,
                      channelLog.ReturnCode,
                      channelLog.Request,
                      channelLog.Response,
                      channelLog.ExceptionStackTrace,
                      channelLog.InsertDateTime
                      });
            }
        }
        #endregion

        #region Dispose
        public void Dispose()
        {

        }
        #endregion
    }
}
