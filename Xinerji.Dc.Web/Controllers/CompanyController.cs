using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xinerji.Dc.Internet.Model;
using Xinerji.Dc.Internet.Services;
using Xinerji.Dc.Model.Enumurations;
using Xinerji.Dc.Web.Filters;

namespace Xinerji.Dc.Web.Controllers
{
    public class CompanyController : Controller
    {
        CompanyService companyService;

        public CompanyController()
        {
            companyService = new CompanyService();
        }

        [HttpPost]
        [InternetActionFilter]
        [ValidateInput(true)]
        public ActionResult GetCompanyList(GetCompanyListRequest request)
        {
            GetCompanyListResponse response = this.companyService.GetCompanyList(request);


            return Json(response);
        }


        [HttpPost]
        [InternetActionFilter]
        [ValidateInput(true)]
        public ActionResult InsertCompany(InsertCompanyRequest request)
        {

            return Json(this.companyService.InsertCompany(request));

        }

        [HttpPost]
        [InternetActionFilter]
        [ValidateInput(true)]
        public ActionResult DeleteCompany(DeleteCompanyRequest request)
        {

            return Json(this.companyService.DeleteCompany(request));

        }


        [HttpPost]
        [InternetActionFilter]
        [ValidateInput(true)]
        public ActionResult EditCompany(EditCompanyRequest request)
        {
            return Json(this.companyService.EditCompany(request));
        }


        [HttpPost]
        [InternetActionFilter]
        [ValidateInput(true)]
        public ActionResult GetBranchList(GetBranchListRequest request)
        {
            GetBranchListResponse response = this.companyService.GetBranchList(request);


            return Json(response);
        }


        [HttpPost]
        [InternetActionFilter]
        [ValidateInput(true)]
        public ActionResult DeleteBranch(DeleteBranchRequest request)
        {

            return Json(this.companyService.DeteleBranch(request));

        }

        [HttpPost]
        [InternetActionFilter]
        [ValidateInput(true)]
        public ActionResult InsertBranch(InsertBranchRequest request)
        {

            return Json(this.companyService.InsertBranch(request));

        }

        [HttpPost]
        [InternetActionFilter]
        [ValidateInput(true)]
        public ActionResult EditBranch(EditBranchRequest request)
        {

            return Json(this.companyService.EditBranch(request));

        }




    }
}