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
        private readonly ITemplateRepository _templateRepository;

        public TemplateService(ITemplateRepository templateRepository)
        {
            _templateRepository = templateRepository;
        }

        public Task<List<TemplateViewModel>> GetTemplate()
        {
            throw new NotImplementedException();
        }

        public async Task<TemplateViewModel> GetTemplate(int tempId)
        {
            var template = await _templateRepository.GetByIdAsync(tempId);
            var templateViewModel = new TemplateViewModel
            {
                TemplateID = template.TemplateID,
                TemplateName = template.TemplateName
            };
            return templateViewModel;
        }
    }
}
