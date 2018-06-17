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
    public static class OrderDataBinder
    {
        private static Order GetOrderField(DataRowView drv)
        {
            return new Order
            {
                Id = long.Parse(UtilMethods.StripHTML(drv["Id"].ToString())),
                FirmId = long.Parse(UtilMethods.StripHTML(drv["FirmId"].ToString())),
                TripId = long.Parse(UtilMethods.StripHTML(drv["TripId"].ToString())),
                Title = UtilMethods.StripHTML(drv["Title"].ToString()),
                ConsignmentNo = UtilMethods.StripHTML(drv["ConsignmentNo"].ToString()),
                ReceiptNo = UtilMethods.StripHTML(drv["ReceiptNo"].ToString()),
                Description = UtilMethods.StripHTML(drv["Description"].ToString()),
                CityId = long.Parse(UtilMethods.StripHTML(drv["CityId"].ToString())),
                BranchId = long.Parse(UtilMethods.StripHTML(drv["BranchId"].ToString())),
                BranchName = UtilMethods.StripHTML(drv["BranchName"].ToString()),
                CompanyName = UtilMethods.StripHTML(drv["CompanyName"].ToString()),
                DeliveryStatusId = long.Parse(UtilMethods.StripHTML(drv["DeliveryStatusId"].ToString())),
                DeliveryStatus = UtilMethods.StripHTML(drv["DeliveryStatus"].ToString()),
                OrderTypeId = long.Parse(UtilMethods.StripHTML(drv["OrderTypeId"].ToString())),
                Status = (RecordStatusEnum)UtilMethods.ToEnum<RecordStatusEnum>(UtilMethods.StripHTML(drv["Status"].ToString())),
            };
        }

        public static Order ToOrder(DataView dv)
        {
            if (dv.Count > 0)
            {
                return GetOrderField(dv[0]);
            }

            return null;
        }

        public static List<Order> ToOrderList(DataView dv)
        {
            List<Order> tripList = new List<Order>();
            for (int i = 0; i < dv.Count; i++)
            {
                tripList.Add(GetOrderField(dv[i]));
            }

            return tripList;
        }
    }
}
