using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Model.Base;
using Xinerji.Dc.Model.Core;

namespace Xinerji.Dc.Internet.Model
{
    [Serializable]
    public class GetTripByTruckIdResponse : AbstractResponse
    {
        public Trip Trip { get; set; }

        public List<Order> OrderList { get; set;}
    }
}
