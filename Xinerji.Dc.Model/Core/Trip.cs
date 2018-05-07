using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Model.Enumurations;

namespace Xinerji.Dc.Model.Core
{
    public class Trip
    {
        public long Id { get; set; }

        public long FirmId { get; set; }

        public string Name { get; set; }

        public long TruckId { get; set; }

        public long ConsigneeId { get; set; }

        public RecordStatusEnum Status { get; set; }
    }
}
