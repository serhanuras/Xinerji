using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Model.Enumurations;

namespace Xinerji.Dc.Model.Core
{
    public class Messaging
    {
        public long Id { get; set; }

        public MessagingTemplateEnum Template { get; set; }

        public MessagingTypeEnum Type { get; set; }

        public string ReceiverAddress { get; set; }

        public string Subject { get; set; }

        public string Content { get; set; }

        public MessagingStatusEnum Status { get; set; }

        public bool IsEncrypted { get; set; }

        public int RetryCount { get; set; }

        public int AttemptCount { get; set; }

        public MessagingPriorityEnum Priority { get; set; }

        public DateTime InsertDateTime { get; set; }

        public DateTime LastModifiedDateTime { get; set; }

        public string[] Parameters;

        public LanguageEnum Language;

    }
}
