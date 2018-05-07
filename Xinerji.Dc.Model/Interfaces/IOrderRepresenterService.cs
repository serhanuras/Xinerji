using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Model.Core;
using Xinerji.Dc.Model.Enumurations;

namespace Xinerji.Dc.Model.Interfaces
{
    public interface IOrderRepresenterService
    {
        OrderRepresenter Insert(OrderRepresenter orderRepresenter);

        OrderRepresenter Update(OrderRepresenter orderRepresenter);

        OrderRepresenter Delete(long Id);

        List<OrderRepresenter> GetAll(long orderId);

        OrderRepresenter GetById(long Id);
    }
}
