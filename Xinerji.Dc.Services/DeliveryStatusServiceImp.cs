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
    public class DeliveryStatusServiceImp : IDeliveryStatusService
    {
        #region Local Variables
        SPExecutor spExecutor;
        #endregion

        public DeliveryStatus ChangeStatus(long Id, RecordStatusEnum recordStatusEnum)
        {
            DeliveryStatus returnvalue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnvalue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_changeDeliveryStatusState",
                        new object[] {
                            Id,
                            recordStatusEnum
                        });

                    returnvalue = DeliveryStatusDataBinder.ToDeliveryStatus(dv);
                }

                return returnvalue;
            }
        }

        public void Dispose()
        {
            
        }

        public List<DeliveryStatus> GetAll(long firmId)
        {
            List<DeliveryStatus> returnValue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnValue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_getDeliveryStatusList",
                        new object[] {
                            firmId
                        });

                    returnValue = DeliveryStatusDataBinder.ToDeliveryStatusList(dv);
                }

                return returnValue;
            }
        }

        public DeliveryStatus Insert(DeliveryStatus deliveryStatus)
        {
            DeliveryStatus returnvalue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnvalue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_insertDeliveryStatus",
                        new object[] {
                            deliveryStatus.FirmId,
                            deliveryStatus.Name,
                            (int) deliveryStatus.Status
                        });

                    returnvalue = DeliveryStatusDataBinder.ToDeliveryStatus(dv);
                }

                return returnvalue;
            }
        }

        public List<DeliveryStatus> Search(long firmId, string data)
        {
            List<DeliveryStatus> returnValue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnValue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_searchDeliveryStatusList",
                        new object[] {
                            firmId,
                            data
                        });

                    returnValue = DeliveryStatusDataBinder.ToDeliveryStatusList(dv);
                }

                return returnValue;
            }
        }

        public DeliveryStatus Update(DeliveryStatus deliveryStatus)
        {
            DeliveryStatus returnvalue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnvalue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_updateDeliveryStatus",
                        new object[] {
                            deliveryStatus.Id,
                            deliveryStatus.Name,
                            (int) deliveryStatus.Status
                        });

                    returnvalue = DeliveryStatusDataBinder.ToDeliveryStatus(dv);
                }

                return returnvalue;
            }
        }
    }
}
