using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsurancePortal.Data
{
    public class TemplateTabRepository : BaseRepository<TemplateTab>, ITemplateTabRepository
    {
        public TemplateTabRepository(InsurancePortalEntities dbContext) : base(dbContext)
        {
        }
    }
}
