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
    public static class OrderMissingItemDataBinder
    {
        private static OrderMissingItem GetOrderMissingItemFields(DataRowView drv)
        {
            return new OrderMissingItem
            {
                Id = long.Parse(UtilMethods.StripHTML(drv["Id"].ToString())),
                OrderId = long.Parse(UtilMethods.StripHTML(drv["OrderId"].ToString())),
                OrderDetailId = long.Parse(UtilMethods.StripHTML(drv["OrderDetailId"].ToString())),
                Quantity = int.Parse(drv["Quantity"].ToString())
            };
        }

        public static OrderMissingItem ToOrderMissingItem(DataView dv)
        {
            if (dv.Count > 0)
            {
                return GetOrderMissingItemFields(dv[0]);
            }

            return null;
        }

        public static List<OrderMissingItem> ToOrderMissingItemList(DataView dv)
        {
            List<OrderMissingItem> transactions = new List<OrderMissingItem>();
            for (int i = 0; i < dv.Count; i++)
            {
                transactions.Add(GetOrderMissingItemFields(dv[i]));
            }

            return transactions;
        }
    }
}
