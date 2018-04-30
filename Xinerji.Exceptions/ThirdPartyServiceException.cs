using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xinerji.Exceptions
{
    public class ThirdPartyServiceException : Exception
    {
        public ThirdPartyServiceException()
        : base() { }

        public ThirdPartyServiceException(string message)
        : base(message) { }

        public ThirdPartyServiceException(string format, params object[] args)
        : base(string.Format(format, args)) { }

        public ThirdPartyServiceException(string message, Exception innerException)
        : base(message, innerException) { }

        public ThirdPartyServiceException(string format, Exception innerException, params object[] args)
        : base(string.Format(format, args), innerException) { }
    }
}
