using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Model.Core;
using Xinerji.Dc.Model.Enumurations;


namespace Xinerji.Dc.Model.Interfaces
{
    public interface IOrderMissingItemService
    {
        OrderMissingItem Insert(OrderMissingItem orderMissingItem);

        OrderMissingItem Update(OrderMissingItem orderMissingItem);

        OrderMissingItem Delete(long Id);

        List<OrderMissingItem> GetAll(long orderId);

        OrderMissingItem GetById(long Id);
    }
}
