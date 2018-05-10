﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Model.Base;

namespace Xinerji.Dc.Internet.Model
{
    [Serializable]
    public class GetCompanyListRequest : AbstractRequest
    {
        public string Search { get; set; }
    }
}