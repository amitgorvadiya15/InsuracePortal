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
        Task<List<TemplateViewModel>> GetTemplate();
        Task<TemplateViewModel> GetTemplate(int tempId);
    }
}
