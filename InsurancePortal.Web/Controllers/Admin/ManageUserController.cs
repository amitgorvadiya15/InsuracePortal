using InsuracePortal.Service;
using InsurancePortal.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsurancePortal.Web.Controllers.Admin
{
    [LoginAuth]
    public class ManageUserController : Controller
    {
        private readonly IUserService _userService;

        public ManageUserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: ManageUser
        public ActionResult Index()
        {
            ViewBag.UserList = _userService.GetList();
            return View();
        }
    }
}