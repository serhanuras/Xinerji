using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xinerji.Dc.Model.Core
{
    public class OrderRepresenter
    {
        public long Id { get; set; }

        public long OrderId { get; set; }

        public long RepresenterId { get; set; }

        public int Level { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Type { get; set; }

    }
}
