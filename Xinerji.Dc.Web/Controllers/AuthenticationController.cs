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
    public class AuthenticationController : Controller
    {
        AuthenticationService authenticationService;

        public AuthenticationController()
        {
            authenticationService = new AuthenticationService();
        }

        [HttpPost]
        [InternetActionFilter]
        [ValidateInput(true)]
        public ActionResult ValidateLogon(ValidateLogonRequest request)
        {

            request.ChannelCode = ChannelCodeEnum.Internet;

            ValidateLogonResponse response = this.authenticationService.ValidateLogon(request);

            if (Request.Cookies["XinerjiToken"] != null)
            {
                Response.Cookies["XinerjiToken"].Expires = DateTime.Now.AddDays(-1);

            }

            if (response.Header.Error.ErrorCode == 0)
            {
                HttpCookie cookie = new HttpCookie("XinerjiToken");
                cookie.Value = response.SessionNumber;
                cookie.Expires = DateTime.Now.AddDays(1);
                //cookie.Secure = true;

                this.ControllerContext.HttpContext.Response.Cookies.Add(cookie);
            }


            return Json(response);

        }


        [HttpGet]
        [InternetActionFilter]
        [ValidateInput(true)]
        public ActionResult TerminateSession(TerminateSessionRequest request)
        {
            TerminateSessionResponse response = this.authenticationService.TerminateSession(request);

            if (Request.Cookies["XinerjiToken"] != null)
            {
                Response.Cookies["XinerjiToken"].Expires = DateTime.Now.AddDays(-1);
            }

            return Json(response, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        [InternetActionFilter]
        [ValidateInput(true)]
        public ActionResult ChangeLanguage(ChangeLanguageRequest request)
        {

            request.ChannelCode = ChannelCodeEnum.Internet;

            ChangeLanguageResponse response = this.authenticationService.ChangeLanguage(request);

            HttpCookie cookie = new HttpCookie("XinerjiToken");
            cookie.Value = response.SessionNumber;
            cookie.Expires = DateTime.Now.AddDays(1);

            this.ControllerContext.HttpContext.Response.Cookies.Add(cookie);

            return Json(response);

        }

    }
}