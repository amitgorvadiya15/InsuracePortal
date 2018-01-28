using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace InsurancePortal.Transport
{
    public class TemplateTabQuesionModel
    {
        public int TemplateQuesID { get; set; }
        public int TemplateTabID { get; set; }
        public string Question { get; set; }
        public string AnswerType { get; set; }
        public string AnswerDetails { get; set; }
        public string Section { get ; set; }
        public int Parent { get; set; }
        public int RenderOnAnswerId { get; set; }
        public string Tooltip { get; set; }
        [DefaultValue(false)]
        public bool IsSubQuestion { get; set; }
    }
}