using InsurancePortal.Web.Common.Enums;
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
        public ActionResult Index(int templateId = (int)InsuranceTemplate.Car)
        {
            InsuranceTemplate enumTemplate = (InsuranceTemplate) templateId;

            string templateTitle = "<span>"+ enumTemplate.ToString() + " insurance<br>made for you</span>";
            ViewBag.TemplateTitle = templateTitle;
            ViewBag.TemplateId = templateId;

            //if (template == "Car")
            //    ViewBag.Template = "Business";

            //else if (template == "Home")
            //    ViewBag.Template = "Landlord";

            //else if (template == "Travel")
            //    ViewBag.Template = "Vehicle";

            //else if (template == "Public liability")
            //    ViewBag.Template = "Vehicle";

            //else if (template == "Professional indemnity")
            //    ViewBag.Template = "Vehicle";

            //else if (template == "Employers liability")
            //    ViewBag.Template = "Vehicle";

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