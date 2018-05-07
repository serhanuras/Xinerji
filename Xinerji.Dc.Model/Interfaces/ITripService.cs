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

        List<Trip> GetAll(long firmId);

        Trip GetById(long Id);
    }
}
