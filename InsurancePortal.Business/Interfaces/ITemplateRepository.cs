using InsurancePortal.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsurancePortal.Business.Interfaces
{
    public interface ITemplateRepository
    {
        bool SetTemplate(TemplateViewModel model);
        List<TemplateViewModel> GetTemplate();
        TemplateViewModel GetTemplate(int tempId);
        bool DelTemplate(int TemplateID);


        bool SetTemplateTab(TemplateTabViewModel model);
        List<TemplateTabViewModel> GetTemplateTab(int TempId);
        bool DelTemplateTab(int TemplateTabID);
        TemplateTabViewModel GetTemplateTabById(int tabId);

        bool SetTemplateQuestion(TemplateQuesionViewModel model);
        List<TemplateQuesionViewModel> GetTemplateQuestions(int tabId);
        bool DetTemplateQuestion(int TemplateQuestionID);
        TemplateQuesionViewModel GetTemplateQuestionByID(int QueId);

        ModelQuestionsViewModel GetTemplateQuestions(string templateName);
    }
}
