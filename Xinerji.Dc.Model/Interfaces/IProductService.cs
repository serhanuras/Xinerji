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

        Product GetById(long Id);

        Product SearchProductByBarcode(long firmId, string barcode);

        List<Product> GetAll(long firmId);

        Tuple<List<Product>, int> GetAll(long firmId, int selectedPageNumber, int numberOfItemsInPage);

        Tuple<List<Product>, int> Search(long firmId, int selectedPageNumber, int numberOfItemsInpage, string data);
    }
}
