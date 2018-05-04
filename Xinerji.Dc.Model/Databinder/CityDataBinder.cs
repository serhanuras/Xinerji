using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Model.Core;
using Xinerji.Utilities;

namespace Xinerji.Dc.Model.Databinder
{
    public static class CityDataBinder
    {

        private static City GetCityField(DataRowView drv)
        {
            return new City
            {
                Id = int.Parse(UtilMethods.StripHTML(drv["Id"].ToString())),
                CountryId = int.Parse(UtilMethods.StripHTML(drv["CountryId"].ToString())),
                Name = UtilMethods.StripHTML(drv["Name"].ToString())
            };
        }

        public static City ToCity(DataView dv)
        {
            if (dv.Count > 0)
            {
                return GetCityField(dv[0]);
            }

            return null;
        }

        public static List<City> ToCitytList(DataView dv)
        {
            List<City> cities = new List<City>();
            for (int i = 0; i < dv.Count; i++)
            {
                cities.Add(GetCityField(dv[i]));
            }

            return cities;
        }
    }
}
