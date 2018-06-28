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
    public class OrderController : Controller
    {
        OrderService orderService;
   

        public OrderController()
        {
            orderService = new OrderService();
        }

        [HttpPost]
        [InternetActionFilter]
        [ValidateInput(true)]
        public ActionResult GetOrderList(GetOrderListRequest request)
        {
            return Json(this.orderService.GetOrderList(request));
        }


        [HttpPost]
        [InternetActionFilter]
        [ValidateInput(true)]
        public ActionResult InsertOrder(InsertOrderRequest request)
        {
            return Json(this.orderService.InsertOrder(request));

        }

        [HttpPost]
        [InternetActionFilter]
        [ValidateInput(true)]
        public ActionResult DeleteOrder(DeleteOrderRequest request)
        {
            return Json(this.orderService.DeleteOrder(request));
        }


        [HttpPost]
        [InternetActionFilter]
        [ValidateInput(true)]
        public ActionResult EditOrder(EditOrderRequest request)
        {
            return Json(this.orderService.EditOrder(request));
        }

        [HttpPost]
        [InternetActionFilter]
        [ValidateInput(true)]
        public ActionResult GetOrderDetailList(GetOrderDetailListRequest request)
        {
            return Json(this.orderService.GetOrderDetailList(request));
        }

        [HttpPost]
        [InternetActionFilter]
        [ValidateInput(true)]
        public ActionResult GetTripOrderList(GetOrderListRequest request)
        {
            return Json(this.orderService.GetTripOrderList(request));
        }

        [HttpPost]
        [InternetActionFilter]
        [ValidateInput(true)]
        public ActionResult BindOrderToTrip(BindOrderToTripRequest request)
        {
            return Json(this.orderService.BindOrderToTrip(request));
        }


        [HttpPost]
        [InternetActionFilter]
        [ValidateInput(true)]
        public ActionResult InsertOrderDetail(InsertOrderDetailRequest request)
        {
            return Json(this.orderService.InsertOrderDetail(request));
        }


        [HttpPost]
        [InternetActionFilter]
        [ValidateInput(true)]
        public ActionResult DeleteOrderDetail(DeleteOrderDetailRequest request)
        {
            return Json(this.orderService.DeleteOrderDetail(request));
        }


        [HttpPost]
        [InternetActionFilter]
        [ValidateInput(true)]
        public ActionResult EditOrderDetail(EditOrderDetailRequest request)
        {
            return Json(this.orderService.EditOrderDetail(request));
        }


        [HttpPost]
        [InternetActionFilter]
        [ValidateInput(true)]
        public ActionResult ChangeDeliverStatus(ChangeDeliverStatusRequest request)
        {
            return Json(this.orderService.ChangeDeliverStatus(request));
        }

        [HttpPost]
        [InternetActionFilter]
        [ValidateInput(true)]
        public ActionResult InsertOrderDocument(InsertOrderDocumentRequest request)
        {
            return Json(this.orderService.InsertOrderDocument(request));
        }

        [HttpPost]
        [InternetActionFilter]
        [ValidateInput(true)]
        public ActionResult GetOrderDocumentList(GetOrderDocumentListRequest request)
        {
            return Json(this.orderService.GetOrderDocumentList(request));
        }


        [HttpPost]
        [InternetActionFilter]
        [ValidateInput(true)]
        public ActionResult DeleteOrderDocument(DeleteOrderDocumentRequest request)
        {
            return Json(this.orderService.DeleteOrderDocument(request));
        }
    }
}