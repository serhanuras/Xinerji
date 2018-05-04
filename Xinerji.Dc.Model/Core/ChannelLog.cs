using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Model.Enumurations;

namespace Xinerji.Dc.Model.Core
{
    public class ChannelLog
    {
        public long Id { get; set; }

        public ChannelCodeEnum ChannelCode { get; set; }

        public long SessionId { get; set; }

        public bool IsOutgoingCall { get; set; }

        public string Url { get; set; }

        public string MethodName { get; set; }

        public int ReturnCode { get; set; }

        public string Request { get; set; }

        public string Response { get; set; }

        public string ExceptionStackTrace { get; set; }

        public DateTime InsertDateTime { get; set; }

    }
}
