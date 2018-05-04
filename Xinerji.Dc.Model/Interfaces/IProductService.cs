using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Model.Core;
using Xinerji.Dc.Model.Enumurations;

namespace Xinerji.Dc.Model.Interfaces
{
    public interface IProductService : IDisposable
    {
        Product Insert(Product product);

        Product Update(Product product);

        Product ChangeStatus(long Id, RecordStatusEnum recordStatusEnum);

        List<Product> GetAll(long firmId);

        Product GetById(long Id);
    }
}
