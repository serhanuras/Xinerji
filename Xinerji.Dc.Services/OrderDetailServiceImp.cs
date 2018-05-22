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
    public class OrderDetailServiceImp : IOrderDetailService
    {
        #region Local Variables
        SPExecutor spExecutor;
        #endregion


        public OrderDetail ChangeStatus(long Id, RecordStatusEnum recordStatusEnum)
        {
            OrderDetail returnvalue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnvalue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_changeOrderDetailStatus",
                        new object[] {
                            Id,
                            recordStatusEnum
                        });

                    returnvalue = OrderDetailDataBinder.ToOrderDetail(dv);
                }

                return returnvalue;
            }
        }

        public void Dispose()
        {

        }

        public List<OrderDetail> GetAll(long orderId, long firmId)
        {
            List<OrderDetail> returnValue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnValue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_getOrderDetails",
                        new object[] {
                            orderId
                        });

                    returnValue = OrderDetailDataBinder.ToOrderDetailList(dv);
                }

                return returnValue;
            }
        }

       


        public OrderDetail GetById(long Id)
        {
            OrderDetail returnvalue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnvalue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_getOrderDetailById",
                        new object[] {
                            Id
                        });

                    returnvalue = OrderDetailDataBinder.ToOrderDetail(dv);
                }

                return returnvalue;
            }
        }

        public OrderDetail Insert(OrderDetail orderDetail)
        {
            OrderDetail returnvalue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnvalue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_insertOrderDetail",
                        new object[] {
                            orderDetail.FirmId,
                            orderDetail.OrderId,
                            orderDetail.ProductId,
                            orderDetail.Quantity,
                            (int)orderDetail.Status
                        });

                    returnvalue = OrderDetailDataBinder.ToOrderDetail(dv);
                }

                return returnvalue;
            }
        }

        public OrderDetail Update(OrderDetail orderDetail)
        {
            OrderDetail returnvalue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnvalue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_updateOrderDetail",
                        new object[] {
                            orderDetail.Id,
                            orderDetail.OrderId,
                            orderDetail.ProductId,
                            orderDetail.Quantity,
                            (int)orderDetail.Status
                        });

                    returnvalue = OrderDetailDataBinder.ToOrderDetail(dv);
                }

                return returnvalue;
            }
        }
    }
}
