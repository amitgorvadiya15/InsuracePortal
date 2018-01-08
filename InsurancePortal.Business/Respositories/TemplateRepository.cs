using InsurancePortal.Business.Interfaces;
using InsurancePortal.Data;
using InsurancePortal.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsurancePortal.Business.Respositories
{
    public class TemplateRepository : ITemplateRepository
    {
        #region Template
        public bool SetTemplate(TemplateViewModel model)
        {
            try
            {
                using (InsurancePortalEntities db = new InsurancePortalEntities())
                {
                    Template obj = db.Templates.Where(x => x.TemplateID == model.TemplateID).FirstOrDefault();
                    if (obj != null)
                    {
                        obj.TemplateName = model.TemplateName;
                        obj.ModifiedOn = DateTime.Now;
                        db.SaveChanges();
                    }
                    else
                    {
                        obj = new Template();
                        obj.TemplateName = model.TemplateName;
                        obj.CreatedOn = DateTime.Now;
                        obj.CreatedBy = 1;
                        db.Templates.Add(obj);
                        db.SaveChanges();
                    }
                    return true;
                }
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
                using (InsurancePortalEntities db = new InsurancePortalEntities())
                {
                    Template obj = db.Templates.Where(x => x.TemplateID == TemplateID).FirstOrDefault();
                    if (obj != null)
                    {
                        db.Templates.Remove(obj);
                        db.SaveChanges();
                        return true;
                    }
                    return false;
                }
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

        public List<TemplateViewModel> GetTemplate()
        {
            List<TemplateViewModel> templist = new List<TemplateViewModel>();
            try
            {
                using (InsurancePortalEntities _context = new InsurancePortalEntities())
                {
                    List<Template> list = _context.Templates.ToList();
                    if (list != null && list.Count > 0)
                    {
                        templist = list.Select(x => new TemplateViewModel
                        {
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedBy = x.ModifiedBy,
                            ModifiedOn = x.ModifiedOn,
                            TemplateID = x.TemplateID,
                            TemplateName = x.TemplateName,
                        }).ToList();
                    }
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

        public TemplateViewModel GetTemplate(int tempId)
        {
            TemplateViewModel model = new TemplateViewModel();
            using (InsurancePortalEntities db = new InsurancePortalEntities())
            {
                Template obj = db.Templates.Where(x => x.TemplateID == tempId).FirstOrDefault();
                if (obj != null)
                {
                    model.TemplateID = obj.TemplateID;
                    model.TemplateName = obj.TemplateName;
                }
            }
            return model;
        }
        #endregion

        #region Template Tab

        public List<TemplateTabViewModel> GetTemplateTab(int TempId)
        {
            List<TemplateTabViewModel> templist = new List<TemplateTabViewModel>();
            try
            {
                using (InsurancePortalEntities _context = new InsurancePortalEntities())
                {
                    List<TemplateTab> list = _context.TemplateTabs.Where(x => x.TemplateID == TempId).ToList();
                    if (list != null && list.Count > 0)
                    {
                        templist = list.Select(x => new TemplateTabViewModel
                        {
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedBy = x.ModifiedBy,
                            ModifiedOn = x.ModifiedOn,
                            TemplateID = x.TemplateID,
                            TabName = x.TabName,
                            TabDescription = x.TabDescription,
                            TabHeader = x.TabHeader,
                            TemplateTabID = x.TemplateTabID,
                        }).ToList();
                    }
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

        public bool SetTemplateTab(TemplateTabViewModel model)
        {
            try
            {
                using (InsurancePortalEntities db = new InsurancePortalEntities())
                {
                    TemplateTab obj = db.TemplateTabs.Where(x => x.TemplateTabID == model.TemplateTabID && x.TemplateID == model.TemplateID).FirstOrDefault();
                    if (obj != null)
                    {
                        obj.TabName = model.TabName;
                        obj.TabDescription = model.TabDescription;
                        obj.TabHeader = model.TabHeader;
                        obj.ModifiedOn = DateTime.Now;
                        db.SaveChanges();
                    }
                    else
                    {
                        obj = new TemplateTab();
                        obj.TemplateID = model.TemplateID;
                        obj.TabName = model.TabName;
                        obj.TabDescription = model.TabDescription;
                        obj.TabHeader = model.TabHeader;
                        obj.CreatedOn = DateTime.Now;
                        obj.CreatedBy = 1;
                        db.TemplateTabs.Add(obj);
                        db.SaveChanges();
                    }
                    return true;
                }
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

        public TemplateTabViewModel GetTemplateTabById(int tabId)
        {
            TemplateTabViewModel templist = new TemplateTabViewModel();
            try
            {
                using (InsurancePortalEntities _context = new InsurancePortalEntities())
                {
                    TemplateTab obj = _context.TemplateTabs.Where(x => x.TemplateTabID == tabId).FirstOrDefault();
                    if (obj != null)
                    {
                        templist.CreatedBy = obj.CreatedBy;
                        templist.CreatedOn = obj.CreatedOn;
                        templist.ModifiedBy = obj.ModifiedBy;
                        templist.ModifiedOn = obj.ModifiedOn;
                        templist.TemplateID = obj.TemplateID;
                        templist.TabName = obj.TabName;
                        templist.TabHeader = obj.TabHeader;
                        templist.TabDescription = obj.TabDescription;
                        templist.TemplateTabID = obj.TemplateTabID;
                    }
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

        #endregion

        #region Template Question

        public List<TemplateQuesionViewModel> GetTemplateQuestions(int tabId)


        {
            List<TemplateQuesionViewModel> templist = new List<TemplateQuesionViewModel>();
            try
            {
                using (InsurancePortalEntities _context = new InsurancePortalEntities())
                {
                    List<TemplateQue> list = _context.TemplateQues.Where(x => x.TemplateTabID == tabId).ToList();
                    if (list != null && list.Count > 0)
                    {
                        templist = list.Select(x => new TemplateQuesionViewModel
                        {
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedBy = x.ModifiedBy,
                            ModifiedOn = x.ModifiedOn,
                            Question = x.Question,
                            AnswerDetails = x.AnswerDetails,
                            AnswerType = x.AnswerType,
                            TemplateQuesID = x.TemplateQuesID,
                            TemplateTabID = x.TemplateQuesID,
                        }).ToList();
                    }
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

        public TemplateQuesionViewModel GetTemplateQuestionByID(int QueId)
        {
            TemplateQuesionViewModel model = new TemplateQuesionViewModel();
            try
            {
                using (InsurancePortalEntities _context = new InsurancePortalEntities())
                {
                    TemplateQue templateQue = _context.TemplateQues.Where(x => x.TemplateQuesID == QueId).FirstOrDefault();
                    if (templateQue != null)
                    {
                        model.CreatedBy = templateQue.CreatedBy;
                        model.CreatedOn = templateQue.CreatedOn;
                        model.ModifiedBy = templateQue.ModifiedBy;
                        model.ModifiedOn = templateQue.ModifiedOn;
                        model.Question = templateQue.Question;
                        model.AnswerDetails = templateQue.AnswerDetails;
                        model.AnswerType = templateQue.AnswerType;
                        model.TemplateQuesID = templateQue.TemplateQuesID;
                        model.TemplateTabID = templateQue.TemplateQuesID;
                    }
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
            return model;
        }

        public bool SetTemplateQuestion(TemplateQuesionViewModel model)
        {
            try
            {
                using (InsurancePortalEntities db = new InsurancePortalEntities())
                {
                    TemplateQue obj = db.TemplateQues.Where(x => x.TemplateTabID == model.TemplateTabID && x.TemplateQuesID == model.TemplateQuesID)
                        .FirstOrDefault();
                    if (obj != null)
                    {
                        obj.Question = model.Question;
                        obj.AnswerDetails = model.AnswerDetails;
                        obj.AnswerType = model.AnswerType;
                        obj.ModifiedOn = DateTime.Now;
                        db.SaveChanges();
                    }
                    else
                    {
                        obj = new TemplateQue();
                        obj.TemplateQuesID = model.TemplateTabID;
                        obj.TemplateTabID = model.TemplateTabID;
                        obj.Question = model.Question;
                        obj.AnswerDetails = model.AnswerDetails;
                        obj.AnswerType = model.AnswerType;
                        obj.CreatedOn = DateTime.Now;
                        obj.CreatedBy = 1;
                        db.TemplateQues.Add(obj);
                        db.SaveChanges();
                    }
                    return true;
                }
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

        public ModelQuestionsViewModel GetTemplateQuestions(string templateName)
        {
            var model = new ModelQuestionsViewModel();

            using (InsurancePortalEntities db = new InsurancePortalEntities())
            {
                var template = new Template();
                try
                {
                    template = db.Templates.Where(x => x.TemplateName.Contains(templateName)).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                

                var templateTabs = db.TemplateTabs.Where(x => x.TemplateID == template.TemplateID);

                model.Tabs = new List<Tab>();

                foreach (var t in templateTabs)
                {
                    Tab tab = new Tab();
                    tab.TabText = t.TabName;
                    tab.SectionsList = new List<Sections>();

                    foreach (var sec in t.Sections.Split(','))
                    {
                        Sections section = new Sections();
                        section.SectionTitle = sec;
                        var sectionQuestions = db.TemplateQues.Where(x => x.TemplateTabID.Equals(template.TemplateID) && x.Section.Equals(sec)).ToList();
                        section.QuestionsList = (from que in sectionQuestions
                                                 select new Questions
                                                 {
                                                     QuestionId = que.TemplateQuesID,
                                                     QuestionTitle = que.Question,
                                                     QuestionType = Convert.ToInt32(que.AnswerType),
                                                     AnswersList = (from ans in que.AnswerDetails.Split(',')
                                                                    select new Answers
                                                                    {
                                                                        AnswerId = 1,
                                                                        AnswerTitle = ans
                                                                    }).ToList()
                                                 }).ToList();
                    }
                }
            }
            return model;
        }
    }

}
