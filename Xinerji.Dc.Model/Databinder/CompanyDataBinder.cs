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
   
    public class CompanyDataBinder
    {

        private static Company GetCompanyFields(DataRowView drv)
        {
            return new Company
            {
                Id = long.Parse(UtilMethods.StripHTML(drv["Id"].ToString())),
                FirmId = long.Parse(UtilMethods.StripHTML(drv["FirmId"].ToString())),
                Name = UtilMethods.StripHTML(drv["Name"].ToString()),
                Address = UtilMethods.StripHTML(drv["Address"].ToString()),
                Email = UtilMethods.StripHTML(drv["Email"].ToString()),
                Phone = UtilMethods.StripHTML(drv["Phone"].ToString()),
                Location = UtilMethods.StripHTML(drv["Location"].ToString()),
                Status = (RecordStatusEnum)UtilMethods.ToEnum<RecordStatusEnum>(UtilMethods.StripHTML(drv["Status"].ToString())),
            };
        }

        public static Company ToCompany(DataView dv)
        {
            if (dv.Count > 0)
            {
                return GetCompanyFields(dv[0]);
            }

            return null;
        }

        public static List<Company> ToCompanyList(DataView dv)
        {
            List<Company> companies = new List<Company>();
            for (int i = 0; i < dv.Count; i++)
            {
                companies.Add(GetCompanyFields(dv[i]));
            }

            return companies;
        }
    }
}
