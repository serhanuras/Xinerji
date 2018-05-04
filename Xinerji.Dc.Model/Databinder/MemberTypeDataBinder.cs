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
    public class MemberTypeDataBinder
    {
        private static MemberType GetMemberTypeField(DataRowView drv)
        {
            return new MemberType
            {
                Id = long.Parse(UtilMethods.StripHTML(drv["Id"].ToString())),
                FirmId = long.Parse(UtilMethods.StripHTML(drv["FirmId"].ToString())),
                UserLevelId = long.Parse(UtilMethods.StripHTML(drv["UserLevelId"].ToString())),
                Type = UtilMethods.StripHTML(drv["Type"].ToString()),
                Status = (RecordStatusEnum)UtilMethods.ToEnum<RecordStatusEnum>(UtilMethods.StripHTML(drv["Status"].ToString())),
            };
        }

        public static MemberType ToMemberType(DataView dv)
        {
            if (dv.Count > 0)
            {
                return GetMemberTypeField(dv[0]);
            }

            return null;
        }

        public static List<MemberType> ToMemberTypeList(DataView dv)
        {
            List<MemberType> memberTypeList = new List<MemberType>();
            for (int i = 0; i < dv.Count; i++)
            {
                memberTypeList.Add(GetMemberTypeField(dv[i]));
            }

            return memberTypeList;
        }
    }
}
