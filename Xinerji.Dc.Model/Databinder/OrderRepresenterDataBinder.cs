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
    public static class OrderRepresenterDataBinder
    {
        private static OrderRepresenter GetOrderRepresenterFields(DataRowView drv)
        {
            return new OrderRepresenter
            {
                Id = long.Parse(UtilMethods.StripHTML(drv["Id"].ToString())),
                OrderId = long.Parse(UtilMethods.StripHTML(drv["OrderId"].ToString())),
                RepresenterId = long.Parse(UtilMethods.StripHTML(drv["RepresenterId"].ToString())),
                Level = int.Parse(drv["Level"].ToString())
            };
        }

        public static OrderRepresenter ToOrderRepresenter(DataView dv)
        {
            if (dv.Count > 0)
            {
                return GetOrderRepresenterFields(dv[0]);
            }

            return null;
        }

        public static List<OrderRepresenter> ToOrderRepresenterList(DataView dv)
        {
            List<OrderRepresenter> transactions = new List<OrderRepresenter>();
            for (int i = 0; i < dv.Count; i++)
            {
                transactions.Add(GetOrderRepresenterFields(dv[i]));
            }

            return transactions;
        }
    }
}
