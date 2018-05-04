using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Model.Core;
using Xinerji.Dc.Model.Enumurations;

namespace Xinerji.Dc.Model.Interfaces
{
    public interface IMessagingService : IDisposable
    {
        bool Insert(Messaging messaging);

        MessagingTemplate GetMessagingTemplate(MessagingTemplateEnum messagingTemplate);

        MessagingPriorityEnum GetMessagingPriority(MessagingTemplateEnum messagingTemplate);

        List<Messaging> FindMessagingByStatus(MessagingStatusEnum messagingStatus, int itemCount);

        int GetRetryCount(MessagingPriorityEnum messagingType);

        bool SendMessage(List<Messaging> messagingList);

        bool SendSms(Messaging messaging);

        bool SendOtp(Messaging messaging);

        bool SendEmail(Messaging messaging);

        bool UpdateMessagingAttemptCount(Messaging messaging);

        void UpdateMessagingStatusAndResend(Messaging messaging);

        List<Messaging> GetMessagingByReceiver(int topCount, string receiverEmail, string receiverCellPhone);
    }
}
