using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xinerji.Dc.Model.Base;
using Xinerji.Dc.Model.Enumurations;

namespace Xinerji.Dc.Web.Filters
{
    public class InternetActionFilter : ActionFilterAttribute
    {
        //Runs before execution of Action method.
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            AbstractRequest request = filterContext.ActionParameters["request"] as AbstractRequest;

            request.Token = filterContext.HttpContext.Request.Cookies["XinerjiToken"] != null ? filterContext.HttpContext.Request.Cookies["XinerjiToken"].Value : "";
            request.ChannelCode = ChannelCodeEnum.Internet;

            if (request.Url == null)
                request.Url = filterContext.HttpContext.Request.RawUrl;


            System.Threading.Thread.Sleep(200);
        }

        //Runs after execution of Action method.
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {

        }

    }
}