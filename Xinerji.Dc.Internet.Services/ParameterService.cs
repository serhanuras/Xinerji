using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Internet.Model;
using Xinerji.Dc.Internet.Services.Filter;
using Xinerji.Dc.Model.Interfaces;
using Xinerji.Dc.Services;

namespace Xinerji.Dc.Internet.Services
{
    public class ParameterService
    {
        #region Local Variables
        private const int MAX_ATTEMPT_COUNT = 5;
        ISessionService sessionService;
        IMemberService memberService;
        ICompanyService companyService;
        #endregion

        #region Contructors
        public ParameterService()
        {
            sessionService = new SessionServiceImp();
            memberService = new MemberServiceImp();
            companyService = new CompanyServiceImp();
        }
        #endregion

        #region GetFirmList
        [BOServiceFilter]
        public GetFirmListResponse GetFirmList(GetFirmListRequest request)
        {
            GetFirmListResponse response;

            response = new GetFirmListResponse
            {
            };

            return response;
        }
        #endregion


        #region GetCompanyList
        [BOServiceFilter]
        public GetCompanyListResponse GetCompanyList(GetCompanyListRequest request)
        {
            GetCompanyListResponse response;

            response = new GetCompanyListResponse
            {
                CompanyList = companyService.GetAll(request.Session.FirmId)
            };

            return response;
        }
        #endregion

    }
}
