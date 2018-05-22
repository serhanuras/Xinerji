using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Model.Core;
using Xinerji.Dc.Model.Databinder;
using Xinerji.Dc.Model.Enumurations;
using Xinerji.Dc.Model.Interfaces;
using Xinerji.Integration;

namespace Xinerji.Dc.Services
{
    public class OrderServiceImp : IOrderService
    {
        #region Local Variables
        SPExecutor spExecutor;
        #endregion


        public Order ChangeStatus(long Id, RecordStatusEnum recordStatusEnum)
        {
            Order returnvalue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnvalue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_changeOrderStatus",
                        new object[] {
                            Id,
                            recordStatusEnum
                        });

                    returnvalue = OrderDataBinder.ToOrder(dv);
                }

                return returnvalue;
            }
        }

        public void Dispose()
        {

        }

        public List<Order> GetAll(long tripId)
        {
            List<Order> returnValue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnValue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_getAllOrders",
                        new object[] {
                            tripId
                        });

                    returnValue = OrderDataBinder.ToOrderList(dv);
                }

                return returnValue;
            }
        }

        public Tuple<List<Order>, int> GetAll(long firmId, int selectedPageNumber, int numberOfItemsInPage)
        {
            List<Order> orders = null;
            int totalPageSize = 0;
            using (spExecutor = new SPExecutor())
            {
                DataSet ds = spExecutor.ExecSProcDS("usp_getOrders",
                    new object[] {
                            firmId,
                            selectedPageNumber,
                            numberOfItemsInPage
                    });

                orders = OrderDataBinder.ToOrderList(ds.Tables[0].DefaultView);

                totalPageSize = int.Parse(ds.Tables[1].DefaultView[0][0].ToString());

                return new Tuple<List<Order>, int>(orders, totalPageSize); ;
            }
        }

        public Order GetById(long Id)
        {
            Order returnvalue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnvalue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_getOrderById",
                        new object[] {
                            Id
                        });

                    returnvalue = OrderDataBinder.ToOrder(dv);
                }

                return returnvalue;
            }
        }

        public Order Insert(Order order)
        {
            Order returnvalue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnvalue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_insertOrder",
                        new object[] {
                            order.TripId,
                            order.FirmId,
                            order.Title,
                            order.Description,
                            order.CityId,
                            order.BranchId,
                            order.BranchName,
                            order.DeliveryStatusId,
                            order.OrderTypeId,
                            (int)order.Status
                        });

                    returnvalue = OrderDataBinder.ToOrder(dv);
                }

                return returnvalue;
            }
        }

        public Tuple<List<Order>, int> Search(long firmId, int selectedPageNumber, int numberOfItemsInpage, string data)
        {
            List<Order> orders = null;
            int totalPageSize = 0;
            using (spExecutor = new SPExecutor())
            {
                DataSet ds = spExecutor.ExecSProcDS("usp_searchOrders",
                    new object[] {
                            firmId,
                            selectedPageNumber,
                            numberOfItemsInpage,
                            data
                    });

                orders = OrderDataBinder.ToOrderList(ds.Tables[0].DefaultView);

                totalPageSize = int.Parse(ds.Tables[1].DefaultView[0][0].ToString());

                return new Tuple<List<Order>, int>(orders, totalPageSize); ;
            }
        }

        public Order Update(Order order)
        {
            Order returnvalue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnvalue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_updateOrder",
                        new object[] {
                            order.Id,
                            order.Title,
                            order.Description,
                            order.CityId,
                            order.BranchId,
                            order.BranchName,
                            order.DeliveryStatusId,
                            order.OrderTypeId,
                            (int)order.Status
                        });

                    returnvalue = OrderDataBinder.ToOrder(dv);
                }

                return returnvalue;
            }
        }
    }
}
