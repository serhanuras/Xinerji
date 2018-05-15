using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Model.Core;
using Xinerji.Dc.Model.Enumurations;

namespace Xinerji.Dc.Model.Interfaces
{
    public interface IBranchService : IDisposable
    {

        Branch Insert(Branch branch);

        Branch Update(Branch branch);

        Branch ChangeStatus(long Id, RecordStatusEnum recordStatusEnum);

        Tuple<List<Branch>, int> GetAll(long companyId, int selectedPageNumber, int numberOfItemsInPage);

        Branch GetById(long Id);

        Tuple<List<Branch>, int> Search(long companyId, int selectedPageNumber, int numberOfItemsInPage, string data);
    }
}
