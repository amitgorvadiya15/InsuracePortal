using InsurancePortal.Business;
using InsurancePortal.Business.Interfaces;
using InsurancePortal.Business.Respositories;
using InsurancePortal.Transport;
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
        private readonly ITemplateRepository iTemplateRepository;
        public SettingsController()
        {
            iTemplateRepository = new TemplateRepository();
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
            TemplateViewModel obj = new TemplateViewModel();
            obj.TemplateID = model.TemplateID;
            obj.TemplateName = model.TemplateName;
            iTemplateRepository.SetTemplate(obj);
            return RedirectToAction("ManageQuotes");
        }

        #region Manage Quotes

        public ActionResult ManageQuotes()
        {
            ManageQoutesViewModel model = new ManageQoutesViewModel();
            model.TemplateList = iTemplateRepository.GetTemplate();
            return View(model);
        }

        public ActionResult QuoteTemplate(int tempId)
        {
            TemplateModel model = new TemplateModel();
            TemplateViewModel obj = iTemplateRepository.GetTemplate(tempId);
            if (obj != null)
            {
                model.TemplateID = obj.TemplateID;
                model.TemplateName = obj.TemplateName;
            }
            List<TemplateTabViewModel> lst = iTemplateRepository.GetTemplateTab(tempId);
            ViewBag.QuotesTab = lst;
            return View(model);
        }

        public ActionResult QuoteTabs(int tabId)
        {
            TemplateTabModel model = new TemplateTabModel();
            TemplateTabViewModel obj = iTemplateRepository.GetTemplateTabById(tabId);
            if (obj != null)
            {
                model.TemplateID = obj.TemplateID;
                model.TemplateTabID = obj.TemplateTabID;
                model.TemplateTabName = obj.TabName;
                model.TabDescription = obj.TabDescription;
                model.TabHeader = obj.TabHeader;
            }
            List<TemplateQuesionViewModel> lst = iTemplateRepository.GetTemplateQuestions(tabId);
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
            TemplateTabViewModel obj = new TemplateTabViewModel();
            obj.TemplateID = model.TemplateID;
            obj.TemplateTabID = model.TemplateTabID;
            obj.TabName = model.TemplateTabName;
            obj.TabHeader = model.TabHeader;
            obj.TabDescription = model.TabDescription;
            iTemplateRepository.SetTemplateTab(obj);
            return RedirectToAction("QuoteTemplate", new { @tempId = model.TemplateID });
        }

        #endregion

        public ActionResult AddTabQuesion(int tabId, int QuesionId)
        {

            TemplateTabQuesionModel model = new TemplateTabQuesionModel();
            model.TemplateTabID = tabId;
            model.TemplateQuesID = QuesionId;
            if (QuesionId > 0)
            {
                TemplateQuesionViewModel obj = new TemplateQuesionViewModel();
                obj = iTemplateRepository.GetTemplateQuestionByID(QuesionId);
                if (obj != null)
                {
                    model.AnswerDetails = obj.AnswerDetails;
                    model.AnswerType = obj.AnswerType;
                    model.Question = obj.Question;
                }
            }
            return PartialView("PartialAddTabQuestion", model);
        }

        [HttpPost]
        public ActionResult AddTabQuesion(TemplateTabQuesionModel model)
        {
            TemplateQuesionViewModel obj = new TemplateQuesionViewModel();
            obj.TemplateQuesID = model.TemplateQuesID;
            obj.TemplateTabID = model.TemplateTabID;
            obj.Question = model.Question;
            obj.AnswerDetails = model.AnswerDetails;
            obj.AnswerType = model.AnswerType;
            iTemplateRepository.SetTemplateQuestion(obj);
            return RedirectToAction("QuoteTabs", new { tabId = @model.TemplateTabID });
        }
    }

}