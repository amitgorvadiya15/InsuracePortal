using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsurancePortal.Web.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        public ActionResult Index(string template = "Car")
        {
            string templateTitle = "<span>"+ template +" insurance<br>made for you</span>";
            ViewBag.TemplateTitle = templateTitle;

            if(template == "Car")
                ViewBag.Template = "Business";

            if (template == "Travel")
                ViewBag.Template = "Vehicle";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Quote()
        {
            return View();
        }
    }
}