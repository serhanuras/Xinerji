﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xinerji.Dc.Model.Interfaces
{
    public interface IAuthenticationService: IDisposable
    {
        bool Test();
    }
}
