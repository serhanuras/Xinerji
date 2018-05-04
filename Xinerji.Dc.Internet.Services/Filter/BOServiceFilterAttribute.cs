using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Model.Base;
using Xinerji.Dc.Model.Core;
using Xinerji.Dc.Model.Enumurations;
using Xinerji.Dc.Model.Interfaces;
using Xinerji.Dc.Services;

namespace Xinerji.Dc.Internet.Services.Filter
{
    [Serializable]
    public class BOServiceFilterAttribute : OnMethodBoundaryAspect
    {
        ISessionService _sessionService;
        IErrorCodeService _errorCodeService;
        ILoggingService _loggingService;


        //PURPOSE of Session Check
        public override void OnEntry(MethodExecutionArgs args)
        {
            _sessionService = new SessionServiceImp();

            AbstractRequest request = args.Arguments[0] as AbstractRequest;

            request.MethodName = args.Method.Name;

            if (args.Method.Name != "ValidateLogon" &&
                args.Method.Name != "ValidateUser" &&
                args.Method.Name != "GetCities" &&
                args.Method.Name != "GetCities" &&
                args.Method.Name != "GetCities" &&
                args.Method.Name != "GetCounties" &&
                args.Method.Name != "Apply" &&
                args.Method.Name != "ConfirmApplication" &&
                args.Method.Name != "ResetPassword"
                )
                request.Session = _sessionService.FindSession(request.Token, ChannelCodeEnum.Internet);

            base.OnEntry(args);
        }

        //Using PURPOSE of  RQ-RSP with EXCEPTION Logging Service
        public override void OnException(MethodExecutionArgs args)
        {
            _errorCodeService = new ErrorCodeServiceImp();
            _loggingService = new LoggingServiceImpl();

            var methodInfo = args.Method as MethodInfo;

            var type = methodInfo.ReturnType;

            AbstractResponse response = (AbstractResponse)Activator.CreateInstance(type);

            response.Header = new ResponseHeader()
            {
                Error = _errorCodeService.FindDescriptionByException(args.Exception)
            };

            AbstractRequest request = args.Arguments[0] as AbstractRequest;

            _loggingService.LogChannelRequest(request, response, args.Exception);

            args.ReturnValue = response;

            args.FlowBehavior = FlowBehavior.Continue;
            base.OnException(args);
        }

        //Using PURPOSE of prepare returning Admin Response and RQ-RSP Logging Service
        public override void OnSuccess(MethodExecutionArgs args)
        {
            _errorCodeService = new ErrorCodeServiceImp();
            _loggingService = new LoggingServiceImpl();
            AbstractResponse response = args.ReturnValue as AbstractResponse;
            AbstractRequest request = args.Arguments[0] as AbstractRequest;

            if (response.Header == null)
            {
                response.Header = new ResponseHeader()
                {
                    Error = _errorCodeService.FindDescriptionByErrorCode(new Error()
                    {
                        ChannelCode = ChannelCodeEnum.Internet
                    })
                };
            }
            else
            {
                Error error = response.Header.Error;
                error.ChannelCode = ChannelCodeEnum.Internet;

                if (error.ErrorDescriptionTR == null)
                {
                    response.Header = new ResponseHeader()
                    {
                        Error = _errorCodeService.FindDescriptionByErrorCode(error)
                    };
                }
            }

            _loggingService.LogChannelRequest(request, response);

            base.OnSuccess(args);
        }

    }
}
