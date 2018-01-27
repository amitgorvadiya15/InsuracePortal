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
            if (string.IsNullOrEmpty(model.UserName))
            {
                ModelState.AddModelError("UserName", "Please enter password");
            }
            else if (string.IsNullOrEmpty(model.Password))
            {
                ModelState.AddModelError("Password", "Please enter password");
            }
            else if (!string.IsNullOrEmpty(model.UserType) && !string.IsNullOrEmpty(model.Password) && !string.IsNullOrEmpty(model.UserName))
            {
                string entrypass = CommonFunction.Encrypt(model.Password);
                UserViewModel usermodel = _userService.GetLoginUser(model.UserName, entrypass);
                if (usermodel != null)
                {
                    usermodel.StrUserType = "Admin";
                    SessionManager.Theme = "skin-black";
                    usermodel.UserType = Transport.Enums.enumUserType.Admin;
                    if (model.UserType == "Broker")
                    {
                        usermodel.UserType = Transport.Enums.enumUserType.Broker;
                        usermodel.StrUserType = "Broker";
                        SessionManager.Theme = "skin-green";
                    }
                    else if (model.UserType == "Insurer")
                    {
                        usermodel.UserType = Transport.Enums.enumUserType.Insurer;
                        usermodel.StrUserType = "Insurer";
                        SessionManager.Theme = "skin-blue";
                    }
                    else if (model.UserType == "Customer")
                    {
                        usermodel.UserType = Transport.Enums.enumUserType.Customer;
                        usermodel.StrUserType = "Customer";
                        SessionManager.Theme = "skin-blue";
                    }
                    //Session["LoginUser"] = usermodel;
                    SessionManager.CurrentUser = usermodel;
                    SessionManager.LoginType = usermodel.StrUserType;
                    return RedirectToAction("Index", "AdminHome");
                }
                else
                {
                    ModelState.AddModelError("Password", "Please enter valid username or password!");
                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            SessionManager.CurrentUser = null;
            string usertype = "Admin";
            if (SessionManager.LoginType != null)
            {
                usertype = SessionManager.LoginType;
            }
            return RedirectToAction("Index", "Login", new { @type = usertype });
        }
    }
}
