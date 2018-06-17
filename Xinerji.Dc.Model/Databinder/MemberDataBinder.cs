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
    public static class MemberDataBinder
    {
        private static Member GetMemberField(DataRowView drv)
        {
            return new Member
            {
                Id = long.Parse(UtilMethods.StripHTML(drv["Id"].ToString())),
                FirmId = long.Parse(UtilMethods.StripHTML(drv["FirmId"].ToString())),
                TCIdentifier = UtilMethods.StripHTML(drv["TCIdentifier"].ToString()),
                Type = UtilMethods.StripHTML(drv["Type"].ToString()),
                Name = UtilMethods.StripHTML(drv["Name"].ToString()),
                MiddleName = UtilMethods.StripHTML(drv["MiddleName"].ToString()),
                Surname = UtilMethods.StripHTML(drv["Surname"].ToString()),
                Birthdate = UtilMethods.ConvertSqlToDateTime(UtilMethods.StripHTML(drv["Birthdate"].ToString())),
                Email = UtilMethods.StripHTML(drv["Email"].ToString()),
                CompanyId = long.Parse(UtilMethods.StripHTML(drv["CompanyId"].ToString())),
                Password = UtilMethods.StripHTML(drv["Password"].ToString()),
                Phone = UtilMethods.StripHTML(drv["Phone"].ToString()),
                MemberTypeId = long.Parse(UtilMethods.StripHTML(drv["MemberTypeId"].ToString())),
                Status = (RecordStatusEnum)UtilMethods.ToEnum<RecordStatusEnum>(UtilMethods.StripHTML(drv["Status"].ToString())),
            };
        }

        public static Member ToMember(DataView dv)
        {
            if (dv.Count > 0)
            {
                return GetMemberField(dv[0]);
            }

            return null;
        }

        public static List<Member> ToMemberList(DataView dv)
        {
            List<Member> branchList = new List<Member>();
            for (int i = 0; i < dv.Count; i++)
            {
                branchList.Add(GetMemberField(dv[i]));
            }

            return branchList;
        }

    }
}
