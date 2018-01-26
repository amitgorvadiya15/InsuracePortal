using InsuracePortal.Service;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace InsurancePortal.Web.Controllers
{
    public class QuoteController : Controller
    {
        private readonly ITemplateService _templateService;

        public QuoteController(ITemplateService templateService)
        {
            _templateService = templateService;
        }


        //public ActionResult Index()
        //{
        //    var template = _templateService.GetTemplate(1);
        //    return View();
        //}

        //private readonly ITemplateRepository iTemplateRepository;

        //public QuoteController()
        //{
        //    iTemplateRepository = new TemplateRepository();
        //}



        //// GET: Quote
        ////public ActionResult Index()
        ////{
        ////    ModelQuestions model = new ModelQuestions();
        ////    model.Tabs = new List<Tab>
        ////    {
        ////        new Tab{ProgressBarId = Guid.NewGuid(),TabText = "Your business" },
        ////        new Tab { ProgressBarId = Guid.NewGuid(), TabText = "Your employees" },
        ////        new Tab { ProgressBarId = Guid.NewGuid(), TabText = "Cover options" },
        ////        new Tab { ProgressBarId = Guid.NewGuid(), TabText = "Business questions" },
        ////        new Tab { ProgressBarId = Guid.NewGuid(), TabText = "Agreements" },
        ////        new Tab { ProgressBarId = Guid.NewGuid(), TabText = "Your quotes" }
        ////    };

        ////    model.SectionsList = new List<Sections>
        ////    {
        ////        new Sections{
        ////            SectionId = Guid.NewGuid(),
        ////            SectionTitle = "Please tell us about your business",
        ////            ProgressBarId = Guid.NewGuid(),
        ////            QuestionsList = new List<Questions>
        ////            {
        ////                new Questions{ QuestionId = Guid.NewGuid(),
        ////                QuestionTitle = "What is your specific business / trade?",
        ////                QuestionType = (int)QuestionType.AutoComplete,
        ////                },

        ////                new Questions{QuestionId = Guid.NewGuid(),
        ////                QuestionTitle = "Do you have a secondary business activity / secondary trade?",
        ////                QuestionType = (int)QuestionType.RadioButton,
        ////                AnswersList = new List<Answers>
        ////                {
        ////                    new Answers{AnswerId = Guid.NewGuid(),AnswerTitle = "Yes" },
        ////                    new Answers{AnswerId = Guid.NewGuid(),AnswerTitle = "No" },
        ////                }},

        ////                new Questions{QuestionId = Guid.NewGuid(),
        ////                QuestionTitle = "What is your business postcode?",
        ////                QuestionType = (int)QuestionType.TextBox,
        ////                },

        ////                new Questions{QuestionId = Guid.NewGuid(),
        ////                QuestionTitle = "How many years have you been running your own business in this industry?",
        ////                QuestionType = (int)QuestionType.Dropdown,
        ////                AnswersList = new List<Answers>
        ////                {
        ////                    new Answers{AnswerId = Guid.NewGuid(),AnswerTitle = "I've not started yet" },
        ////                    new Answers{AnswerId = Guid.NewGuid(),AnswerTitle = "Less than 1 year" },
        ////                    new Answers{AnswerId = Guid.NewGuid(),AnswerTitle = "1-2 years" },
        ////                    new Answers{AnswerId = Guid.NewGuid(),AnswerTitle = "2-3 years" },
        ////                    new Answers{AnswerId = Guid.NewGuid(),AnswerTitle = "3-4 years" },
        ////                    new Answers{AnswerId = Guid.NewGuid(),AnswerTitle = "4-5 years" },
        ////                    new Answers{AnswerId = Guid.NewGuid(),AnswerTitle = "Over 5 years" },
        ////                }},

        ////                new Questions{QuestionId = Guid.NewGuid(),
        ////                QuestionTitle = "Which of these categories best describes your business?",
        ////                QuestionType = (int)QuestionType.Dropdown,
        ////                AnswersList = new List<Answers>
        ////                {
        ////                    new Answers{AnswerId = Guid.NewGuid(),AnswerTitle = "Sole trader" },
        ////                    new Answers{AnswerId = Guid.NewGuid(),AnswerTitle = "Partnership" },
        ////                    new Answers{AnswerId = Guid.NewGuid(),AnswerTitle = "Limited company" }
        ////                }},


        ////            }
        ////        },

        ////        new Sections{ SectionId = Guid.NewGuid(),
        ////            SectionTitle = "Please enter your contact details",
        ////            ProgressBarId = Guid.NewGuid(),
        ////            QuestionsList = new List<Questions>
        ////            {
        ////                new Questions{ QuestionId = Guid.NewGuid(),
        ////                QuestionTitle = "Title",
        ////                QuestionType = (int)QuestionType.Dropdown,
        ////                AnswersList = new List<Answers>
        ////                {
        ////                    new Answers{AnswerId = Guid.NewGuid(),AnswerTitle = "Mr" },
        ////                    new Answers{AnswerId = Guid.NewGuid(),AnswerTitle = "Mrs" },
        ////                    new Answers{AnswerId = Guid.NewGuid(),AnswerTitle = "Miss" },
        ////                    new Answers{AnswerId = Guid.NewGuid(),AnswerTitle = "Ms" },
        ////                    new Answers{AnswerId = Guid.NewGuid(),AnswerTitle = "Dr" }
        ////                }},

        ////                new Questions{QuestionId = Guid.NewGuid(),
        ////                QuestionTitle = "First name",
        ////                QuestionType = (int)QuestionType.TextBox
        ////                },

        ////                new Questions{QuestionId = Guid.NewGuid(),
        ////                QuestionTitle = "Last name",
        ////                QuestionType = (int)QuestionType.TextBox,
        ////                },

        ////                new Questions{QuestionId = Guid.NewGuid(),
        ////                QuestionTitle = "Email address",
        ////                QuestionType = (int)QuestionType.TextBox,
        ////                },

        ////                new Questions{QuestionId = Guid.NewGuid(),
        ////                QuestionTitle = "Telephone number",
        ////                QuestionType = (int)QuestionType.TextBox,
        ////                },

        ////                new Questions{QuestionId = Guid.NewGuid(),
        ////                QuestionTitle = "Alternative phone number",
        ////                QuestionType = (int)QuestionType.TextBox,
        ////                }
        ////            }
        ////        }
        ////    };


        ////    foreach (var section in model.SectionsList)
        ////    {
        ////        foreach (var question in section.QuestionsList)
        ////        {
        ////            if (question.QuestionType == (int)QuestionType.Dropdown)
        ////            {
        ////                question.AnswersListDropDown = (from answer in question.AnswersList
        ////                                                select new SelectListItem
        ////                                                {
        ////                                                    Value = answer.AnswerId.ToString(),
        ////                                                    Text = answer.AnswerTitle
        ////                                                }).ToList();
        ////            }
        ////        }
        ////    }

        ////    return View(model);
        ////}

        public ActionResult Index(int templateId)
        {
            var model = _templateService.GetTemplateQuestionsForQuote(templateId);
            return View(model);
        }


    }
}