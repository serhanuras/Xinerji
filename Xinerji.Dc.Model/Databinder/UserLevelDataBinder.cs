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

    public class UserLevelDataBinder
    {
        private static UserLevel GetUserLevelField(DataRowView drv)
        {
            return new UserLevel
            {
                Id = long.Parse(UtilMethods.StripHTML(drv["Id"].ToString())),
                FirmId = long.Parse(UtilMethods.StripHTML(drv["FirmId"].ToString())),
                Name = UtilMethods.StripHTML(drv["Name"].ToString()),
                Status = (RecordStatusEnum)UtilMethods.ToEnum<RecordStatusEnum>(UtilMethods.StripHTML(drv["Status"].ToString())),
            };
        }

        public static UserLevel ToUserLevel(DataView dv)
        {
            if (dv.Count > 0)
            {
                return GetUserLevelField(dv[0]);
            }

            return null;
        }

        public static List<UserLevel> ToToUserLevelList(DataView dv)
        {
            List<UserLevel> userLevelList = new List<UserLevel>();
            for (int i = 0; i < dv.Count; i++)
            {
                userLevelList.Add(GetUserLevelField(dv[i]));
            }

            return userLevelList;
        }
    }
}
