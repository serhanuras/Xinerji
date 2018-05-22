﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Model.Base;
using Xinerji.Dc.Model.Core;

namespace Xinerji.Dc.Internet.Model
{
    [Serializable]
    public class GetOrderListResponse : AbstractResponse
    {
        public int PageSize { get; set; }

        public List<Order> OrderList { get; set; }
    }
}
