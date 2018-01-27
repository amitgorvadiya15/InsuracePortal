using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsurancePortal.Data
{
    public class TemplateQuestionRepository : BaseRepository<TemplateQue>, ITemplateQuestionRepository
    {
        public TemplateQuestionRepository(InsurancePortalEntities dbContext) : base(dbContext)
        {
        }

        public List<TemplateQue> GetByTemplateId(int tempId)
        {
            var tempQuestions = (from tq in _dbContext.TemplateQues
                                 join tb in _dbContext.TemplateTabs on tq.TemplateTabID equals tb.TemplateTabID
                                 where tb.TemplateID == tempId
                                 select tq).ToList();

            return tempQuestions;
        }

        public List<TemplateQue> GetByTabId(int tabId)
        {
            var tabQuestions = (from tq in _dbContext.TemplateQues
                                 where tq.TemplateTabID == tabId
                                 select tq).ToList();

            return tabQuestions;
        }
    }
}
