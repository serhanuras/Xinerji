using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Model.Base;

namespace Xinerji.Dc.Internet.Model
{
    [Serializable]
    public class ValidateMobileLogonResponse : AbstractResponse
    {

        public string SessionNumber { get; set; }

        public string Name { get; set; }

        public long TruckId { get; set; }

    }
}
