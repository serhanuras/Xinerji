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
    public static class OrderDocumentDataBinder
    {
        private static OrderDocument GetOrderDocumentFields(DataRowView drv)
        {
            return new OrderDocument
            {
                Id = long.Parse(UtilMethods.StripHTML(drv["Id"].ToString())),
                OrderId = long.Parse(UtilMethods.StripHTML(drv["OrderId"].ToString())),
                DocumentTypeId = long.Parse(UtilMethods.StripHTML(drv["DocumentTypeId"].ToString())),
                FileName = UtilMethods.StripHTML(drv["FileName"].ToString()),
                FileExtension = UtilMethods.StripHTML(drv["FileExtension"].ToString()),
                FileBinary = UtilMethods.StripHTML(drv["FileBinary"].ToString())
            };
        }

        public static OrderDocument ToOrderDocument(DataView dv)
        {
            if (dv.Count > 0)
            {
                return GetOrderDocumentFields(dv[0]);
            }

            return null;
        }

        public static List<OrderDocument> ToOrderDocumentList(DataView dv)
        {
            List<OrderDocument> transactions = new List<OrderDocument>();
            for (int i = 0; i < dv.Count; i++)
            {
                transactions.Add(GetOrderDocumentFields(dv[i]));
            }

            return transactions;
        }
    }
}
