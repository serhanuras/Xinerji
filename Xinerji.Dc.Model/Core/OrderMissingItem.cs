using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xinerji.Dc.Model.Core
{
    public class OrderMissingItem
    {
        public long Id { get; set; }

        public long OrderId { get; set; }

        public long OrderDetailId { get; set; }

        public int Quantity { get; set; }
    }
}
