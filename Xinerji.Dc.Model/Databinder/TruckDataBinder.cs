using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Model.Core;
using Xinerji.Dc.Model.Enumurations;
using Xinerji.Utilities;
namespace Xinerji.Dc.Model.Databinder
{
    public class TruckDataBinder
    {
        private static Truck GetTruckFields(DataRowView drv)
        {
            return new Truck
            {
                Id = long.Parse(UtilMethods.StripHTML(drv["Id"].ToString())),
                FirmId = long.Parse(UtilMethods.StripHTML(drv["FirmId"].ToString())),
                MemberId = long.Parse(UtilMethods.StripHTML(drv["MemberId"].ToString())),
                LicenceNo = UtilMethods.StripHTML(drv["LicenceNo"].ToString()),
                Capacity = int.Parse(drv["Capacity"].ToString()),
                Model = UtilMethods.StripHTML(drv["Model"].ToString()),
                Year = int.Parse(drv["Year"].ToString()),
                Plaque = UtilMethods.StripHTML(drv["Plaque"].ToString()),
                Status = (RecordStatusEnum)UtilMethods.ToEnum<RecordStatusEnum>(UtilMethods.StripHTML(drv["Status"].ToString())),
            };
        }

        public static Truck ToTruck(DataView dv)
        {
            if (dv.Count > 0)
            {
                return GetTruckFields(dv[0]);
            }

            return null;
        }

        public static List<Truck> ToTruckList(DataView dv)
        {
            List<Truck> transactions = new List<Truck>();
            for (int i = 0; i < dv.Count; i++)
            {
                transactions.Add(GetTruckFields(dv[i]));
            }

            return transactions;
        }
    }
}
