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
        IBranchService branchService;
        #endregion

        #region Contructors
        public ParameterService()
        {
            sessionService = new SessionServiceImp();
            memberService = new MemberServiceImp();
            companyService = new CompanyServiceImp();
            branchService = new BranchServiceImp();
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

            if (request.Search == "")
            {
                response = new GetCompanyListResponse
                {
                    CompanyList = companyService.GetAll(request.Session.FirmId)
                };
            }
            else
            {
                response = new GetCompanyListResponse
                {
                    CompanyList = companyService.Search(request.Session.FirmId, request.Search)
                };
            }

            return response;
        }
        #endregion


        #region InsertCompany
        [BOServiceFilter]
        public InsertCompanyResponse InsertCompany(InsertCompanyRequest request)
        {
            request.Company.FirmId = request.Session.FirmId;
            request.Company.Status = Dc.Model.Enumurations.RecordStatusEnum.Active;

            InsertCompanyResponse response;
            companyService.Insert(request.Company);

            response = new InsertCompanyResponse
            {
            };

            return response;
        }
        #endregion

        #region DeleteCompany
        [BOServiceFilter]
        public DeleteCompanyResponse DeleteCompany(DeleteCompanyRequest request)
        {
            DeleteCompanyResponse response;
            companyService.ChangeStatus(request.Id, Dc.Model.Enumurations.RecordStatusEnum.Removed);

            response = new DeleteCompanyResponse
            {

            };

            return response;
        }
        #endregion


        #region EditCompany
        [BOServiceFilter]
        public EditCompanyResponse EditCompany(EditCompanyRequest request)
        {
            request.Company.FirmId = request.Session.FirmId;
            request.Company.Status = Dc.Model.Enumurations.RecordStatusEnum.Active;

            EditCompanyResponse response;
            companyService.Update(request.Company);

            response = new EditCompanyResponse
            {
            };

            return response;
        }
        #endregion


        #region GetBranchList
        [BOServiceFilter]
        public GetBranchListResponse GetBranchList(GetBranchListRequest request)
        {
            GetBranchListResponse response;

            if (request.Search == "")
            {
                response = new GetBranchListResponse
                {
                    BranchList = branchService.GetAll(request.CompanyId)
                };
            }
            else
            {
                response = new GetBranchListResponse
                {
                    BranchList = branchService.Search(request.CompanyId, request.Search)
                };
            }

            return response;
        }
        #endregion


        #region DeteleBranch
        [BOServiceFilter]
        public DeleteBranchResponse DeteleBranch(DeleteBranchRequest request)
        {
            DeleteBranchResponse response;
            branchService.ChangeStatus(request.Id, Dc.Model.Enumurations.RecordStatusEnum.Removed);

            response = new DeleteBranchResponse
            {

            };

            return response;
        }
        #endregion


        #region InsertBranch
        [BOServiceFilter]
        public InsertBranchResponse InsertBranch(InsertBranchRequest request)
        {
            request.Branch.Status = Dc.Model.Enumurations.RecordStatusEnum.Active;

            InsertBranchResponse response;
            branchService.Insert(request.Branch);

            response = new InsertBranchResponse
            {
            };

            return response;
        }
        #endregion

        #region EditBranch
        [BOServiceFilter]
        public EditBranchResponse EditBranch(EditBranchRequest request)
        {
            request.Branch.Status = Dc.Model.Enumurations.RecordStatusEnum.Active;

            EditBranchResponse response;
            branchService.Update(request.Branch);

            response = new EditBranchResponse
            {
            };

            return response;
        }
        #endregion

    }
}
