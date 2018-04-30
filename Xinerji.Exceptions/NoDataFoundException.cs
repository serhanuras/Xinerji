using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xinerji.Exceptions
{
    public class NoDataFoundException : Exception
    {
        public NoDataFoundException()
        : base() { }

        public NoDataFoundException(string message)
        : base(message) { }

        public NoDataFoundException(string format, params object[] args)
        : base(string.Format(format, args)) { }

        public NoDataFoundException(string message, Exception innerException)
        : base(message, innerException) { }

        public NoDataFoundException(string format, Exception innerException, params object[] args)
        : base(string.Format(format, args), innerException) { }
    }
}
