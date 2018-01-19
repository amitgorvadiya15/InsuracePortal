using InsuracePortal.Service;
using InsurancePortal.Transport;
using System.Web.Mvc;
using System.Linq;

namespace InsurancePortal.Web.Controllers.Admin
{
    public class SettingsController : Controller
    {
        private readonly ITemplateService _templateService;

        public SettingsController(ITemplateService templateService)
        {
            _templateService = templateService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddTemplate()
        {
            TemplateModel model = new TemplateModel();
            model.TemplateID = 0;
            return PartialView("PartialAddTemplate", model);
        }

        [HttpPost]
        public ActionResult AddTemplate(TemplateModel model)
        {
            _templateService.SetTemplate(model);
            return RedirectToAction("ManageQuotes");
        }

        #region Manage Quotes

        public ActionResult ManageQuotes()
        {
            var templates = _templateService.GetTemplate();
            return View(templates);
        }

        public ActionResult QuoteTemplate(int tempId)
        {
            TemplateModel model = new TemplateModel();
            var template = _templateService.GetTemplate(tempId);
            var lst = _templateService.GetTemplateTab(tempId);
            ViewBag.QuotesTab = lst;
            return View(model);
        }

        public ActionResult QuoteTabs(int tabId)
        {
            var model = _templateService.GetTemplateTabById(tabId);
            var lst = _templateService.GetTemplateQuestions(tabId);
            ViewBag.QuestionList = lst;
            return View(model);
        }

        public ActionResult AddTemplateTab(int TemplateId)
        {
            TemplateTabModel model = new TemplateTabModel();
            model.TemplateID = TemplateId;
            return PartialView("PartialAddTemplateTab", model);
        }

        [HttpPost]
        public ActionResult AddTemplateTab(TemplateTabModel model)
        {
            _templateService.SetTemplateTab(model);
            return RedirectToAction("QuoteTemplate", new { @tempId = model.TemplateID });
        }

        #endregion

        public ActionResult AddTabQuesion(int tabId, int QuesionId)
        {
            var model = _templateService.GetTemplateQuestionByID(QuesionId);

            return PartialView("PartialAddTabQuestion", model);
        }

        [HttpPost]
        public ActionResult AddTabQuesion(TemplateTabQuesionModel model)
        {
            _templateService.SetTemplateQuestion(model);

            return RedirectToAction("QuoteTabs", new { tabId = @model.TemplateTabID });
        }
    }

}