using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsurancePortal.Web.Models
{
    public class TemplateTabQuesionModel
    {
        public int TemplateQuesID { get; set; }
        public int TemplateTabID { get; set; }
        public string Question { get; set; }
        public string AnswerType { get; set; }
        public string AnswerDetails { get; set; }
    }
}