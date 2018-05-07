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
    public class OrderMissingItemServiceImp : IOrderMissingItemService
    {
        #region Local Variables
        SPExecutor spExecutor;
        #endregion


        public OrderMissingItem Delete(long Id)
        {
            OrderMissingItem returnvalue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnvalue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_deleteOrderMissingItem",
                        new object[] {
                            Id
                        });

                    returnvalue = OrderMissingItemDataBinder.ToOrderMissingItem(dv);
                }

                return returnvalue;
            }
        }

        public void Dispose()
        {

        }

        public List<OrderMissingItem> GetAll(long orderId)
        {
            List<OrderMissingItem> returnValue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnValue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_getOrderMissingItems",
                        new object[] {
                            orderId
                        });

                    returnValue = OrderMissingItemDataBinder.ToOrderMissingItemList(dv);
                }

                return returnValue;
            }
        }

        public OrderMissingItem GetById(long Id)
        {
            OrderMissingItem returnvalue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnvalue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_getOrderMissingItemById",
                        new object[] {
                            Id
                        });

                    returnvalue = OrderMissingItemDataBinder.ToOrderMissingItem(dv);
                }

                return returnvalue;
            }
        }

        public OrderMissingItem Insert(OrderMissingItem orderMissingItem)
        {
            OrderMissingItem returnvalue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnvalue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_insertOrderMissingItem",
                        new object[] {
                            orderMissingItem.OrderId,
                            orderMissingItem.OrderDetailId,
                            orderMissingItem.Quantity
                        });

                    returnvalue = OrderMissingItemDataBinder.ToOrderMissingItem(dv);
                }

                return returnvalue;
            }
        }

        public OrderMissingItem Update(OrderMissingItem orderMissingItem)
        {
            OrderMissingItem returnvalue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnvalue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_updateOrderMissingItem",
                        new object[] {
                            orderMissingItem.Id,
                            orderMissingItem.OrderId,
                            orderMissingItem.OrderDetailId,
                            orderMissingItem.Quantity
                        });

                    returnvalue = OrderMissingItemDataBinder.ToOrderMissingItem(dv);
                }

                return returnvalue;
            }
        }
    }
}
