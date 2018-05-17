using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Internet.Model;
using Xinerji.Dc.Internet.Services.Filter;
using Xinerji.Dc.Model.Core;
using Xinerji.Dc.Model.Interfaces;
using Xinerji.Dc.Services;

namespace Xinerji.Dc.Internet.Services
{
    public class MemberService
    {
        private static int numberOfItemsInPage = 1;

        #region Local Variables
        private const int MAX_ATTEMPT_COUNT = 5;
        ISessionService sessionService;
        IMemberService memberService;
        #endregion

        public MemberService()
        {
            sessionService = new SessionServiceImp();
            memberService = new MemberServiceImp();
        }

        #region GetMemberList
        [BOServiceFilter]
        public GetMemberListResponse GetMemberList(GetMemberListRequest request)
        {
            GetMemberListResponse response;

            if (request.SelectedPage != -1)
            {
                if (request.Search == "")
                {
                    var result = memberService.GetAll(request.Session.FirmId, request.SelectedPage, numberOfItemsInPage);

                    response = new GetMemberListResponse
                    {
                        MemberList = result.Item1,
                        PageSize = result.Item2
                    };
                }
                else
                {
                    var result = memberService.Search(request.Session.FirmId, request.SelectedPage, numberOfItemsInPage, request.Search);

                    response = new GetMemberListResponse
                    {
                        MemberList = result.Item1,
                        PageSize = result.Item2
                    };
                }
            }
            else
            {
                var result = memberService.GetAll(request.Session.FirmId);

                response = new GetMemberListResponse
                {
                    MemberList = result,
                    PageSize = 0
                };
            }

            return response;
        }
        #endregion


        #region InsertMember
        [BOServiceFilter]
        public InsertMemberResponse InsertMember(InsertMemberRequest request)
        {
            request.Member.FirmId = request.Session.FirmId;
            request.Member.Status = Dc.Model.Enumurations.RecordStatusEnum.Active;

            InsertMemberResponse response;
            memberService.Insert(request.Member);

            response = new InsertMemberResponse
            {
            };

            return response;
        }
        #endregion

        #region DeleteMember
        [BOServiceFilter]
        public DeleteMemberResponse DeleteMember(DeleteMemberRequest request)
        {
            DeleteMemberResponse response;
            memberService.ChangeStatus(request.Id, Dc.Model.Enumurations.RecordStatusEnum.Removed);

            response = new DeleteMemberResponse
            {

            };

            return response;
        }
        #endregion


        #region EditMember
        [BOServiceFilter]
        public EditMemberResponse EditMember(EditMemberRequest request)
        {
            request.Member.FirmId = request.Session.FirmId;
            request.Member.Status = Dc.Model.Enumurations.RecordStatusEnum.Active;

            EditMemberResponse response;
            memberService.Update(request.Member);

            response = new EditMemberResponse
            {
            };

            return response;
        }
        #endregion
    }
}
