using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Model.Core;
using Xinerji.Dc.Model.Enumurations;


namespace Xinerji.Dc.Model.Interfaces
{

    public interface IMemberService : IDisposable
    {
        Member Insert(Member member);

        Member Update(Member member);

        Member UpdatePassword(Member member);

        Member ChangeStatus(long Id, RecordStatusEnum recordStatusEnum);

        List<Member> GetAll(long firmId);

        Member GetById(long Id);
    }
}
