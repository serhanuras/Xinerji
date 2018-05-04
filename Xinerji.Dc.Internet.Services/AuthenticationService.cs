using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Internet.Model;
using Xinerji.Dc.Internet.Services.Filter;
using Xinerji.Dc.Model.Base;
using Xinerji.Dc.Model.Core;
using Xinerji.Dc.Model.Interfaces;
using Xinerji.Dc.Services;

namespace Xinerji.Dc.Internet.Services
{
    public class AuthenticationService
    {
        #region Local Variables
        private const int MAX_ATTEMPT_COUNT = 5;
        ISessionService sessionService;
        #endregion

        #region Contructors
        public AuthenticationService()
        {
            sessionService = new SessionServiceImp();
        }
        #endregion

        #region ValidateLogon
        [BOServiceFilter]
        public ValidateLogonResponse ValidateLogon(ValidateLogonRequest request)
        {
            ValidateLogonResponse response;

            
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
            


            return response;
        }
        #endregion

        
     
       


    }
}
