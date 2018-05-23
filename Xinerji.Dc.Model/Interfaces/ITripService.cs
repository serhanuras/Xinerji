using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Model.Core;
using Xinerji.Dc.Model.Enumurations;
namespace Xinerji.Dc.Model.Interfaces
{
    public interface ITripService : IDisposable
    {

        Trip Insert(Trip trip);

        Trip Update(Trip trip);

        Trip ChangeStatus(long Id, RecordStatusEnum recordStatusEnum);

        Tuple<List<Trip>, int> GetAll(long firmId, int selectedPageNumber, int numberOfItemsInPage);

        Tuple<List<Trip>, int> Search(long firmId, int selectedPageNumber, int numberOfItemsInpage, string data);

        Trip GetById(long Id);
    }
}
