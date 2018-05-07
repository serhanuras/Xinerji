using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Model.Core;
using Xinerji.Dc.Model.Enumurations;

namespace Xinerji.Dc.Model.Interfaces
{
    public interface IOrderDocumentService : IDisposable
    {
        OrderDocument Insert(OrderDocument OrderDocument);

        OrderDocument Update(OrderDocument OrderDocument);

        OrderDocument Delete(long Id);

        List<OrderDocument> GetAll(long orderId);

        OrderDocument GetById(long Id);
    }
}
