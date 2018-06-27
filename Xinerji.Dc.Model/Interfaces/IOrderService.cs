using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Model.Core;
using Xinerji.Dc.Model.Enumurations;

namespace Xinerji.Dc.Model.Interfaces
{
    public interface IOrderService : IDisposable
    {
        Order Insert(Order order);

        Order Update(Order order);

        Order ChangeStatus(long Id, RecordStatusEnum recordStatusEnum);

        List<Order> GetAll(long tripId, string data);

        Tuple<List<Order>, int> GetAll(long firmId, int selectedPageNumber, int numberOfItemsInPage);

        Tuple<List<Order>, int> Search(long firmId, int selectedPageNumber, int numberOfItemsInpage, string data);

        Order BindOrderToTrip(long orderId, long tripId);

        Order ChangeDeliveryStatus(long orderId, long deliveryStatusId);

        Order ChangeDeliverySubStatus(long orderId, long deliverySubStatusId);

        Order GetById(long Id);
    }
}
