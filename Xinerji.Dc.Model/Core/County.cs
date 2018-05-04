using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xinerji.Dc.Model.Core
{
    public class County
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CityId { get; set; }
    }
}
