using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Model.Enumurations;

namespace Xinerji.Dc.Model.Core
{
    public class Channel
    {

        public ChannelCodeEnum ChannelCode { get; set; }

        public string Code { get; set; }

        public string NameTr { get; set; }

        public string NameEng { get; set; }
    }
}
