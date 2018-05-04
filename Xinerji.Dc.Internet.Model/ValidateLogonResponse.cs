using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Model.Base;

namespace Xinerji.Dc.Internet.Model
{
    [Serializable]
    public class ValidateLogonResponse : AbstractResponse
    {

        public string PhoneNumber { get; set; }

        public string SessionNumber { get; set; }

        public string OtpId { get; set; }

    }
}
