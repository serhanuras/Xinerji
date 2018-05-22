using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Model.Core;
using Xinerji.Dc.Model.Enumurations;


namespace Xinerji.Dc.Model.Interfaces
{
    public interface IOrderDetailService : IDisposable
    {
        OrderDetail Insert(OrderDetail orderDetail);

        OrderDetail Update(OrderDetail orderDetail);

        OrderDetail ChangeStatus(long Id, RecordStatusEnum recordStatusEnum);

        List<OrderDetail> GetAll(long orderId, long firmId);

        OrderDetail GetById(long Id);
    }
}
