using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Model.Base;
using Xinerji.Dc.Model.Enumurations;

namespace Xinerji.Dc.Model.Interfaces
{
    public interface ILoggingService : IDisposable
    {
        int LogChannelRequest(string url, string method, string returnCode, string request, string response, ChannelCodeEnum channelCode);

        int LogChannelRequest(AbstractRequest request, AbstractResponse response);

        int LogChannelRequest(AbstractRequest request, AbstractResponse response, Exception ex);

        int LogWindowServiceTick(string serviceName, string method, string serviceDescription, string result, Exception ex);
    }
}
