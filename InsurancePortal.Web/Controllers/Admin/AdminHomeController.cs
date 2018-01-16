using InsurancePortal.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsurancePortal.Web.Controllers.Admin
{
    [LoginAuth]
    public class AdminHomeController : Controller
    {
        // GET: AdminHome
        
       public ActionResult Index()
        {
            return View();
        }
    }
}
