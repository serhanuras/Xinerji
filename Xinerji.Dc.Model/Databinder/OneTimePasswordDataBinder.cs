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
    public static class OneTimePasswordDataBinder
    {
        private static OneTimePassword GetOneTimePasswordField(DataRowView drv)
        {
            return new OneTimePassword
            {
                Id = long.Parse(UtilMethods.StripHTML(drv["Id"].ToString())),
                CustomerId = long.Parse(UtilMethods.StripHTML(drv["CustomerId"].ToString())),
                SessionId = long.Parse(UtilMethods.StripHTML(drv["SessionId"].ToString())),
                MethodName = UtilMethods.StripHTML(drv["MethodName"].ToString()),
                OtpEncryptedString = UtilMethods.StripHTML(drv["OtpEncryptedString"].ToString()),
                OtpStatusEnum = (OtpStatusEnum)UtilMethods.ToEnum<OtpStatusEnum>(UtilMethods.StripHTML(drv["OtpStatus"].ToString())),
                OtpAttemptCount = int.Parse(UtilMethods.StripHTML(drv["OtpAttemptCount"].ToString())),
                OtpRemaingAttemptCount = int.Parse(UtilMethods.StripHTML(drv["OtpRemaingAttemptCount"].ToString())),
                InsertDateTime = UtilMethods.ConvertSqlToDateTime(UtilMethods.StripHTML(drv["InsertDateTime"].ToString())),
                LastModifiedDateTime = UtilMethods.ConvertSqlToDateTime(UtilMethods.StripHTML(drv["LastModifiedDateTime"].ToString()))

            };
        }


        public static OneTimePassword ToOneTimePassword(DataView dv)
        {
            if (dv.Count > 0)
            {
                return GetOneTimePasswordField(dv[0]);
            }

            return null;
        }


        public static List<OneTimePassword> ToOneTimePasswordList(DataView dv)
        {
            List<OneTimePassword> accounts = new List<OneTimePassword>();
            for (int i = 0; i < dv.Count; i++)
            {
                accounts.Add(GetOneTimePasswordField(dv[i]));
            }

            return accounts;
        }
    }
}
