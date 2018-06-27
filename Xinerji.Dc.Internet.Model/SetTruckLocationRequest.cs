﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Model.Base;
using Xinerji.Dc.Model.Core;

namespace Xinerji.Dc.Internet.Model
{
    public class SetTruckLocationRequest : AbstractRequest
    {
        public long Id { get; set; }

        public string Latitude { get; set; }

        public string Longtitude { get; set; }
    }
}
