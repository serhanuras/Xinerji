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
    public static class OrderDetailDataBinder
    {
        private static OrderDetail GetOrderDetailFields(DataRowView drv)
        {
            return new OrderDetail
            {
                Id = long.Parse(UtilMethods.StripHTML(drv["Id"].ToString())),
                FirmId = long.Parse(UtilMethods.StripHTML(drv["FirmId"].ToString())),
                OrderId = long.Parse(UtilMethods.StripHTML(drv["OrderId"].ToString())),
                ProductId = long.Parse(UtilMethods.StripHTML(drv["ProductId"].ToString())),
                ProductDescription = UtilMethods.StripHTML(drv["ProductDescription"].ToString()),
                Quantity = int.Parse(drv["Quantity"].ToString()),
                Status = (RecordStatusEnum)UtilMethods.ToEnum<RecordStatusEnum>(UtilMethods.StripHTML(drv["Status"].ToString())),
            };
        }

        public static OrderDetail ToOrderDetail(DataView dv)
        {
            if (dv.Count > 0)
            {
                return GetOrderDetailFields(dv[0]);
            }

            return null;
        }

        public static List<OrderDetail> ToOrderDetailList(DataView dv)
        {
            List<OrderDetail> transactions = new List<OrderDetail>();
            for (int i = 0; i < dv.Count; i++)
            {
                transactions.Add(GetOrderDetailFields(dv[i]));
            }

            return transactions;
        }
    }
}
