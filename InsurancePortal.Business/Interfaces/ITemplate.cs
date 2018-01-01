using InsurancePortal.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsurancePortal.Business.Interfaces
{
    public interface ITemplate
    {
        bool SetTemplate(TemplateViewModel model);
        List<TemplateViewModel> GetTemplate();
        bool DelTemplate(int TemplateID);
    }
}
