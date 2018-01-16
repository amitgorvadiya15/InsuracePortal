using InsurancePortal.Business.Respositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsurancePortal.Web.Controllers.Admin
{
    public class ManageUserController : Controller
    {
        // GET: ManageUser
        public ActionResult Index()
        {
            UserRepository userRepository = new UserRepository();
            ViewBag.UserList = userRepository.GetList();
            return View();
        }
    }
}