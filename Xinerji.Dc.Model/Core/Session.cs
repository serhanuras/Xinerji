using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Model.Enumurations;

namespace Xinerji.Dc.Model.Core
{
    public class Session
    {
        public long Id { get; set; }

        public long CustomerId { get; set; }

        public SessionStatusEnum Status { get; set; }

        public ChannelCodeEnum ChannelCode { get; set; }

        public DateTime CreateDateTime { get; set; }

        public DateTime LastModifiedDateTime { get; set; }

        public String Token { get; set; }

    }
}
