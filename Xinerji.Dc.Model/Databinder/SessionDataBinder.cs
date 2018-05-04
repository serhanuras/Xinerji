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
    public static class SessionDataBinder
    {

        private static Session GetSessionFields(DataRowView drv)
        {
            return new Session
            {
                Id = long.Parse(UtilMethods.StripHTML(drv["ID"].ToString())),
                ChannelCode = (ChannelCodeEnum)UtilMethods.ToEnum<ChannelCodeEnum>(UtilMethods.StripHTML(drv["ChannelCode"].ToString())),
                CustomerId = long.Parse(UtilMethods.StripHTML(drv["CustomerId"].ToString())),
                Status = (SessionStatusEnum)UtilMethods.ToEnum<SessionStatusEnum>(UtilMethods.StripHTML(drv["Status"].ToString())),
                CreateDateTime = UtilMethods.ConvertSqlToDateTime(UtilMethods.StripHTML(drv["CreateDateTime"].ToString())),
                LastModifiedDateTime = UtilMethods.ConvertSqlToDateTime(UtilMethods.StripHTML(drv["LastModifiedDateTime"].ToString()))
            };
        }

        public static Session ToSession(DataView dv)
        {
            if (dv.Count > 0)
            {
                return GetSessionFields(dv[0]);
            }

            return null;
        }
    }
}
