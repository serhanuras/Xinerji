using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Model.Enumurations;

namespace Xinerji.Dc.Model.Core
{
    public class OrderDetail
    {
        public long Id { get; set; }

        public long FirmId { get; set; }

        public long OrderId { get; set; }

        public long ProductId { get; set; }

        public int Quantity { get; set; }

        public RecordStatusEnum Status { get; set; }
    }
}
