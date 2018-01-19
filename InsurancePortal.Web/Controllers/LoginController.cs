using InsuracePortal.Service;
using InsurancePortal.Transport;
using InsurancePortal.Web.Common;
using InsurancePortal.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsurancePortal.Web.Controllers
{
    [IsLogined]
    public class LoginController : Controller
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: Login
        public ActionResult Index(string type)
        {
            if (!string.IsNullOrEmpty(type))
            {
                if (type.ToUpper() == "BROKER")
                {
                    type = "Broker";
                }
                else if (type.ToUpper() == "INSURER")
                {
                    type = "Insurer";
                }
                else if (type.ToUpper() == "ADMIN")
                {
                    type = "Admin";
                }
                else
                {
                    type = "Customer";
                }
            }

            else
            {
                RedirectToAction("Index", "Home");
            }
            LoginModel model = new LoginModel();
            model.UserType = type;
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            if (!string.IsNullOrEmpty(model.UserType) && !string.IsNullOrEmpty(model.Password) && !string.IsNullOrEmpty(model.UserName))
            {
                string entrypass = CommonFunction.Encrypt(model.Password);
                UserViewModel usermodel = _userService.GetLoginUser(model.UserName, entrypass);
                if (usermodel != null)
                {
                    Session["LoginUser"] = usermodel;
                    return RedirectToAction("Index", "AdminHome");
                }
                else
                    return RedirectToAction("Index", "Home");
            }
            else
                return View(model);
        }

        public ActionResult Logout()
        {
            Session["LoginUser"] = null;
            return RedirectToAction("Index", "Login", new { @type = "Admin" });
        }
    }
}
