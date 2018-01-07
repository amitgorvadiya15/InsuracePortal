using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsurancePortal.Web.Models
{
    public class ModelQuestions
    {
        public List<ProgressBar> ProgressBarsList { get; set; }

        public List<Sections> SectionsList { get; set; }
    }

    public class ProgressBar
    {
        public Guid ProgressBarId { get; set; }

        public string ProgressBarTitle { get; set; }
    }

    public class Sections
    {
        public Guid SectionId { get; set; }

        public Guid ProgressBarId { get; set; }

        public string SectionTitle { get; set; }

        public List<Questions> QuestionsList { get; set; }
    }

    public class Questions
    {
        public Guid QuestionId { get; set; }

        public string QuestionTitle { get; set; }

        public int QuestionType { get; set; }

        public string SubmittedAnswer { get; set; }

        public string ValidationMessage { get; set; }

        public List<Answers> AnswersList { get; set; }

        public List<SelectListItem> AnswersListDropDown { get; set; }
    }

    public class Answers
    {
        public Guid AnswerId { get; set; }

        public string AnswerTitle { get; set; }

        public Guid SelectedAnswer { get; set; }
    }


}