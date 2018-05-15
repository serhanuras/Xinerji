using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Model.Core;
using Xinerji.Dc.Model.Enumurations;

namespace Xinerji.Dc.Model.Interfaces
{
    public interface IDeliveryStatusService : IDisposable
    {
        DeliveryStatus Insert(DeliveryStatus deliveryStatus);

        DeliveryStatus Update(DeliveryStatus deliveryStatus);

        DeliveryStatus ChangeStatus(long Id, RecordStatusEnum recordStatusEnum);

        List<DeliveryStatus> GetAll(long firmId);

        List<DeliveryStatus> Search(long firmId, string data);
    }
}
