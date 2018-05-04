using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Model.Core;
using Xinerji.Dc.Model.Enumurations;

namespace Xinerji.Dc.Model.Interfaces
{
    public interface IMemberTypeService : IDisposable
    {
        MemberType Insert(MemberType memberType);

        MemberType Update(MemberType memberType);

        MemberType ChangeStatus(long Id, RecordStatusEnum recordStatusEnum);

        List<MemberType> GetAll(long firmId);

        MemberType GetById(long Id);
    }
}
