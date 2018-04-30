using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xinerji.Exceptions
{
    public class ValueNotUpdatedException : Exception
    {
        public ValueNotUpdatedException()
        : base() { }

        public ValueNotUpdatedException(string message)
        : base(message) { }

        public ValueNotUpdatedException(string format, params object[] args)
        : base(string.Format(format, args)) { }

        public ValueNotUpdatedException(string message, Exception innerException)
        : base(message, innerException) { }

        public ValueNotUpdatedException(string format, Exception innerException, params object[] args)
        : base(string.Format(format, args), innerException) { }
    }
}
