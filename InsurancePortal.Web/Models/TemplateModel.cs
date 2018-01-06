using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InsurancePortal.Web.Models
{
    public class TemplateModel
    {
        [Required(ErrorMessage = "Please enter template name.")]
        public string TemplateName { get; set; }
        public int TemplateID { get; set; }
    }
}