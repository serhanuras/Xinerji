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
    public static class SessionDataDataBinder
    {

        private static SessionData GetSessionDataFields(DataRowView drv)
        {
            return new SessionData
            {
                Id = long.Parse(UtilMethods.StripHTML(drv["ID"].ToString())),
                SessionId = long.Parse(UtilMethods.StripHTML(drv["ID"].ToString())),
                Key = UtilMethods.StripHTML(drv["Key"].ToString()),
                Value = drv["Value"].ToString(),
                InsertDateTime = UtilMethods.ConvertSqlToDateTime(UtilMethods.StripHTML(drv["InsertDateTime"].ToString())),
            };
        }

        public static SessionData ToSessionData(DataView dv)
        {
            if (dv.Count > 0)
            {
                return GetSessionDataFields(dv[0]);
            }

            return null;
        }

        public static List<SessionData> ToSessionDataList(DataView dv)
        {
            List<SessionData> sessionDataList = new List<SessionData>();

            for (int i = 0; i < dv.Count; i++)
            {
                sessionDataList.Add(GetSessionDataFields(dv[i]));
            }

            return sessionDataList;
        }
    }
}
