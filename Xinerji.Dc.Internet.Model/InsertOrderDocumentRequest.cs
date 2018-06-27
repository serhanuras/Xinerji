using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Model.Base;
using Xinerji.Dc.Model.Core;

namespace Xinerji.Dc.Internet.Model
{
    public class InsertOrderDocumentRequest : AbstractRequest
    {
        public long OrderId { get; set; }

        public string FileBase64 { get; set; }
    }
}
