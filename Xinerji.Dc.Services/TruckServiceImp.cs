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
    public class TruckServiceImp : ITruckService
    {
        #region Local Variables
        SPExecutor spExecutor;
        #endregion


        public Truck ChangeStatus(long Id, RecordStatusEnum recordStatusEnum)
        {
            Truck returnvalue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnvalue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_changeTruckStatus",
                        new object[] {
                            Id,
                            recordStatusEnum
                        });

                    returnvalue = TruckDataBinder.ToTruck(dv);
                }

                return returnvalue;
            }
        }

        public void Dispose()
        {

        }

        public List<Truck> GetAll(long firmId)
        {
            List<Truck> returnValue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnValue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_getAllTrucks",
                        new object[] {
                            firmId
                        });

                    returnValue = TruckDataBinder.ToTruckList(dv);
                }

                return returnValue;
            }
        }

        public Tuple<List<Truck>, int> GetAll(long firmId, int selectedPageNumber, int numberOfItemsInPage)
        {
            List<Truck> trucks = null;
            int totalPageSize = 0;
            using (spExecutor = new SPExecutor())
            {
                DataSet ds = spExecutor.ExecSProcDS("usp_getTrucks",
                    new object[] {
                            firmId,
                            selectedPageNumber,
                            numberOfItemsInPage
                    });

                trucks = TruckDataBinder.ToTruckList(ds.Tables[0].DefaultView);

                totalPageSize = int.Parse(ds.Tables[1].DefaultView[0][0].ToString());

                return new Tuple<List<Truck>, int>(trucks, totalPageSize); ;
            }
        }

        public Truck GetById(long Id)
        {
            Truck returnvalue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnvalue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_getTruckById",
                        new object[] {
                            Id
                        });

                    returnvalue = TruckDataBinder.ToTruck(dv);
                }

                return returnvalue;
            }
        }

        public Truck Insert(Truck truck)
        {
            Truck returnvalue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnvalue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_insertTruck",
                        new object[] {
                            truck.FirmId,
                            truck.MemberId,
                            truck.MemberName,
                            truck.LicenceNo,
                            truck.Capacity,
                            truck.Model,
                            truck.Year,
                            truck.Plaque,
                            truck.TruckStatusId,
                            (int)truck.Status
                        });

                    returnvalue = TruckDataBinder.ToTruck(dv);
                }

                return returnvalue;
            }
        }

        public Tuple<List<Truck>, int> Search(long firmId, int selectedPageNumber, int numberOfItemsInpage, string data)
        {
            List<Truck> trucks = null;
            int totalPageSize = 0;
            using (spExecutor = new SPExecutor())
            {
                DataSet ds = spExecutor.ExecSProcDS("usp_searchTrucks",
                    new object[] {
                            firmId,
                            selectedPageNumber,
                            numberOfItemsInpage,
                            data
                    });

                trucks = TruckDataBinder.ToTruckList(ds.Tables[0].DefaultView);

                totalPageSize = int.Parse(ds.Tables[1].DefaultView[0][0].ToString());

                return new Tuple<List<Truck>, int>(trucks, totalPageSize); ;
            }
        }

        public Truck Update(Truck truck)
        {
            Truck returnvalue = null;
            using (spExecutor = new SPExecutor())
            {
                if (returnvalue == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_updateTruck",
                        new object[] {
                            truck.Id,
                            truck.MemberId,
                            truck.MemberName,
                            truck.LicenceNo,
                            truck.Capacity,
                            truck.Model,
                            truck.Year,
                            truck.Plaque,
                            truck.TruckStatusId,
                            (int)truck.Status
                        });

                    returnvalue = TruckDataBinder.ToTruck(dv);
                }

                return returnvalue;
            }
        }
    }
}
