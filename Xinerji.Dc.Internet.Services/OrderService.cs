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
       public class OrderService
    {
        private static int numberOfItemsInPage = int.Parse(Xinerji.Configuration.ConfigurationManager.GetServiceElement("projectSettings")["itemsCountInPage"]);

        #region Local Variables
        private const int MAX_ATTEMPT_COUNT = 5;
        ISessionService sessionService;
        IOrderService orderService;
        IOrderDetailService orderDetailService;
        #endregion

        public OrderService()
        {
            sessionService = new SessionServiceImp();
            orderService = new OrderServiceImp();
            orderDetailService = new OrderDetailServiceImp();
        }

        #region GetOrderList
        [BOServiceFilter]
        public GetOrderListResponse GetOrderList(GetOrderListRequest request)
        {
            GetOrderListResponse response;

            if (request.Search == "")
            {
                var result = orderService.GetAll(request.Session.FirmId, request.SelectedPage, numberOfItemsInPage);

                response = new GetOrderListResponse
                {
                    OrderList = result.Item1,
                    PageSize = result.Item2
                };
            }
            else
            {
                var result = orderService.Search(request.Session.FirmId, request.SelectedPage, numberOfItemsInPage, request.Search);

                response = new GetOrderListResponse
                {
                    OrderList = result.Item1,
                    PageSize = result.Item2
                };
            }


            return response;
        }
        #endregion


        #region GetTripOrderList
        [BOServiceFilter]
        public GetOrderListResponse GetTripOrderList(GetOrderListRequest request)
        {
            GetOrderListResponse response;


            var result = orderService.GetAll(request.TripId, request.Search);

            response = new GetOrderListResponse
            {
                OrderList = result,
                PageSize = 0
            };


            return response;
        }
        #endregion


        #region BindOrderToTrip
        [BOServiceFilter]
        public BindOrderToTripResponse BindOrderToTrip(BindOrderToTripRequest request)
        {
            BindOrderToTripResponse response;


            var result = orderService.BindOrderToTrip(request.OrderId, request.TripId);

            response = new BindOrderToTripResponse
            {
               
            };


            return response;
        }
        #endregion



        #region InsertOrder
        [BOServiceFilter]
        public InsertOrderResponse InsertOrder(InsertOrderRequest request)
        {
            InsertOrderResponse response;

            request.Order.FirmId = request.Session.FirmId;
            request.Order.Status = Dc.Model.Enumurations.RecordStatusEnum.Active;


            orderService.Insert(request.Order);

            response = new InsertOrderResponse
            {
            };


            return response;
        }
        #endregion

        #region DeleteOrder
        [BOServiceFilter]
        public DeleteOrderResponse DeleteOrder(DeleteOrderRequest request)
        {
            DeleteOrderResponse response;
            orderService.ChangeStatus(request.Id, Dc.Model.Enumurations.RecordStatusEnum.Removed);

            response = new DeleteOrderResponse
            {

            };

            return response;
        }
        #endregion

        #region EditOrder
        [BOServiceFilter]
        public EditOrderResponse EditOrder(EditOrderRequest request)
        {
            EditOrderResponse response;
            request.Order.FirmId = request.Session.FirmId;
            request.Order.Status = Dc.Model.Enumurations.RecordStatusEnum.Active;

            orderService.Update(request.Order);

            response = new EditOrderResponse
            {
            };


            return response;
        }
        #endregion


        #region GetOrderDetailList
        [BOServiceFilter]
        public GetOrderDetailListResponse GetOrderDetailList(GetOrderDetailListRequest request)
        {
            GetOrderDetailListResponse response;

            var result = orderDetailService.GetAll(request.OrderId, request.Session.FirmId);

            response = new GetOrderDetailListResponse
            {
                OrderDetailList = result,
                PageSize = 0
            };



            return response;
        }
        #endregion

        #region InsertOrderDetail
        [BOServiceFilter]
        public InsertOrderDetailResponse InsertOrderDetail(InsertOrderDetailRequest request)
        {
            InsertOrderDetailResponse response;

            request.OrderDetail.FirmId = request.Session.FirmId;
            request.OrderDetail.Status = Dc.Model.Enumurations.RecordStatusEnum.Active;


            orderDetailService.Insert(request.OrderDetail);

            response = new InsertOrderDetailResponse
            {
            };


            return response;
        }
        #endregion

        #region DeleteOrderDetail
        [BOServiceFilter]
        public DeleteOrderDetailResponse DeleteOrderDetail(DeleteOrderDetailRequest request)
        {
            DeleteOrderDetailResponse response;
            orderDetailService.ChangeStatus(request.Id, Dc.Model.Enumurations.RecordStatusEnum.Removed);

            response = new DeleteOrderDetailResponse
            {

            };

            return response;
        }
        #endregion

        #region EditOrderDetail
        [BOServiceFilter]
        public EditOrderDetailResponse EditOrderDetail(EditOrderDetailRequest request)
        {
            EditOrderDetailResponse response;
            request.OrderDetail.FirmId = request.Session.FirmId;
            request.OrderDetail.Status = Dc.Model.Enumurations.RecordStatusEnum.Active;

            orderDetailService.Update(request.OrderDetail);

            response = new EditOrderDetailResponse
            {
            };


            return response;
        }
        #endregion


        #region ChangeDeliverStatus
        [BOServiceFilter]
        public ChangeDeliverStatusResponse ChangeDeliverStatus(ChangeDeliverStatusRequest request)
        {
            ChangeDeliverStatusResponse response;
            

            orderService.ChangeDeliveryStatus(request.OrderId, request.DeliveryStatusId);

            response = new ChangeDeliverStatusResponse
            {
            };


            return response;
        }
        #endregion
    }
}
