using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Model.Core;
using Xinerji.Dc.Model.Databinder;
using Xinerji.Dc.Model.Interfaces;
using Xinerji.Integration;

namespace Xinerji.Dc.Services
{
    public class UtilitiesServiceImp : IUtilitiesService
    {
        #region LocalVariables
        SPExecutor spExecutor;
        #endregion

        #region Constructor
        public UtilitiesServiceImp()
        {

        }
        #endregion

        #region GetCityCountyList
        public List<County> GetCityCountyList(int CityId)
        {
            return GetCountyList().Where(e => e.CityId == CityId).ToList();
        }
        #endregion 


        #region GetCityList
        private static List<City> cityList;
        public List<City> GetCityList()
        {
            using (spExecutor = new SPExecutor())
            {
                if (cityList == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_getCityList",
                       new object[] {

                       });

                    cityList = CityDataBinder.ToCitytList(dv);
                }
                return cityList;
            }
        }
        #endregion 

        #region GetCountyList
        private static List<County> countyList;
        public List<County> GetCountyList()
        {
            using (spExecutor = new SPExecutor())
            {
                if (countyList == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_getCountyList",
                      new object[] {

                      });

                    countyList = CountyDataBinder.ToCountyList(dv);
                }
                return countyList;
            }
        }
        #endregion

        #region GetCity
        public City GetCity(int CityId)
        {
            return GetCityList().Where(e => e.Id == CityId).ToList()[0];
        }
        #endregion 

        #region GetCounty
        public County GetCounty(int CountyId)
        {
            return GetCountyList().Where(e => e.Id == CountyId).ToList()[0];
        }
        #endregion

        


    

        #region Dispose
        public void Dispose()
        {

        }
        #endregion
    }
}
