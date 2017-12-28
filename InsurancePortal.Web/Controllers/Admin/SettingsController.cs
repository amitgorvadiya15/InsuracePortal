using InsurancePortal.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsurancePortal.Web.Controllers.Admin
{
    public class SettingsController : Controller
    {
        // GET: Settings
        public ActionResult Index()
        {
            return View();
        }

        #region Manage Quotes
        public ActionResult ManageQuotes()
        {
            ManageQoutesViewModel model = new ManageQoutesViewModel();
            return View(model);
        }

        public ActionResult QuoteTemplate()
        {
            return View();
        }

        public ActionResult QuoteTabs()
        {
            return View();
        }
        #endregion
    }
}
