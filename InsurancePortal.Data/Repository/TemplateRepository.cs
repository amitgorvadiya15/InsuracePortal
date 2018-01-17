using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsurancePortal.Data
{
    public class TemplateRepository : BaseRepository<Template>,ITemplateRepository
    {
        public TemplateRepository(InsurancePortalEntities dbContext) : base(dbContext)
        {

        }
    }
}
