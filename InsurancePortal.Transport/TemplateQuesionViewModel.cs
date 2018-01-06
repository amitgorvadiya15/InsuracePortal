using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsurancePortal.Transport
{
    public class TemplateQuesionViewModel
    {
        public int TemplateQuesID { get; set; }
        public int TemplateTabID { get; set; }
        public string Question { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public string AnswerType { get; set; }
        public string AnswerDetails { get; set; }
    }
}
