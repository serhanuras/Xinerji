using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Model.Enumurations;

namespace Xinerji.Dc.Model.Core
{
    public class OrderType
    {
        public long Id { get; set; }

        public long FirmId { get; set; }

        public string Name { get; set; }

        public RecordStatusEnum Status { get; set; }
    }
}
