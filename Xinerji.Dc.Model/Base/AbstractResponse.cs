using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xinerji.Dc.Model.Base
{
    [Serializable]
    public abstract class AbstractResponse
    {
        public ResponseHeader Header { get; set; }


    }
}
