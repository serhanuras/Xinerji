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
    public class TripController : Controller
    {
        TripService tripService;

        public TripController()
        {
            tripService = new TripService();
        }

        [HttpPost]
        [InternetActionFilter]
        [ValidateInput(true)]
        public ActionResult GetTripList(GetTripListRequest request)
        {
            return Json(this.tripService.GetTripList(request));
        }


        [HttpPost]
        [InternetActionFilter]
        [ValidateInput(true)]
        public ActionResult InsertTrip(InsertTripRequest request)
        {
            return Json(this.tripService.InsertTrip(request));

        }

        [HttpPost]
        [InternetActionFilter]
        [ValidateInput(true)]
        public ActionResult DeleteTrip(DeleteTripRequest request)
        {
            return Json(this.tripService.DeleteTrip(request));
        }


        [HttpPost]
        [InternetActionFilter]
        [ValidateInput(true)]
        public ActionResult EditTrip(EditTripRequest request)
        {
            return Json(this.tripService.EditTrip(request));
        }

        [HttpPost]
        [InternetActionFilter]
        [ValidateInput(true)]
        public ActionResult GetTripByTruckId(GetTripByTruckIdRequest request)
        {
            return Json(this.tripService.GetTripByTruckId(request));
        }

        [HttpPost]
        [InternetActionFilter]
        [ValidateInput(true)]
        public ActionResult SetTruckLocation(SetTruckLocationRequest request)
        {
            return Json(this.tripService.SetTruckLocation(request));
        }
    }
}