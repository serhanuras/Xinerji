using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Model.Enumurations;


namespace Xinerji.Dc.Model.Core
{
    public class OrderDocument
    {
        public long Id { get; set; }

        public long OrderId { get; set; }

        public long DocumentTypeId { get; set; }

        public string FileName { get; set; }

        public string FileExtension { get; set; }

        public string FileBinary { get; set; }

    }
}
