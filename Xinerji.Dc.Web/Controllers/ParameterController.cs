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
        public ActionResult GetTruckStatusList(GetTruckStatusListRequest request)
        {
            GetTruckStatusListResponse response = this.parameterService.GetTruckStatusList(request);


            return Json(response);
        }


        [HttpPost]
        [InternetActionFilter]
        [ValidateInput(true)]
        public ActionResult DeleteTruckStatus(DeleteTruckStatusRequest request)
        {

            return Json(this.parameterService.DeleteTruckStatus(request));

        }

        [HttpPost]
        [InternetActionFilter]
        [ValidateInput(true)]
        public ActionResult InsertTruckStatus(InsertTruckStatusRequest request)
        {

            return Json(this.parameterService.InsertTruckStatus(request));

        }

        [HttpPost]
        [InternetActionFilter]
        [ValidateInput(true)]
        public ActionResult EditTruckStatus(EditTruckStatusRequest request)
        {

            return Json(this.parameterService.EditTruckStatus(request));

        }


        [HttpPost]
        [InternetActionFilter]
        [ValidateInput(true)]
        public ActionResult GetDeliveryStatusList(GetDeliveryStatusListRequest request)
        {

            return Json(this.parameterService.GetDeliveryStatusList(request));
        }


        [HttpPost]
        [InternetActionFilter]
        [ValidateInput(true)]
        public ActionResult DeleteDeliveryStatus(DeleteDeliveryStatusRequest request)
        {

            return Json(this.parameterService.DeleteDeliveryStatus(request));

        }

        [HttpPost]
        [InternetActionFilter]
        [ValidateInput(true)]
        public ActionResult InsertDeliveryStatus(InsertDeliveryStatusRequest request)
        {

            return Json(this.parameterService.InsertDeliveryStatus(request));

        }

        [HttpPost]
        [InternetActionFilter]
        [ValidateInput(true)]
        public ActionResult EditDeliveryStatus(EditDeliveryStatusRequest request)
        {

            return Json(this.parameterService.EditDeliveryStatus(request));

        }


        [HttpPost]
        [InternetActionFilter]
        [ValidateInput(true)]
        public ActionResult GetMemberTypeList(GetMemberTypeListRequest request)
        {

            return Json(this.parameterService.GetMemberTypeList(request));
        }


        [HttpPost]
        [InternetActionFilter]
        [ValidateInput(true)]
        public ActionResult DeleteMemberType(DeleteMemberTypeRequest request)
        {

            return Json(this.parameterService.DeleteMemberType(request));

        }

        [HttpPost]
        [InternetActionFilter]
        [ValidateInput(true)]
        public ActionResult InsertMemberType(InsertMemberTypeRequest request)
        {

            return Json(this.parameterService.InsertMemberType(request));

        }

        [HttpPost]
        [InternetActionFilter]
        [ValidateInput(true)]
        public ActionResult EditMemberType(EditMemberTypeRequest request)
        {

            return Json(this.parameterService.EditMemberType(request));

        }


        [HttpPost]
        [InternetActionFilter]
        [ValidateInput(true)]
        public ActionResult GetTruckList(GetTruckListRequest request)
        {

            return Json(this.parameterService.GetTruckList(request));
        }


        [HttpPost]
        [InternetActionFilter]
        [ValidateInput(true)]
        public ActionResult DeleteTruck(DeleteTruckRequest request)
        {

            return Json(this.parameterService.DeleteTruck(request));

        }

        [HttpPost]
        [InternetActionFilter]
        [ValidateInput(true)]
        public ActionResult InsertTruck(InsertTruckRequest request)
        {

            return Json(this.parameterService.InsertTruck(request));

        }

        [HttpPost]
        [InternetActionFilter]
        [ValidateInput(true)]
        public ActionResult EditTruck(EditTruckRequest request)
        {

            return Json(this.parameterService.EditTruck(request));

        }
    }
}