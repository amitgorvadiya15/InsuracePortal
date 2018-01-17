using InsurancePortal.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsurancePortal.Web.Controllers
{
    [Route("")]
    public class LoginController : Controller
    {
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
                if (model.UserType == "Admin" && model.Password == "admin" && Convert.ToString(model.UserName).ToLower() == "admin")
                    return RedirectToAction("Index", "AdminHome");
                else
                    return RedirectToAction("Index", "Home");
            }
            else
                return View(model);
        }
    }
}
