using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsurancePortal.Web.Common
{
    public class IsLogined : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext ctx = HttpContext.Current;
            if (ctx.Session["LoginUser"] != null)
            {
                if (ctx.Request.Path != "/Logout")
                {
                    filterContext.Result = new RedirectResult("~/Admin/Dashboard");
                    return;
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}