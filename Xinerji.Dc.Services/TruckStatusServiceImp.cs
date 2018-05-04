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
    public class TruckStatusServiceImp : ITruckStatusService
    {

        #region Local Variables
        SPExecutor spExecutor;
        #endregion


        public TruckStatus ChangeStatus(long Id, RecordStatusEnum recordStatusEnum)
        {
            TruckStatus returnvalue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnvalue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_changeTruckStatus",
                        new object[] {
                            Id,
                            recordStatusEnum
                        });

                    returnvalue = TruckStatusDataBinder.ToTruckStatus(dv);
                }

                return returnvalue;
            }
        }

        public void Dispose()
        {
            
        }

        public List<TruckStatus> GetAll(long firmId)
        {
            List<TruckStatus> returnValue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnValue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_getTruckStatus",
                        new object[] {
                            firmId
                        });

                    returnValue = TruckStatusDataBinder.ToTruckStatusList(dv);
                }

                return returnValue;
            }
        }

        public TruckStatus Insert(TruckStatus truckStatus)
        {
            TruckStatus returnvalue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnvalue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_insertTruckStatus",
                        new object[] {
                            truckStatus.FirmId,
                            truckStatus.Name,
                            (int)truckStatus.Status
                        });

                    returnvalue = TruckStatusDataBinder.ToTruckStatus(dv);
                }

                return returnvalue;
            }
        }

        public TruckStatus Update(TruckStatus truckStatus)
        {
            TruckStatus returnvalue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnvalue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_updateTruckStatus",
                        new object[] {
                            truckStatus.Id,
                            truckStatus.Name,
                            (int)truckStatus.Status
                        });

                    returnvalue = TruckStatusDataBinder.ToTruckStatus(dv);
                }

                return returnvalue;
            }
        }
    }
}
