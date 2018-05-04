using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Model.Core;
using Xinerji.Dc.Model.Enumurations;

namespace Xinerji.Dc.Model.Interfaces
{
    public interface ICompanyService: IDisposable
    {
        Company Insert(Company company);

        Company Update(Company company);

        Company ChangeStatus(long Id, RecordStatusEnum recordStatusEnum );

        List<Company> GetAll(long firmId);

    }
}
