using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Model.Enumurations;

namespace Xinerji.Dc.Model.Core
{
    public class Error
    {
        public long Id { get; set; }

        public ChannelCodeEnum ChannelCode { get; set; }

        public int ErrorCode { get; set; }

        public string ErrorDescriptionTR { get; set; }

        public string ErrorDescriptionENG { get; set; }

        public DateTime DateLastModified { get; set; }
    }
}
