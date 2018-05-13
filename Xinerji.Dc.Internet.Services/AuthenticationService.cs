using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Internet.Model;
using Xinerji.Dc.Internet.Services.Filter;
using Xinerji.Dc.Model.Base;
using Xinerji.Dc.Model.Core;
using Xinerji.Dc.Model.Enumurations;
using Xinerji.Dc.Model.Interfaces;
using Xinerji.Dc.Services;

namespace Xinerji.Dc.Internet.Services
{
    public class AuthenticationService
    {
        #region Local Variables
        private const int MAX_ATTEMPT_COUNT = 5;
        ISessionService sessionService;
        IMemberService memberService;
        #endregion

        #region Contructors
        public AuthenticationService()
        {
            sessionService = new SessionServiceImp();
            memberService = new MemberServiceImp();
        }
        #endregion

        #region ValidateLogon
        [BOServiceFilter]
        public ValidateLogonResponse ValidateLogon(ValidateLogonRequest request)
        {
            ValidateLogonResponse response;

            Member member = memberService.GetByLogonCrendetial(request.Email, request.Password);

            if (member != null)
            {
                Session session = 
                    sessionService.CreateSession(member.Id, 
                                    Dc.Model.Enumurations.ChannelCodeEnum.Internet, 
                                    member.FirmId,
                                    request.Language);

                response = new ValidateLogonResponse
                {
                    PhoneNumber = member.Phone,
                    OtpId = "0",
                    SessionNumber = session.Token
                };
            }
            else
            {
                response = new ValidateLogonResponse
                {
                    Header = new ResponseHeader
                    {
                        Error = new Error
                        {
                            ErrorCode = 2
                        }
                    }
                };
            }
            return response;
        }
        #endregion



        #region TerminateSession
        [BOServiceFilter]
        public TerminateSessionResponse TerminateSession(TerminateSessionRequest request)
        {
            TerminateSessionResponse response;

            sessionService.ChangeSessionStatus(request.Token, SessionStatusEnum.WindowClosed, ChannelCodeEnum.Internet);

            response = new TerminateSessionResponse
            {
            };

            return response;
        }
        #endregion


        #region ChangeLanguage
        [BOServiceFilter]
        public ChangeLanguageResponse ChangeLanguage(ChangeLanguageRequest request)
        {
            ChangeLanguageResponse response;

            LanguageEnum language = LanguageEnum.ENG;

            if(request.Session.Language == LanguageEnum.ENG)
            {
                language = LanguageEnum.TR;
            }


            Session session = sessionService.ChangeLanguage(request.Session, language);

            response = new ChangeLanguageResponse
            {
                SessionNumber = session.Token
            };

            return response;
        }
        #endregion



    }
}
