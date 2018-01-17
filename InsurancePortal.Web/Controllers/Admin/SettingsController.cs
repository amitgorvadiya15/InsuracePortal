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

        //GET: Settings
        //private readonly ITemplateRepository iTemplateRepository;
        //public SettingsController()
        //{
        //    iTemplateRepository = new TemplateRepository();
        //}
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

            //TemplateViewModel obj = new TemplateViewModel();
            //obj.TemplateID = model.TemplateID;
            //obj.TemplateName = model.TemplateName;
            //iTemplateRepository.SetTemplate(obj);
            return RedirectToAction("ManageQuotes");
        }

        #region Manage Quotes

        public ActionResult ManageQuotes()
        {
            //ManageQoutesViewModel model = new ManageQoutesViewModel();
            //model.TemplateList = iTemplateRepository.GetTemplate();

            var templates = _templateService.GetTemplate();
            return View(templates);
        }

        public ActionResult QuoteTemplate(int tempId)
        {
            TemplateModel model = new TemplateModel();
            //TemplateViewModel obj = iTemplateRepository.GetTemplate(tempId);
            //if (obj != null)
            //{
            //    model.TemplateID = obj.TemplateID;
            //    model.TemplateName = obj.TemplateName;
            //}
            //List<TemplateTabViewModel> lst = iTemplateRepository.GetTemplateTab(tempId);

            var template = _templateService.GetTemplate(tempId);

            var lst = _templateService.GetTemplateTab(tempId);

            ViewBag.QuotesTab = lst;
            return View(model);
        }

        public ActionResult QuoteTabs(int tabId)
        {
            //TemplateTabModel model = new TemplateTabModel();
            //TemplateTabViewModel obj = iTemplateRepository.GetTemplateTabById(tabId);
            //if (obj != null)
            //{
            //    model.TemplateID = obj.TemplateID;
            //    model.TemplateTabID = obj.TemplateTabID;
            //    model.TemplateTabName = obj.TabName;
            //    //model.TabDescription = obj.TabDescription;
            //    //model.TabHeader = obj.TabHeader;
            //    model.Sections = obj.Sections;
            //}

            var model = _templateService.GetTemplateTabById(tabId);

            //List<TemplateQuesionViewModel> lst = iTemplateRepository.GetTemplateQuestions(tabId);

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
            //TemplateTabViewModel obj = new TemplateTabViewModel();
            //obj.TemplateID = model.TemplateID;
            //obj.TemplateTabID = model.TemplateTabID;
            //obj.TabName = model.TemplateTabName;
            ////obj.TabHeader = model.TabHeader;
            ////obj.TabDescription = model.TabDescription;
            //obj.Sections = model.Sections;
            //iTemplateRepository.SetTemplateTab(obj);

            _templateService.SetTemplateTab(model);
            return RedirectToAction("QuoteTemplate", new { @tempId = model.TemplateID });
        }

        #endregion

        public ActionResult AddTabQuesion(int tabId, int QuesionId)
        {
            //TemplateTabQuesionModel model = new TemplateTabQuesionModel();
            //model.TemplateTabID = tabId;
            //model.TemplateQuesID = QuesionId;
            //if (QuesionId > 0)
            //{
            //    TemplateQuesionViewModel obj = new TemplateQuesionViewModel();
            //    obj = iTemplateRepository.GetTemplateQuestionByID(QuesionId);
            //    if (obj != null)
            //    {
            //        model.AnswerDetails = obj.AnswerDetails;
            //        model.AnswerType = obj.AnswerType;
            //        model.Question = obj.Question;
            //    }
            //}

            var model = _templateService.GetTemplateQuestionByID(QuesionId);

            return PartialView("PartialAddTabQuestion", model);
        }

        [HttpPost]
        public ActionResult AddTabQuesion(TemplateTabQuesionModel model)
        {
            //TemplateQuesionViewModel obj = new TemplateQuesionViewModel();
            //obj.TemplateQuesID = model.TemplateQuesID;
            //obj.TemplateTabID = model.TemplateTabID;
            //obj.Question = model.Question;
            //obj.AnswerDetails = model.AnswerDetails;
            //obj.AnswerType = model.AnswerType;
            //iTemplateRepository.SetTemplateQuestion(obj);
            _templateService.SetTemplateQuestion(model);

            return RedirectToAction("QuoteTabs", new { tabId = @model.TemplateTabID });
        }
    }

}