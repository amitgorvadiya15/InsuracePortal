using InsurancePortal.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuracePortal.Service
{
    public interface ITemplateService
    {
        bool SetTemplate(TemplateModel model);
        ManageQoutesViewModel GetTemplate();
        TemplateModel GetTemplate(int tempId);
        bool DelTemplate(int TemplateID);


        bool SetTemplateTab(TemplateTabModel model);
        List<TemplateTabModel> GetTemplateTab(int TempId);
        bool DelTemplateTab(int TemplateTabID);
        TemplateTabModel GetTemplateTabById(int tabId);

        bool SetTemplateQuestion(TemplateTabQuesionModel model);
        List<TemplateTabQuesionModel> GetTemplateQuestions(int tabId);
        bool DetTemplateQuestion(int TemplateQuestionID);
        TemplateTabQuesionModel GetTemplateQuestionByID(int QueId);

        ModelQuestionsViewModel GetTemplateQuestions(string templateName);
    }
}
