using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsurancePortal.Web.Common
{
    public class LoginAuth : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext ctx = HttpContext.Current;
            if (HttpContext.Current.Session["LoginUser"] == null)
            {
                filterContext.Result = new RedirectResult("~/Login/admin");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}