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
    public class OrderTypeServiceImp : IOrderTypeService
    {
        #region Local Variables
        SPExecutor spExecutor;
        #endregion

        public OrderType ChangeStatus(long Id, RecordStatusEnum recordStatusEnum)
        {
            OrderType returnvalue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnvalue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_changeOrderTypeStatus",
                        new object[] {
                            Id,
                            recordStatusEnum
                        });

                    returnvalue = OrderTypeDataBinder.ToOrderType(dv);
                }

                return returnvalue;
            }
        }

        public void Dispose()
        {
            
        }

        public List<OrderType> GetAll(long firmId)
        {
            List<OrderType> returnValue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnValue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_getOrderTypes",
                        new object[] {
                            firmId
                        });

                    returnValue = OrderTypeDataBinder.ToOrderTypeList(dv);
                }

                return returnValue;
            }
        }

        public OrderType Insert(OrderType orderType)
        {
            OrderType returnvalue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnvalue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_insertOrderType",
                        new object[] {
                            orderType.FirmId,
                            orderType.Name,
                            (int)orderType.Status
                        });

                    returnvalue = OrderTypeDataBinder.ToOrderType(dv);
                }

                return returnvalue;
            }
        }

        public OrderType Update(OrderType orderType)
        {
            OrderType returnvalue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnvalue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_updateOrderType",
                        new object[] {
                            orderType.Id,
                            orderType.Name,
                            (int)orderType.Status
                        });

                    returnvalue = OrderTypeDataBinder.ToOrderType(dv);
                }

                return returnvalue;
            }
        }
    }
}
