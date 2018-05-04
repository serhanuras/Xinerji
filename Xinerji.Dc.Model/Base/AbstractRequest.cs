using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Model.Core;
using Xinerji.Dc.Model.Enumurations;

namespace Xinerji.Dc.Model.Base
{
    [Serializable]
    public abstract class AbstractRequest
    {
        [Required]
        [StringLength(500, MinimumLength = 2)]
        public string Token { get; set; }

        public ChannelCodeEnum ChannelCode { get; set; }

        public string MethodName { get; set; }

        public string Url { get; set; }

        public Session Session { get; set; }

    }
}
