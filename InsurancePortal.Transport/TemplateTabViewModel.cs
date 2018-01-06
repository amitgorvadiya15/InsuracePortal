using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsurancePortal.Transport
{
    public class TemplateTabViewModel
    {
        public int TemplateTabID { get; set; }
        public int TemplateID { get; set; }
        public string TabName { get; set; }
        public string TabDescription { get; set; }
        public string TabHeader { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
    }
}
