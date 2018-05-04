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
    public class TruckStatusDataBinder
    {
        private static TruckStatus GetTruckStatusField(DataRowView drv)
        {
            return new TruckStatus
            {
                Id = long.Parse(UtilMethods.StripHTML(drv["Id"].ToString())),
                FirmId = long.Parse(UtilMethods.StripHTML(drv["FirmId"].ToString())),
                Name = UtilMethods.StripHTML(drv["Name"].ToString()),
                Status = (RecordStatusEnum)UtilMethods.ToEnum<RecordStatusEnum>(UtilMethods.StripHTML(drv["Status"].ToString())),
            };
        }

        public static TruckStatus ToTruckStatus(DataView dv)
        {
            if (dv.Count > 0)
            {
                return GetTruckStatusField(dv[0]);
            }

            return null;
        }

        public static List<TruckStatus> ToTruckStatusList(DataView dv)
        {
            List<TruckStatus> truckStatusList = new List<TruckStatus>();
            for (int i = 0; i < dv.Count; i++)
            {
                truckStatusList.Add(GetTruckStatusField(dv[i]));
            }

            return truckStatusList;
        }
    }
}
