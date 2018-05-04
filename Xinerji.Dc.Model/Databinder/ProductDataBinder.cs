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
    public static class ProductDataBinder
    {
        private static Product GetProductFields(DataRowView drv)
        {
            return new Product
            {
                Id = long.Parse(UtilMethods.StripHTML(drv["Id"].ToString())),
                FirmId = long.Parse(UtilMethods.StripHTML(drv["FirmId"].ToString())),
                Name = UtilMethods.StripHTML(drv["Name"].ToString()),
                Barcode = UtilMethods.StripHTML(drv["Barcode"].ToString()),
                Weight = int.Parse(drv["Weight"].ToString()),
                Height = int.Parse(drv["Height"].ToString()),
                Width = int.Parse(drv["Width"].ToString()),
                Volume = int.Parse(drv["Volume"].ToString()),
                Status = (RecordStatusEnum)UtilMethods.ToEnum<RecordStatusEnum>(UtilMethods.StripHTML(drv["Status"].ToString())),
            };
        }

        public static Product ToProduct(DataView dv)
        {
            if (dv.Count > 0)
            {
                return GetProductFields(dv[0]);
            }

            return null;
        }

        public static List<Product> ToProductList(DataView dv)
        {
            List<Product> transactions = new List<Product>();
            for (int i = 0; i < dv.Count; i++)
            {
                transactions.Add(GetProductFields(dv[i]));
            }

            return transactions;
        }
    }
}
