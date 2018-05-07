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
    public class OrderRepresenterServiceImp : IOrderRepresenterService
    {
        #region Local Variables
        SPExecutor spExecutor;
        #endregion


        public OrderRepresenter Delete(long Id)
        {
            OrderRepresenter returnvalue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnvalue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_deleteOrderRepresenter",
                        new object[] {
                            Id
                        });

                    returnvalue = OrderRepresenterDataBinder.ToOrderRepresenter(dv);
                }

                return returnvalue;
            }
        }

        public void Dispose()
        {

        }

        public List<OrderRepresenter> GetAll(long orderId)
        {
            List<OrderRepresenter> returnValue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnValue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_getOrderRepresenters",
                        new object[] {
                            orderId
                        });

                    returnValue = OrderRepresenterDataBinder.ToOrderRepresenterList(dv);
                }

                return returnValue;
            }
        }

        public OrderRepresenter GetById(long Id)
        {
            OrderRepresenter returnvalue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnvalue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_getOrderRepresenterById",
                        new object[] {
                            Id
                        });

                    returnvalue = OrderRepresenterDataBinder.ToOrderRepresenter(dv);
                }

                return returnvalue;
            }
        }

        public OrderRepresenter Insert(OrderRepresenter orderRepresenter)
        {
            OrderRepresenter returnvalue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnvalue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_insertOrderRepresenter",
                        new object[] {
                            orderRepresenter.OrderId,
                            orderRepresenter.RepresenterId,
                            orderRepresenter.Level
                        });

                    returnvalue = OrderRepresenterDataBinder.ToOrderRepresenter(dv);
                }

                return returnvalue;
            }
        }

        public OrderRepresenter Update(OrderRepresenter orderRepresenter)
        {
            OrderRepresenter returnvalue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnvalue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_updateOrderRepresenter",
                        new object[] {
                            orderRepresenter.Id,
                            orderRepresenter.OrderId,
                            orderRepresenter.RepresenterId,
                            orderRepresenter.Level
                        });

                    returnvalue = OrderRepresenterDataBinder.ToOrderRepresenter(dv);
                }

                return returnvalue;
            }
        }
    }
}
