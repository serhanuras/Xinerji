using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Model.Core;
using Xinerji.Dc.Model.Enumurations;

namespace Xinerji.Dc.Model.Interfaces
{
    public interface ITruckStatusService : IDisposable
    {
        TruckStatus Insert(TruckStatus truckStatus);

        TruckStatus Update(TruckStatus truckStatus);

        TruckStatus ChangeStatus(long Id, RecordStatusEnum recordStatusEnum);

        List<TruckStatus> GetAll(long firmId);

        List<TruckStatus> Search(long firmId, string data);

    }
}
