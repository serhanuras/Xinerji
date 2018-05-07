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
    public static class TripDataBinder
    {
        private static Trip GetTripField(DataRowView drv)
        {
            return new Trip
            {
                Id = long.Parse(UtilMethods.StripHTML(drv["Id"].ToString())),
                FirmId = long.Parse(UtilMethods.StripHTML(drv["FirmId"].ToString())),
                Name = UtilMethods.StripHTML(drv["Name"].ToString()),
                TruckId = long.Parse(UtilMethods.StripHTML(drv["TruckId"].ToString())),
                ConsigneeId = long.Parse(UtilMethods.StripHTML(drv["ConsigneeId"].ToString())),
                Status = (RecordStatusEnum)UtilMethods.ToEnum<RecordStatusEnum>(UtilMethods.StripHTML(drv["Status"].ToString())),
            };
        }

        public static Trip ToTrip(DataView dv)
        {
            if (dv.Count > 0)
            {
                return GetTripField(dv[0]);
            }

            return null;
        }

        public static List<Trip> ToTripList(DataView dv)
        {
            List<Trip> tripList = new List<Trip>();
            for (int i = 0; i < dv.Count; i++)
            {
                tripList.Add(GetTripField(dv[i]));
            }

            return tripList;
        }
    }
}
