using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Model.Core;
using Xinerji.Dc.Model.Enumurations;

namespace Xinerji.Dc.Model.Interfaces
{
    public interface IChannelService : IDisposable
    {
        Channel GetChannel(ChannelCodeEnum channelCode);

        List<Channel> GetChannelList();
    }
}
