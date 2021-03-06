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
    public class GetProductListResponse : AbstractResponse
    {
        public int PageSize { get; set; }

        public List<Product> ProductList { get; set; }
    }
}
