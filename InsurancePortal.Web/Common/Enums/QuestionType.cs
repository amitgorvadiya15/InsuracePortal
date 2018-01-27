using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace InsurancePortal.Web.Common.Enums
{
    public enum QuestionType
    {
        AutoComplete = 1,
        TextBox = 2,
        Dropdown = 3,
        RadioButton = 4,
        CheckBox = 5
    }

    public enum InsuranceTemplate
    {
        [Description("Car")]
        Car = 1,

        [Description("Home")]
        Home = 2,

        [Description("Travel")]
        Travel = 3,

        [Description("Public liability")]
        PublicLiability = 4,

        [Description("Professional indemnity")]
        ProfessionalIndemnity = 5,

        [Description("Employers liability")]
        EmployersLiability = 6
    }
}