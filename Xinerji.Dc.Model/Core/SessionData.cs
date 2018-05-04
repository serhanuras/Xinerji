using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xinerji.Dc.Model.Core
{
    public class SessionData
    {
        public long Id { get; set; }

        public long SessionId { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }

        public DateTime InsertDateTime { get; set; }
    }
}
