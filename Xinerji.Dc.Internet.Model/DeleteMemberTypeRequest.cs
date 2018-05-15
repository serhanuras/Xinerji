using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Model.Base;

namespace Xinerji.Dc.Internet.Model
{
    public class DeleteMemberTypeRequest : AbstractRequest
    {
        public long Id { get; set; }
    }
}
