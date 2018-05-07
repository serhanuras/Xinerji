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
    public class TripServiceImp : ITripService
    {
        #region Local Variables
        SPExecutor spExecutor;
        #endregion


        public Trip ChangeStatus(long Id, RecordStatusEnum recordStatusEnum)
        {
            Trip returnvalue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnvalue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_changeTripStatus",
                        new object[] {
                            Id,
                            recordStatusEnum
                        });

                    returnvalue = TripDataBinder.ToTrip(dv);
                }

                return returnvalue;
            }
        }

        public void Dispose()
        {

        }

        public List<Trip> GetAll(long firmId)
        {
            List<Trip> returnValue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnValue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_getTrips",
                        new object[] {
                            firmId
                        });

                    returnValue = TripDataBinder.ToTripList(dv);
                }

                return returnValue;
            }
        }

        public Trip GetById(long Id)
        {
            Trip returnvalue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnvalue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_getTripById",
                        new object[] {
                            Id
                        });

                    returnvalue = TripDataBinder.ToTrip(dv);
                }

                return returnvalue;
            }
        }

        public Trip Insert(Trip trip)
        {
            Trip returnvalue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnvalue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_insertTrip",
                        new object[] {
                            trip.FirmId,
                            trip.Name,
                            trip.TruckId,
                            trip.ConsigneeId,
                            (int)trip.Status
                        });

                    returnvalue = TripDataBinder.ToTrip(dv);
                }

                return returnvalue;
            }
        }

        public Trip Update(Trip trip)
        {
            Trip returnvalue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnvalue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_updateTrip",
                        new object[] {
                            trip.Id,
                            trip.Name,
                            trip.TruckId,
                            trip.ConsigneeId,
                            (int)trip.Status
                        });

                    returnvalue = TripDataBinder.ToTrip(dv);
                }

                return returnvalue;
            }
        }
    }
}
