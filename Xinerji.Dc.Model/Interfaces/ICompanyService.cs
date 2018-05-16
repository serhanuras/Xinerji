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

        Tuple<List<Company>, int>  GetAll(long firmId, int selectedPageNumber, int numberOfItemsInPage);

        Tuple<List<Company>, int> Search(long firmId, int selectedPageNumber, int numberOfItemsInpage, string data);

        Company GetById(long Id);
    }
}
