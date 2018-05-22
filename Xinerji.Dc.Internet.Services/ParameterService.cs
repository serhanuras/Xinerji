using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Internet.Model;
using Xinerji.Dc.Internet.Services.Filter;
using Xinerji.Dc.Model.Core;
using Xinerji.Dc.Model.Interfaces;
using Xinerji.Dc.Services;

namespace Xinerji.Dc.Internet.Services
{
    public class ParameterService
    {
        private static int numberOfItemsInPage = int.Parse(Xinerji.Configuration.ConfigurationManager.GetServiceElement("projectSettings")["itemsCountInPage"]);

        #region Local Variables
        private const int MAX_ATTEMPT_COUNT = 5;
        ISessionService sessionService;
        IMemberService memberService;
        ICompanyService companyService;
        IBranchService branchService;
        ITruckStatusService truckStatusService;
        IDeliveryStatusService deliveryStatusService;
        IMemberTypeService memberTypeService;
        ITruckService truckService;
        #endregion

        #region Contructors
        public ParameterService()
        {
            sessionService = new SessionServiceImp();
            memberService = new MemberServiceImp();
            companyService = new CompanyServiceImp();
            branchService = new BranchServiceImp();
            truckStatusService = new TruckStatusServiceImp();
            deliveryStatusService = new DeliveryStatusServiceImp();
            memberTypeService = new MemberTypeServiceImp();
            truckService = new TruckServiceImp();
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



        #region GetTruckStatusList
        [BOServiceFilter]
        public GetTruckStatusListResponse GetTruckStatusList(GetTruckStatusListRequest request)
        {
            GetTruckStatusListResponse response;

            if (request.Search == "")
            {
                var result = truckStatusService.GetAll(request.Session.FirmId);

                response = new GetTruckStatusListResponse
                {
                    TruckStatusList = result,
                    PageSize = 1

                };
            }
            else
            {
                var result = truckStatusService.Search(request.Session.FirmId, request.Search);

                response = new GetTruckStatusListResponse
                {
                    TruckStatusList = result,
                    PageSize = 1
                };
            }

            return response;
        }
        #endregion


        #region DeleteTruckStatus
        [BOServiceFilter]
        public DeleteTruckStatusResponse DeleteTruckStatus(DeleteTruckStatusRequest request)
        {
            DeleteTruckStatusResponse response;
            truckStatusService.ChangeStatus(request.Id, Dc.Model.Enumurations.RecordStatusEnum.Removed);

            response = new DeleteTruckStatusResponse
            {

            };

            return response;
        }
        #endregion


        #region InsertTruckStatus
        [BOServiceFilter]
        public InsertTruckStatusResponse InsertTruckStatus(InsertTruckStatusRequest request)
        {
            request.TruckStatus.FirmId = request.Session.FirmId;
            request.TruckStatus.Status = Dc.Model.Enumurations.RecordStatusEnum.Active;

            InsertTruckStatusResponse response;
            truckStatusService.Insert(request.TruckStatus);

            response = new InsertTruckStatusResponse
            {
            };

            return response;
        }
        #endregion

        #region EditTruckStatus
        [BOServiceFilter]
        public EditTruckStatusResponse EditTruckStatus(EditTruckStatusRequest request)
        {
            request.TruckStatus.FirmId = request.Session.FirmId;
            request.TruckStatus.Status = Dc.Model.Enumurations.RecordStatusEnum.Active;

            EditTruckStatusResponse response;
            truckStatusService.Update(request.TruckStatus);

            response = new EditTruckStatusResponse
            {
            };

            return response;
        }
        #endregion


        #region GetDeliveryStatusList
        [BOServiceFilter]
        public GetDeliveryStatusListResponse GetDeliveryStatusList(GetDeliveryStatusListRequest request)
        {
            GetDeliveryStatusListResponse response;

            if (request.Search == "")
            {
                var result = deliveryStatusService.GetAll(request.Session.FirmId);

                response = new GetDeliveryStatusListResponse
                {
                    DeliveryStatusList = result,
                    PageSize = 1

                };
            }
            else
            {
                var result = deliveryStatusService.Search(request.Session.FirmId, request.Search);

                response = new GetDeliveryStatusListResponse
                {
                    DeliveryStatusList = result,
                    PageSize = 1
                };
            }

            return response;
        }
        #endregion


        #region DeleteDeliveryStatus
        [BOServiceFilter]
        public DeleteDeliveryStatusResponse DeleteDeliveryStatus(DeleteDeliveryStatusRequest request)
        {
            DeleteDeliveryStatusResponse response;
            deliveryStatusService.ChangeStatus(request.Id, Dc.Model.Enumurations.RecordStatusEnum.Removed);

            response = new DeleteDeliveryStatusResponse
            {

            };

            return response;
        }
        #endregion


        #region InsertDeliveryStatus
        [BOServiceFilter]
        public InsertDeliveryStatusResponse InsertDeliveryStatus(InsertDeliveryStatusRequest request)
        {
            request.DeliveryStatus.FirmId = request.Session.FirmId;
            request.DeliveryStatus.Status = Dc.Model.Enumurations.RecordStatusEnum.Active;

            InsertDeliveryStatusResponse response;
            deliveryStatusService.Insert(request.DeliveryStatus);

            response = new InsertDeliveryStatusResponse
            {
            };

            return response;
        }
        #endregion

        #region EditDeliveryStatus
        [BOServiceFilter]
        public EditDeliveryStatusResponse EditDeliveryStatus(EditDeliveryStatusRequest request)
        {
            request.DeliveryStatus.FirmId = request.Session.FirmId;
            request.DeliveryStatus.Status = Dc.Model.Enumurations.RecordStatusEnum.Active;

            EditDeliveryStatusResponse response;
            deliveryStatusService.Update(request.DeliveryStatus);

            response = new EditDeliveryStatusResponse
            {
            };

            return response;
        }
        #endregion


        #region GetMemberTypeList
        [BOServiceFilter]
        public GetMemberTypeListResponse GetMemberTypeList(GetMemberTypeListRequest request)
        {
            GetMemberTypeListResponse response;

            if (request.Search == "")
            {
                var result = memberTypeService.GetAll(request.Session.FirmId);

                response = new GetMemberTypeListResponse
                {
                    MemberTypeList = result,
                    PageSize = 1

                };
            }
            else
            {
                var result = memberTypeService.Search(request.Session.FirmId, request.Search);

                response = new GetMemberTypeListResponse
                {
                    MemberTypeList = result,
                    PageSize = 1
                };
            }

            return response;
        }
        #endregion


        #region DeleteMemberType
        [BOServiceFilter]
        public DeleteMemberTypeResponse DeleteMemberType(DeleteMemberTypeRequest request)
        {
            DeleteMemberTypeResponse response;
            memberTypeService.ChangeStatus(request.Id, Dc.Model.Enumurations.RecordStatusEnum.Removed);

            response = new DeleteMemberTypeResponse
            {

            };

            return response;
        }
        #endregion


        #region InsertMemberType
        [BOServiceFilter]
        public InsertMemberTypeResponse InsertMemberType(InsertMemberTypeRequest request)
        {
            request.MemberType.FirmId = request.Session.FirmId;
            request.MemberType.Status = Dc.Model.Enumurations.RecordStatusEnum.Active;

            InsertMemberTypeResponse response;
            memberTypeService.Insert(request.MemberType);

            response = new InsertMemberTypeResponse
            {
            };

            return response;
        }
        #endregion

        #region EditDeliveryStatus
        [BOServiceFilter]
        public EditMemberTypeResponse EditMemberType(EditMemberTypeRequest request)
        {
            request.MemberType.FirmId = request.Session.FirmId;
            request.MemberType.Status = Dc.Model.Enumurations.RecordStatusEnum.Active;

            EditMemberTypeResponse response;
            memberTypeService.Update(request.MemberType);

            response = new EditMemberTypeResponse
            {
            };

            return response;
        }
        #endregion


        //TRUCK
        #region GetTruckList
        [BOServiceFilter]
        public GetTruckListResponse GetTruckList(GetTruckListRequest request)
        {
            GetTruckListResponse response;

            if (request.SelectedPage != -1)
            {
                if (request.Search == "")
                {
                    var result = truckService.GetAll(request.Session.FirmId, request.SelectedPage, numberOfItemsInPage);

                    response = new GetTruckListResponse
                    {
                        TruckList = result.Item1,
                        PageSize = result.Item2
                    };
                }
                else
                {
                    var result = truckService.Search(request.Session.FirmId, request.SelectedPage, numberOfItemsInPage, request.Search);

                    response = new GetTruckListResponse
                    {
                        TruckList = result.Item1,
                        PageSize = result.Item2
                    };
                }
            }
            else
            {
                var result = truckService.GetAll(request.Session.FirmId);

                response = new GetTruckListResponse
                {
                    TruckList = result,
                    PageSize = 0
                };
            }

            return response;
        }
        #endregion


        #region InsertTruck
        [BOServiceFilter]
        public InsertTruckResponse InsertTruck(InsertTruckRequest request)
        {
            request.Truck.FirmId = request.Session.FirmId;
            request.Truck.Status = Dc.Model.Enumurations.RecordStatusEnum.Active;

            InsertTruckResponse response;
            truckService.Insert(request.Truck);

            response = new InsertTruckResponse
            {
            };

            return response;
        }
        #endregion

        #region DeleteTruck
        [BOServiceFilter]
        public DeleteTruckResponse DeleteTruck(DeleteTruckRequest request)
        {
            DeleteTruckResponse response;
            truckService.ChangeStatus(request.Id, Dc.Model.Enumurations.RecordStatusEnum.Removed);

            response = new DeleteTruckResponse
            {

            };

            return response;
        }
        #endregion


        #region EditTruck
        [BOServiceFilter]
        public EditTruckResponse EditTruck(EditTruckRequest request)
        {
            request.Truck.FirmId = request.Session.FirmId;
            request.Truck.Status = Dc.Model.Enumurations.RecordStatusEnum.Active;

            EditTruckResponse response;
            truckService.Update(request.Truck);

            response = new EditTruckResponse
            {
            };

            return response;
        }
        #endregion


    }
}
