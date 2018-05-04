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
    public static class CountyDataBinder
    {

        private static County GetCountyField(DataRowView drv)
        {
            return new County
            {
                Id = int.Parse(UtilMethods.StripHTML(drv["Id"].ToString())),
                CityId = int.Parse(UtilMethods.StripHTML(drv["CityId"].ToString())),
                Name = UtilMethods.StripHTML(drv["Name"].ToString())
            };
        }

        public static County ToCounty(DataView dv)
        {
            if (dv.Count > 0)
            {
                return GetCountyField(dv[0]);
            }

            return null;
        }

        public static List<County> ToCountyList(DataView dv)
        {
            List<County> cities = new List<County>();
            for (int i = 0; i < dv.Count; i++)
            {
                cities.Add(GetCountyField(dv[i]));
            }

            return cities;
        }
    }
}
