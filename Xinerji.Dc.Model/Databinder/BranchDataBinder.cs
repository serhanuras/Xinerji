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
    public class BranchDataBinder
    {
        private static Branch GetBranchField(DataRowView drv)
        {
            return new Branch
            {
                Id = long.Parse(UtilMethods.StripHTML(drv["Id"].ToString())),
                FirmId = long.Parse(UtilMethods.StripHTML(drv["FirmId"].ToString())),
                CompanyId = long.Parse(UtilMethods.StripHTML(drv["CompanyId"].ToString())),
                CompanyName = UtilMethods.StripHTML(drv["CompanyName"].ToString()),
                Name = UtilMethods.StripHTML(drv["Name"].ToString()),
                Phone = UtilMethods.StripHTML(drv["Phone"].ToString()),
                Email = UtilMethods.StripHTML(drv["Email"].ToString()),
                Location = UtilMethods.StripHTML(drv["Location"].ToString()),
                Address = UtilMethods.StripHTML(drv["Address"].ToString()),
                Status = (RecordStatusEnum)UtilMethods.ToEnum<RecordStatusEnum>(UtilMethods.StripHTML(drv["Status"].ToString())),
            };
        }

        public static Branch ToBranch(DataView dv)
        {
            if (dv.Count > 0)
            {
                return GetBranchField(dv[0]);
            }

            return null;
        }

        public static List<Branch> ToBranchList(DataView dv)
        {
            List<Branch> branchList = new List<Branch>();
            for (int i = 0; i < dv.Count; i++)
            {
                branchList.Add(GetBranchField(dv[i]));
            }

            return branchList;
        }
    }
}
