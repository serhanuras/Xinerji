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
    public static class ErrorDataBinder
    {

        private static Error GetErrorDescription(DataRowView drv)
        {
            return new Error
            {
                Id = int.Parse(UtilMethods.StripHTML(drv["ID"].ToString())),
                ChannelCode = (ChannelCodeEnum)UtilMethods.ToEnum<ChannelCodeEnum>(UtilMethods.StripHTML(drv["ChannelCode"].ToString())),
                ErrorCode = int.Parse(UtilMethods.StripHTML(drv["ErrorCode"].ToString())),
                ErrorDescriptionTR = UtilMethods.StripHTML(drv["ErrorDescriptionTR"].ToString()),
                ErrorDescriptionENG = UtilMethods.StripHTML(drv["ErrorDescriptionENG"].ToString()),
                DateLastModified = UtilMethods.ConvertSqlToDateTime(UtilMethods.StripHTML(drv["DateLastModified"].ToString()))

            };
        }

        public static Error ToErrorDescription(DataView dv)
        {
            if (dv.Count > 0)
            {
                return GetErrorDescription(dv[0]);
            }

            return null;
        }
    }
}
