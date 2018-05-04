using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Model.Enumurations;

namespace Xinerji.Dc.Model.Core
{
    public class MemberType
    {
        public long Id { get; set; }

        public long FirmId { get; set; }

        public long UserLevelId { get; set; }

        public string Type { get; set; }

        public RecordStatusEnum Status { get; set; }
    }
}
