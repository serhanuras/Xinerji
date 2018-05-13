﻿using System;
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
    public class ParameterController : Controller
    {
        ParameterService parameterService;

        public ParameterController()
        {
            parameterService = new ParameterService();
        }

        [HttpGet]
        [InternetActionFilter]
        [ValidateInput(true)]
        public ActionResult GetFirmList(GetFirmListRequest request)
        {
           
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [InternetActionFilter]
        [ValidateInput(true)]
        public ActionResult GetCompanyList(GetCompanyListRequest request)
        {
            GetCompanyListResponse response = this.parameterService.GetCompanyList(request);


            return Json(response);
        }


        [HttpPost]
        [InternetActionFilter]
        [ValidateInput(true)]
        public ActionResult InsertCompany(InsertCompanyRequest request)
        {

            return Json(this.parameterService.InsertCompany(request));

        }

        [HttpPost]
        [InternetActionFilter]
        [ValidateInput(true)]
        public ActionResult DeleteCompany(DeleteCompanyRequest request)
        {

            return Json(this.parameterService.DeleteCompany(request));

        }


        [HttpPost]
        [InternetActionFilter]
        [ValidateInput(true)]
        public ActionResult EditCompany(EditCompanyRequest request)
        {
            return Json(this.parameterService.EditCompany(request));
        }


        [HttpPost]
        [InternetActionFilter]
        [ValidateInput(true)]
        public ActionResult GetBranchList(GetBranchListRequest request)
        {
            GetBranchListResponse response = this.parameterService.GetBranchList(request);


            return Json(response);
        }


        [HttpPost]
        [InternetActionFilter]
        [ValidateInput(true)]
        public ActionResult DeleteBranch(DeleteBranchRequest request)
        {

            return Json(this.parameterService.DeteleBranch(request));

        }

        [HttpPost]
        [InternetActionFilter]
        [ValidateInput(true)]
        public ActionResult InsertBranch(InsertBranchRequest request)
        {

            return Json(this.parameterService.InsertBranch(request));

        }

        [HttpPost]
        [InternetActionFilter]
        [ValidateInput(true)]
        public ActionResult EditBranch(EditBranchRequest request)
        {

            return Json(this.parameterService.EditBranch(request));

        }
    }
}