//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InsurancePortal.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class TemplateQue
    {
        public int TemplateQuesID { get; set; }
        public int TemplateTabID { get; set; }
        public string Section { get; set; }
        public string Question { get; set; }
        public string AnswerType { get; set; }
        public string AnswerDetails { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
    }
}
