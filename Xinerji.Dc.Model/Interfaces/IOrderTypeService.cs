using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Model.Core;
using Xinerji.Dc.Model.Enumurations;

namespace Xinerji.Dc.Model.Interfaces
{
    public interface IOrderTypeService : IDisposable
    {
        OrderType Insert(OrderType orderType);

        OrderType Update(OrderType orderType);

        OrderType ChangeStatus(long Id, RecordStatusEnum recordStatusEnum);

        List<OrderType> GetAll(long firmId);

    }
}
