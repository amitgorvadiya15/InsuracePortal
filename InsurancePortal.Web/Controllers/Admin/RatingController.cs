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
    public class RatingController : Controller
    {
        private readonly ITemplateService _templateService;

        public RatingController(ITemplateService templateService)
        {
            _templateService = templateService;
        }

        // GET: ManageUser
        public ActionResult Index()
        {
            var templates = _templateService.GetTemplate();
            ViewBag.Templates = (from temp in templates.TemplateList
                                 select new SelectListItem
                                 {
                                     Text = temp.TemplateName,
                                     Value = temp.TemplateID.ToString()
                                 }).ToList();
            //var model = _templateService.GetTemplateRating(1);
            return View();
        }
    }
}