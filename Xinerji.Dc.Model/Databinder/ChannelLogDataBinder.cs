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
    public static class ChannelLogDataBinder
    {

        private static ChannelLog GetChannelLogFields(DataRowView drv)
        {
            return new ChannelLog
            {
                Id = long.Parse(UtilMethods.StripHTML(drv["Id"].ToString())),
                ChannelCode = (ChannelCodeEnum)UtilMethods.ToEnum<ChannelCodeEnum>(UtilMethods.StripHTML(drv["ChannelCode"].ToString())),
                SessionId = long.Parse(UtilMethods.StripHTML(drv["SessionId"].ToString())),
                IsOutgoingCall = UtilMethods.StripHTML(drv["IsOutgoingCall"].ToString()) == "0" ? false : true,
                Url = UtilMethods.StripHTML(drv["Url"].ToString()),
                MethodName = UtilMethods.StripHTML(drv["MethodName"].ToString()),
                ReturnCode = int.Parse(UtilMethods.StripHTML(drv["ReturnCode"].ToString())),
                Request = UtilMethods.StripHTML(drv["Request"].ToString()),
                Response = UtilMethods.StripHTML(drv["Response"].ToString()),
                InsertDateTime = UtilMethods.ConvertSqlToDateTime(UtilMethods.StripHTML(drv["InsertDateTime"].ToString())),
                ExceptionStackTrace = UtilMethods.StripHTML(drv["ExceptionStackTrace"].ToString())

            };
        }


        public static ChannelLog ToChannelLog(DataView dv)
        {
            if (dv.Count > 0)
            {
                return GetChannelLogFields(dv[0]);
            }

            return null;
        }

        public static List<ChannelLog> ToChannelLogList(DataView dv)
        {
            List<ChannelLog> channelLogList = new List<ChannelLog>();
            for (int i = 0; i < dv.Count; i++)
            {
                channelLogList.Add(GetChannelLogFields(dv[i]));
            }

            return channelLogList;
        }
    }

}
