using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsurancePortal.Data;
using InsurancePortal.Transport;

namespace InsuracePortal.Service
{
    public class TemplateService : ITemplateService
    {
        private readonly ITemplateRepository _templateRepository;
        private readonly ITemplateTabRepository _templateTabRepository;
        private readonly ITemplateQuestionRepository _templateQuestionRepository;
        private readonly IAnswerRepository _answerRepository;

        private int ansCount = 0;


        public TemplateService(ITemplateRepository templateRepository,
            ITemplateTabRepository templateTabRepository,
            ITemplateQuestionRepository templateQuestionRepository,
            IAnswerRepository answerRepository)
        {
            _templateRepository = templateRepository;
            _templateTabRepository = templateTabRepository;
            _templateQuestionRepository = templateQuestionRepository;
            _answerRepository = answerRepository;
        }

        #region Template
        public bool SetTemplate(TemplateModel model)
        {
            try
            {
                if (model.TemplateID > 0)
                {
                    var template = _templateRepository.GetById(model.TemplateID);
                    if (template != null)
                    {
                        template.TemplateName = model.TemplateName;
                        template.ModifiedBy = 1;
                        template.ModifiedOn = DateTime.UtcNow;
                        _templateRepository.Update(template);
                    }
                }
                else
                {
                    var template = new Template
                    {
                        TemplateName = model.TemplateName,
                        CreatedBy = 1,
                        CreatedOn = DateTime.Now
                    };
                    _templateRepository.Add(template);
                }
                //_templateRepository.SaveChangesAsync();
                return true;
            }
            catch (EntryPointNotFoundException ex)
            {
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool DelTemplate(int TemplateID)
        {
            try
            {
                var template = _templateRepository.GetById(TemplateID);

                if (template != null)
                {
                    _templateRepository.Delete(template);
                    //_templateRepository.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (EntryPointNotFoundException ex)
            {
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public ManageQoutesViewModel GetTemplate()
        {
            ManageQoutesViewModel model = new ManageQoutesViewModel();
            try
            {
                var templates = _templateRepository.ListAll();

                model.TemplateList = (from t in templates
                                      select new TemplateModel
                                      {
                                          TemplateID = t.TemplateID,
                                          TemplateName = t.TemplateName
                                      }).OrderBy(x => x.TemplateID).ToList();

            }
            catch (EntryPointNotFoundException ex)
            {
                string msg = ex.Message;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return model;
        }

        public TemplateModel GetTemplate(int tempId)
        {
            TemplateModel model = new TemplateModel();
            if (tempId > 0)
            {
                var template = _templateRepository.GetById(tempId);
                if (template != null)
                {
                    model.TemplateID = template.TemplateID;
                    model.TemplateName = template.TemplateName;
                }
            }
            return model;
        }
        #endregion

        #region Template Tab

        public List<TemplateTabModel> GetTemplateTab(int TempId)
        {
            List<TemplateTabModel> templist = new List<TemplateTabModel>();
            try
            {
                var templateTabs = _templateTabRepository.ListAll().Where(x => x.TemplateID == TempId).OrderBy(x => x.TemplateID).ToList();
                if (templateTabs != null && templateTabs.Count > 0)
                {
                    templist = (from x in templateTabs
                                select new TemplateTabModel
                                {
                                    TemplateID = x.TemplateID,
                                    TemplateTabID = x.TemplateTabID,
                                    TemplateTabName = x.TabName
                                }).ToList();
                }
            }
            catch (EntryPointNotFoundException ex)
            {
                string msg = ex.Message;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return templist;
        }

        public bool SetTemplateTab(TemplateTabModel model)
        {
            try
            {
                if (model.TemplateTabID > 0)
                {
                    var templateTab = _templateTabRepository.GetById(model.TemplateTabID);
                    if (templateTab != null)
                    {
                        templateTab.TabName = model.TemplateTabName;
                        templateTab.Sections = model.Sections;
                        templateTab.ModifiedOn = DateTime.UtcNow;
                        templateTab.ModifiedBy = 1;
                        _templateTabRepository.Update(templateTab);
                    }
                }
                else
                {
                    var templateTab = new TemplateTab();
                    templateTab.TemplateID = model.TemplateID;
                    templateTab.TabName = model.TemplateTabName;
                    templateTab.Sections = model.Sections;
                    templateTab.CreatedOn = DateTime.UtcNow;
                    templateTab.CreatedBy = 1;
                    _templateTabRepository.Add(templateTab);
                }

                //_templateTabRepository.SaveChangesAsync();

                return true;
            }
            catch (EntryPointNotFoundException ex)
            {
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DelTemplateTab(int TemplateTabID)
        {
            return false;
        }

        public TemplateTabModel GetTemplateTabById(int tabId)
        {
            TemplateTabModel tempTab = new TemplateTabModel();
            try
            {
                var templateTab = _templateTabRepository.GetById(tabId);
                if (templateTab != null)
                {
                    tempTab.TemplateID = templateTab.TemplateID;
                    tempTab.TemplateTabID = templateTab.TemplateTabID;
                    tempTab.TemplateTabName = templateTab.TabName;
                    tempTab.Sections = templateTab.Sections;
                }
            }
            catch (EntryPointNotFoundException ex)
            {
                string msg = ex.Message;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return tempTab;
        }

        #endregion

        #region Template Question

        public List<TemplateTabQuesionModel> GetTemplateQuestions(int tabId)
        {
            List<TemplateTabQuesionModel> tempQuestionlist = new List<TemplateTabQuesionModel>();
            try
            {
                var questions = _templateQuestionRepository.ListAll().OrderBy(x => x.TemplateQuesID).Where(x => x.TemplateTabID == tabId).ToList();

                tempQuestionlist = (from x in questions
                                    select new TemplateTabQuesionModel
                                    {
                                        Question = x.Question,
                                        AnswerDetails = x.AnswerDetails,
                                        AnswerType = x.AnswerType,
                                        TemplateQuesID = x.TemplateQuesID,
                                        TemplateTabID = x.TemplateQuesID,
                                    }).ToList();

            }
            catch (EntryPointNotFoundException ex)
            {
                string msg = ex.Message;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return tempQuestionlist;
        }

        public TemplateTabQuesionModel GetTemplateQuestionByID(int QueId)
        {
            TemplateTabQuesionModel question = new TemplateTabQuesionModel();
            try
            {
                if (QueId > 0)
                {
                    var templateQue = _templateQuestionRepository.GetById(QueId);
                    if (templateQue != null)
                    {
                        question.Question = templateQue.Question;
                        question.AnswerDetails = templateQue.AnswerDetails;
                        question.AnswerType = templateQue.AnswerType;
                        question.TemplateQuesID = templateQue.TemplateQuesID;
                        question.TemplateTabID = templateQue.TemplateTabID;
                        question.Section = templateQue.Section ?? "";
                    }
                }
                else
                {
                }
            }
            catch (EntryPointNotFoundException ex)
            {
                string msg = ex.Message;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return question;
        }

        public bool SetTemplateQuestion(TemplateTabQuesionModel model)
        {
            try
            {
                var tempQuestion = new TemplateQue();

                if (model.TemplateQuesID > 0)
                {
                    tempQuestion = _templateQuestionRepository.GetById(model.TemplateQuesID);

                    tempQuestion.TemplateTabID = model.TemplateTabID;
                    tempQuestion.Question = model.Question;
                    tempQuestion.Section = model.Section;
                    tempQuestion.AnswerDetails = model.AnswerDetails;
                    tempQuestion.AnswerType = model.AnswerType;
                    tempQuestion.ParentId = model.Parent;
                    tempQuestion.RenderOnAnwerId = model.RenderOnAnswerId;
                    tempQuestion.Tooltip = model.Tooltip;
                    tempQuestion.ModifiedOn = DateTime.UtcNow;
                    tempQuestion.ModifiedBy = 1;
                    _templateQuestionRepository.Update(tempQuestion);
                }
                else
                {
                    tempQuestion.TemplateQuesID = model.TemplateTabID;
                    tempQuestion.TemplateTabID = model.TemplateTabID;
                    tempQuestion.Section = model.Section;
                    tempQuestion.Question = model.Question;
                    tempQuestion.AnswerDetails = model.AnswerDetails;
                    tempQuestion.AnswerType = model.AnswerType;
                    tempQuestion.ParentId = model.Parent;
                    tempQuestion.RenderOnAnwerId = model.RenderOnAnswerId;
                    tempQuestion.Tooltip = model.Tooltip;
                    tempQuestion.CreatedOn = DateTime.Now;
                    tempQuestion.CreatedBy = 1;

                    _templateQuestionRepository.Add(tempQuestion);

                    if (!string.IsNullOrWhiteSpace(model.AnswerDetails))
                    {
                        var answers = (from ans in model.AnswerDetails.Split(',')
                                       select new Answer
                                       {
                                           AnswerText = ans,
                                           QuestionId = tempQuestion.TemplateQuesID
                                       }).ToList();

                        _answerRepository.AddRange(answers);
                    }
                }

                //_templateQuestionRepository.SaveChangesAsync();

                return true;
            }
            catch (EntryPointNotFoundException ex)
            {
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DetTemplateQuestion(int TemplateQuestionID)
        {
            return false;
        }

        #endregion

        public ModelQuestionsViewModel GetTemplateQuestionsForQuote(int templateId)
        {
            var model = new ModelQuestionsViewModel();

            //using (InsurancePortalEntities db = new InsurancePortalEntities())
            //{
            var template = new Template();

            template = _templateRepository.ListAll().Where(x => x.TemplateID.Equals(templateId)).FirstOrDefault();

            if (template != null)
            {
                var templateTabs = _templateTabRepository.ListAll().Where(x => x.TemplateID == template.TemplateID).ToList();

                if (templateTabs != null && templateTabs.Count > 0)
                {
                    model.Tabs = new List<Tab>();

                    foreach (var t in templateTabs)
                    {
                        Tab tab = new Tab();
                        tab.TabText = t.TabName;
                        tab.SectionsList = new List<Sections>();

                        model.Tabs.Add(tab);

                        if (t.Sections != null)
                        {
                            foreach (var sec in t.Sections.Split(','))
                            {
                                Sections section = new Sections();
                                section.SectionTitle = sec;
                                //var sectionQuestions = db.TemplateQues.Where(x => x.TemplateTabID.Equals(template.TemplateID) && x.Section.Equals(sec)).ToList();
                                var sectionQuestions = _templateQuestionRepository.ListAll().Where(x => x.TemplateTabID.Equals(t.TemplateTabID)
                                                                                                    && x.Section.ToLower().Equals(sec.ToLower())
                                                                                                    && x.ParentId == 0
                                                                                                    ).ToList();

                                section.QuestionsList = GetQuestions(sectionQuestions);

                                //if (section.QuestionsList.Count > 0)
                                //{
                                //    foreach (var question in section.QuestionsList)
                                //    {
                                //        if (Convert.ToInt32(question.ParentId) > 0)
                                //        {

                                //        }
                                //    }
                                //}

                                tab.SectionsList.Add(section);
                            }
                        }
                    }
                }
            }
            //var sub = _templateQuestionRepository.ListAll().Where(x => x.ParentId.Equals(16)).ToList();
            //}
            return model;
        }

        private List<Questions> GetQuestions(List<TemplateQue> queList)
        {
            int[] questionType = { 3, 4, 5 };

            var questions = (from que in queList
                             select new Questions
                             {
                                 QuestionId = que.TemplateQuesID,
                                 QuestionTitle = que.Question,
                                 QuestionType = Convert.ToInt32(que.AnswerType),
                                 Tooltip = string.IsNullOrEmpty(que.Tooltip) ? "" : que.Tooltip,
                                 ParentId = que.ParentId ?? 0,
                                 RenderOnAnswerId = Convert.ToInt32(que.ParentId) > 0 ? que.RenderOnAnwerId ?? 0 : 0,
                                 AnswersList = !questionType.Contains(Convert.ToInt32(que.AnswerType)) ? new List<AnswersOfQuestion>() : GetAnswersOfQuestion(que.TemplateQuesID),
                                 SubQuestions = GetQuestions(_templateQuestionRepository.ListAll().Where(x => x.ParentId.Equals(que.TemplateQuesID)).ToList())
                             }).ToList();

            return questions;
        }

        public List<AnswersOfQuestion> GetAnswersOfQuestion(int questionId)
        {
            var answers = _answerRepository.GetByQuestion(questionId);

            var answersOfQuestion = new List<AnswersOfQuestion>();

            if (answers != null && answers.Count > 0)
            {
                answersOfQuestion = (from ans in answers
                                     select new AnswersOfQuestion
                                     {
                                         AnswerId = ans.AnswerId,
                                         AnswerTitle = ans.AnswerText,
                                     }).ToList();
            }

            return answersOfQuestion;
        }

        public RatingViewModel GetTemplateRating(int templateId)
        {
            var template = new Template();

            template = _templateRepository.GetById(templateId);

            var model = new RatingViewModel();

            model.QuestionsList = new List<Questions>();

            if (template != null)
            {
                var tempQuestions = _templateQuestionRepository.GetByTemplateId(templateId);

                int[] questionType = { 3, 4, 5 };

                model.QuestionsList = (from que in tempQuestions
                                       select new Questions
                                       {
                                           QuestionId = que.TemplateQuesID,
                                           QuestionTitle = que.Question,
                                           QuestionType = Convert.ToInt32(que.AnswerType),
                                           AnswersList = !questionType.Contains(Convert.ToInt32(que.AnswerType)) ? new List<AnswersOfQuestion>() : (from ans in que.AnswerDetails.Split(',')
                                                                                                                                                    select new AnswersOfQuestion
                                                                                                                                                    {
                                                                                                                                                        AnswerId = 1,
                                                                                                                                                        AnswerTitle = ans
                                                                                                                                                    }).ToList()

                                       }).ToList();
            }
            return model;
        }

        public List<Questions> GetByTabAndSection(int tabId, string section)
        {
            var questions = new List<Questions>();
            if (tabId > 0)
            {
                var tabQuestions = _templateQuestionRepository.GetByTabId(tabId);

                if (tabQuestions != null && tabQuestions.Count > 0)
                {
                    var sectionQuestions = tabQuestions.Where(x => x.Section.ToLower().Equals(section.ToLower()));

                    if (sectionQuestions != null && sectionQuestions.Count() > 0)
                    {
                        questions = (from que in sectionQuestions
                                     select new Questions
                                     {
                                         QuestionId = que.TemplateQuesID,
                                         QuestionTitle = que.Question
                                     }).ToList();
                    }
                }
            }

            return questions;
        }
    }
}
