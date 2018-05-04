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

    public static class OrderTypeDataBinder
    {

        private static OrderType GetOrderTypeField(DataRowView drv)
        {
            return new OrderType
            {
                Id = long.Parse(UtilMethods.StripHTML(drv["Id"].ToString())),
                FirmId = long.Parse(UtilMethods.StripHTML(drv["FirmId"].ToString())),
                Name = UtilMethods.StripHTML(drv["Name"].ToString()),
                Status = (RecordStatusEnum)UtilMethods.ToEnum<RecordStatusEnum>(UtilMethods.StripHTML(drv["Status"].ToString())),
            };
        }

        public static OrderType ToOrderType(DataView dv)
        {
            if (dv.Count > 0)
            {
                return GetOrderTypeField(dv[0]);
            }

            return null;
        }

        public static List<OrderType> ToOrderTypeList(DataView dv)
        {
            List<OrderType> orderTypes = new List<OrderType>();
            for (int i = 0; i < dv.Count; i++)
            {
                orderTypes.Add(GetOrderTypeField(dv[i]));
            }

            return orderTypes;
        }
    }
}
