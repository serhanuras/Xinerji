using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Model.Enumurations;

namespace Xinerji.Dc.Model.Core
{
    public class OneTimePassword
    {
        public long Id { get; set; }

        public long CustomerId { get; set; }

        public long SessionId { get; set; }

        public string MethodName { get; set; }

        public string OtpEncryptedString { get; set; }

        public OtpStatusEnum OtpStatusEnum { get; set; }

        public int OtpAttemptCount { get; set; }

        public int OtpRemaingAttemptCount { get; set; }

        public DateTime InsertDateTime { get; set; }

        public DateTime LastModifiedDateTime { get; set; }

        public bool IsEntryValid { get; set; }

        public bool IsMaximumAttempt { get; set; }


    }
}
