using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Model.Enumurations;

namespace Xinerji.Dc.Model.Core
{
    public class Truck
    {
        public long Id { get; set; }

        public long FirmId { get; set; }

        public long MemberId { get; set; }

        public string LicenceNo { get; set; }

        public int Capacity { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public string Plaque { get; set; }

        public RecordStatusEnum Status { get; set; }
    }
}
