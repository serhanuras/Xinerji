using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Model.Enumurations;

namespace Xinerji.Dc.Model.Core
{
    public class Branch
    {
        public long Id { get; set; }

        public long CompanyId { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Location { get; set; }

        public string Address { get; set; }

        public RecordStatusEnum Status { get; set; }
    }
}
