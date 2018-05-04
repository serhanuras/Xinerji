using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Model.Enumurations;

namespace Xinerji.Dc.Model.Core
{
    public class MessagingTemplate
    {
        public long Id { get; set; }

        public MessagingTypeEnum Type { get; set; }

        public string SubjectTr { get; set; }

        public string ContentTr { get; set; }

        public string SubjectEng { get; set; }

        public string ContentEng { get; set; }

        public DateTime InsertDateTime { get; set; }

        public DateTime LastModifiedDateTime { get; set; }

    }
}
