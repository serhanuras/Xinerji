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

        public Tuple<List<Trip>, int> GetAll(long firmId, int selectedPageNumber, int numberOfItemsInPage)
        {
            List<Trip> trips = null;
            int totalPageSize = 0;
            using (spExecutor = new SPExecutor())
            {
                DataSet ds = spExecutor.ExecSProcDS("usp_getTrips",
                    new object[] {
                            firmId,
                            selectedPageNumber,
                            numberOfItemsInPage
                    });

                trips = TripDataBinder.ToTripList(ds.Tables[0].DefaultView);

                totalPageSize = int.Parse(ds.Tables[1].DefaultView[0][0].ToString());

                return new Tuple<List<Trip>, int>(trips, totalPageSize); ;
            }
        }

        public Tuple<List<Trip>, int> Search(long firmId, int selectedPageNumber, int numberOfItemsInPage, string data)
        {
            List<Trip> trips = null;
            int totalPageSize = 0;
            using (spExecutor = new SPExecutor())
            {

                DataSet ds = spExecutor.ExecSProcDS("usp_searchTrips",
                    new object[] {
                            firmId,
                            selectedPageNumber,
                            numberOfItemsInPage,
                            data
                    });

                trips = TripDataBinder.ToTripList(ds.Tables[0].DefaultView);

                totalPageSize = int.Parse(ds.Tables[1].DefaultView[0][0].ToString());


                return new Tuple<List<Trip>, int>(trips, totalPageSize); ;
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
