using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Model.Core;

namespace Xinerji.Dc.Model.Interfaces
{
    public interface IErrorCodeService : IDisposable
    {
        Error FindDescriptionByErrorCode(Error errorDescription);

        Error FindDescriptionById(long id);

        Error FindDescriptionByException(Exception ex);
    }
}
