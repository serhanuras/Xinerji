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
    public static class ChannelDataBinder
    {

        private static Channel GetChannelFields(DataRowView drv)
        {
            return new Channel
            {
                ChannelCode = (ChannelCodeEnum)UtilMethods.ToEnum<ChannelCodeEnum>(UtilMethods.StripHTML(drv["Id"].ToString())),
                Code = UtilMethods.StripHTML(drv["Code"].ToString()),
                NameEng = UtilMethods.StripHTML(drv["NameEng"].ToString()),
                NameTr = UtilMethods.StripHTML(drv["NameTr"].ToString())
            };
        }

        public static Channel ToChannel(DataView dv)
        {
            if (dv.Count > 0)
            {
                return GetChannelFields(dv[0]);
            }

            return null;
        }

        public static List<Channel> ToChannelList(DataView dv)
        {
            List<Channel> transactions = new List<Channel>();
            for (int i = 0; i < dv.Count; i++)
            {
                transactions.Add(GetChannelFields(dv[i]));
            }

            return transactions;
        }
    }
}
