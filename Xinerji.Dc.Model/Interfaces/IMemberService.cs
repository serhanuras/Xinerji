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

        Tuple<List<Member>, int> GetAll(long firmId, int selectedPageNumber, int numberOfItemsInPage);

        Tuple<List<Member>, int> Search(long firmId, int selectedPageNumber, int numberOfItemsInpage, string data);

        Member GetById(long Id);

        Member GetByLogonCrendetial(String email, String password);

        Member GetByTCIdentifier(String tCIdentifier);
    }
}
