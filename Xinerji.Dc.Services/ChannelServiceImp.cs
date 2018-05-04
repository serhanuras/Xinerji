using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Model.Core;
using Xinerji.Dc.Model.Databinder;
using Xinerji.Dc.Model.Enumurations;
using Xinerji.Dc.Model.Interfaces;
using Xinerji.Integration;

namespace Xinerji.Dc.Services
{
    public class ChannelServiceImp : IChannelService
    {
        #region Local Variables
        SPExecutor spExecutor;
        private static List<Channel> channelList = null;
        #endregion

        #region Constructor
        public ChannelServiceImp()
        {

        }
        #endregion

        #region Methods
        #region GetChannel
        public Channel GetChannel(ChannelCodeEnum channelCode)
        {
            return GetChannelList().Where(e => e.ChannelCode == channelCode).ToList()[0];
        }
        #endregion

        #region GetChannelList
        public List<Channel> GetChannelList()
        {
            using (spExecutor = new SPExecutor())
            {
                if (channelList == null)
                {
                    DataView dv = spExecutor.ExecSProcDV("usp_getChannelList",
                        new object[] { });

                    channelList = ChannelDataBinder.ToChannelList(dv);
                }

                return channelList;
            }
        }
        #endregion

        #region Dispose
        public void Dispose()
        {

        }
        #endregion
        #endregion
    }
}
