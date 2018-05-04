using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Model.Enumurations;

namespace Xinerji.Dc.Model.Core
{
    public class Product
    {
        public long Id { get; set; }

        public long FirmId { get; set; }

        public string Name { get; set; }

        public string Barcode { get; set; }

        public int Weight { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }

        public int Volume { get; set; }

        public RecordStatusEnum Status { get; set; }
    }
}
