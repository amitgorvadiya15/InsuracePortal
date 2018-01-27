﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsurancePortal.Data
{
    public interface ITemplateQuestionRepository : IBaseRepository<TemplateQue>
    {
        List<TemplateQue> GetByTemplateId(int tempId);

        List<TemplateQue> GetByTabId(int tabId);
    }
}
