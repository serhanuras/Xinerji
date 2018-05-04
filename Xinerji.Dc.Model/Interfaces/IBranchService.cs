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

        List<Branch> GetAll(long companyId);

        Branch GetById(long Id);
    }
}
