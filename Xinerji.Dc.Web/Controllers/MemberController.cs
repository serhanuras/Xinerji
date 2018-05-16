using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xinerji.Dc.Internet.Model;
using Xinerji.Dc.Internet.Services;
using Xinerji.Dc.Model.Enumurations;
using Xinerji.Dc.Web.Filters;

namespace Xinerji.Dc.Web.Controllers
{
    public class MemberController : Controller
    {
        MemberService memberService;

        public MemberController()
        {
            memberService = new MemberService();
        }

        [HttpPost]
        [InternetActionFilter]
        [ValidateInput(true)]
        public ActionResult GetMemberList(GetMemberListRequest request)
        {
            return Json(this.memberService.GetMemberList(request));
        }


        [HttpPost]
        [InternetActionFilter]
        [ValidateInput(true)]
        public ActionResult InsertMember(InsertMemberRequest request)
        {
            return Json(this.memberService.InsertMember(request));

        }

        [HttpPost]
        [InternetActionFilter]
        [ValidateInput(true)]
        public ActionResult DeleteMember(DeleteMemberRequest request)
        {
            return Json(this.memberService.DeleteMember(request));
        }


        [HttpPost]
        [InternetActionFilter]
        [ValidateInput(true)]
        public ActionResult EditMember(EditMemberRequest request)
        {
            return Json(this.memberService.EditMember(request));
        }

        
    }
}