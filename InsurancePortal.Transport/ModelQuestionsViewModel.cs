using System.Collections.Generic;

namespace InsurancePortal.Transport
{
    public class ModelQuestionsViewModel
    {
        public List<Tab> Tabs { get; set; }
    }

    public class Tab
    {
        public string TabText { get; set; }

        public List<Sections> SectionsList { get; set; }
    }

    public class Sections
    {
        public string SectionTitle { get; set; }

        public List<Questions> QuestionsList { get; set; }
    }

    public class Questions
    {
        public int QuestionId { get; set; }

        public string QuestionTitle { get; set; }

        public int QuestionType { get; set; }

        public string SubmittedAnswer { get; set; }

        public string ValidationMessage { get; set; }

        public List<Answers> AnswersList { get; set; }
    }

    public class Answers
    {
        public int AnswerId { get; set; }

        public string AnswerTitle { get; set; }

        public int SelectedAnswer { get; set; }
    }
}