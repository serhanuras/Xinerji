using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Model.Core;
using Xinerji.Utilities;

namespace Xinerji.Dc.Model.Databinder
{
    public class FirmDataBinder
    {

        private static Firm GetFirmFields(DataRowView drv)
        {
            return new Firm
            {
                Id = long.Parse(UtilMethods.StripHTML(drv["Id"].ToString())),
                Name = UtilMethods.StripHTML(drv["Name"].ToString()),
                Address = UtilMethods.StripHTML(drv["Address"].ToString()),
                Email = UtilMethods.StripHTML(drv["Email"].ToString()),
                Phone = UtilMethods.StripHTML(drv["Phone"].ToString()),
                Location = UtilMethods.StripHTML(drv["Location"].ToString())
            };
        }

        public static Firm ToFirm(DataView dv)
        {
            if (dv.Count > 0)
            {
                return GetFirmFields(dv[0]);
            }

            return null;
        }

        public static List<Firm> ToFirmList(DataView dv)
        {
            List<Firm> firms = new List<Firm>();
            for (int i = 0; i < dv.Count; i++)
            {
                firms.Add(GetFirmFields(dv[i]));
            }

            return firms;
        }
    }
}
