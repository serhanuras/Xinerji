using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Model.Core;
using Xinerji.Dc.Model.Enumurations;

namespace Xinerji.Dc.Model.Interfaces
{
    public interface IUserLevelService : IDisposable
    {
        UserLevel Insert(UserLevel userLevel);

        UserLevel Update(UserLevel userLevel);

        UserLevel ChangeStatus(long Id, RecordStatusEnum recordStatusEnum);

        List<UserLevel> GetAll(long firmId);

    }
}
