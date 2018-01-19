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
    }
}
