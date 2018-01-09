using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsurancePortal.Web.Models
{
    public class TemplateTabModel
    {
        public int TemplateID { get; set; }
        public int TemplateTabID { get; set; }
        public string TemplateTabName { get; set; }
        //public string TabDescription { get; set; }
        //public string TabHeader { get; set; }
        public string Sections { get; set; }
    }
}