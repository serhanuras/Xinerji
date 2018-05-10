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

    }
}