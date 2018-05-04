using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xinerji.Exceptions
{
    public class MessagingTemplateNofFoundException : Exception
    {
        public MessagingTemplateNofFoundException()
        : base() { }

        public MessagingTemplateNofFoundException(string message)
        : base(message) { }

        public MessagingTemplateNofFoundException(string format, params object[] args)
        : base(string.Format(format, args)) { }

        public MessagingTemplateNofFoundException(string message, Exception innerException)
        : base(message, innerException) { }

        public MessagingTemplateNofFoundException(string format, Exception innerException, params object[] args)
        : base(string.Format(format, args), innerException) { }

    }
}
