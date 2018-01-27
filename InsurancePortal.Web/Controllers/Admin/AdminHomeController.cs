using InsurancePortal.Transport;
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
            //UserViewModel usermodel = new UserViewModel();
            //usermodel.StrUserType = "Admin";
            //usermodel.UserType = Transport.Enums.enumUserType.Broker;
            //string strTheme = "Default";
            //if (Session["LoginUser"] != null)
            //{
            //    usermodel = new UserViewModel();
            //    usermodel = Session["LoginUser"] as UserViewModel;
            //}
            //else
            //{
            //    return RedirectToAction("Index", "Home");
            //}
            //ViewBag.Theme = strTheme;
            //ViewBag.UserModel = usermodel;
            return View();
        }
    }
}
