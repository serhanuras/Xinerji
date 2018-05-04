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
    public class DeliveryStatusDataBinder
    {
        private static DeliveryStatus GetDeliveryStatusField(DataRowView drv)
        {
            return new DeliveryStatus
            {
                Id = long.Parse(UtilMethods.StripHTML(drv["Id"].ToString())),
                FirmId = long.Parse(UtilMethods.StripHTML(drv["FirmId"].ToString())),
                Name = UtilMethods.StripHTML(drv["Name"].ToString()),
                Status = (RecordStatusEnum)UtilMethods.ToEnum<RecordStatusEnum>(UtilMethods.StripHTML(drv["Status"].ToString())),
            };
        }

        public static DeliveryStatus ToDeliveryStatus(DataView dv)
        {
            if (dv.Count > 0)
            {
                return GetDeliveryStatusField(dv[0]);
            }

            return null;
        }

        public static List<DeliveryStatus> ToDeliveryStatusList(DataView dv)
        {
            List<DeliveryStatus> deliveryStatusList = new List<DeliveryStatus>();
            for (int i = 0; i < dv.Count; i++)
            {
                deliveryStatusList.Add(GetDeliveryStatusField(dv[i]));
            }

            return deliveryStatusList;
        }
    }
}
