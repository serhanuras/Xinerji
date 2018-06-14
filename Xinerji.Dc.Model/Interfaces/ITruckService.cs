using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Model.Core;
using Xinerji.Dc.Model.Enumurations;

namespace Xinerji.Dc.Model.Interfaces
{
    public interface ITruckService : IDisposable
    {
        Truck Insert(Truck product);

        Truck Update(Truck product);

        Truck ChangeStatus(long Id, RecordStatusEnum recordStatusEnum);

        List<Truck> GetAll(long firmId);

        Tuple<List<Truck>, int> GetAll(long firmId, int selectedPageNumber, int numberOfItemsInPage);

        Tuple<List<Truck>, int> Search(long firmId, int selectedPageNumber, int numberOfItemsInpage, string data);

        Truck GetById(long Id);

        Truck GetByPlaque(string plaque);
    }
}
