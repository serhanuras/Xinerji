﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Model.Base;

namespace Xinerji.Dc.Internet.Model
{
    [Serializable]
    public class GetTripListRequest : AbstractRequest
    {
        public int SelectedPage { get; set; }

        public string Search { get; set; }
    }
}
