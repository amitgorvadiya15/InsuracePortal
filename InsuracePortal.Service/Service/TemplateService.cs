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
        private readonly ITemplateRepository templateRepository;

        public TemplateService()
        {
            templateRepository = new TemplateRepository();
        }

        public Task<List<TemplateViewModel>> GetTemplate()
        {
            throw new NotImplementedException();
        }

        public async Task<TemplateViewModel> GetTemplate(int tempId)
        {
            var template = await templateRepository.GetById(tempId);
            var templateViewModel = new TemplateViewModel
            {
                TemplateID = template.TemplateID,
                TemplateName = template.TemplateName
            };
            return templateViewModel;
        }
    }
}
