using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xinerji.Exceptions
{
    public class SessionNotFoundException : Exception
    {

        public SessionNotFoundException()
        : base() { }

        public SessionNotFoundException(string message)
        : base(message) { }

        public SessionNotFoundException(string format, params object[] args)
        : base(string.Format(format, args)) { }

        public SessionNotFoundException(string message, Exception innerException)
        : base(message, innerException) { }

        public SessionNotFoundException(string format, Exception innerException, params object[] args)
        : base(string.Format(format, args), innerException) { }
    }
}
