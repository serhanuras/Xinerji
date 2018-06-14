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
    public class TripService
    {
        private static int numberOfItemsInPage = int.Parse(Xinerji.Configuration.ConfigurationManager.GetServiceElement("projectSettings")["itemsCountInPage"]);

        #region Local Variables
        private const int MAX_ATTEMPT_COUNT = 5;
        ISessionService sessionService;
        ITripService tripService;
        IMemberService memberService;
        ITruckService truckService;
        IOrderService orderService;
        #endregion


        public TripService()
        {
            sessionService = new SessionServiceImp();
            tripService = new TripServiceImp();
            memberService = new MemberServiceImp();
            truckService = new TruckServiceImp();
            orderService = new OrderServiceImp();
        }

        #region GetTripList
        [BOServiceFilter]
        public GetTripListResponse GetTripList(GetTripListRequest request)
        {
            GetTripListResponse response;

            if (request.Search == "")
            {
                var result = tripService.GetAll(request.Session.FirmId, request.SelectedPage, numberOfItemsInPage);

                response = new GetTripListResponse
                {
                    TripList = result.Item1,
                    PageSize = result.Item2
                };
            }
            else
            {
                var result = tripService.Search(request.Session.FirmId, request.SelectedPage, numberOfItemsInPage, request.Search);

                response = new GetTripListResponse
                {
                    TripList = result.Item1,
                    PageSize = result.Item2
                };
            }

            return response;
        }
        #endregion


        #region GetTripByTruckId
        [BOServiceFilter]
        public GetTripByTruckIdResponse GetTripByTruckId(GetTripByTruckIdRequest request)
        {
            GetTripByTruckIdResponse response;

            var trip = tripService.GetByTruckId(request.TruckId);

            var member = truckService.GetById(request.TruckId);

            if (trip != null)
            {
                var orderList = orderService.GetAll(trip.Id, "");

                if (member.MemberId == request.Session.MemberId)
                {
                    response = new GetTripByTruckIdResponse
                    {
                        Trip = trip,
                        OrderList = orderList
                    };

                    return response;
                }
            }

            response = new GetTripByTruckIdResponse
            {
                Header = new ResponseHeader
                {
                    Error = new Error
                    {
                        ErrorCode = 5
                    }
                }
            };

            return response;
        }
        #endregion

        #region InsertTrip
        [BOServiceFilter]
        public InsertTripResponse InsertTrip(InsertTripRequest request)
        {
            var result = tripService.Search(request.Session.FirmId, 0, 1000,"REF-" + DateTime.Now.ToString("yyyyMMdd") + "-");

            List<Trip> tripList = result.Item1;
            
            request.Trip.Name = "REF-" + DateTime.Now.ToString("yyyyMMdd") + "-" + (tripList.Count + 1).ToString().PadLeft(4, '0');

            request.Trip.FirmId = request.Session.FirmId;
            request.Trip.Status = Dc.Model.Enumurations.RecordStatusEnum.Active;

            InsertTripResponse response;
            tripService.Insert(request.Trip);

            response = new InsertTripResponse
            {
            };

            return response;
        }
        #endregion

        #region DeleteMember
        [BOServiceFilter]
        public DeleteTripResponse DeleteTrip(DeleteTripRequest request)
        {
            DeleteTripResponse response;
            tripService.ChangeStatus(request.Id, Dc.Model.Enumurations.RecordStatusEnum.Removed);

            response = new DeleteTripResponse
            {

            };

            return response;
        }
        #endregion


        #region EditMember
        [BOServiceFilter]
        public EditTripResponse EditTrip(EditTripRequest request)
        {
            request.Trip.FirmId = request.Session.FirmId;
            request.Trip.Status = Dc.Model.Enumurations.RecordStatusEnum.Active;

            EditTripResponse response;
            tripService.Update(request.Trip);

            response = new EditTripResponse
            {
            };

            return response;
        }
        #endregion
    }
}
