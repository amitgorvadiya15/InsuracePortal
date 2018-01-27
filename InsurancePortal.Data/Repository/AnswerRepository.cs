using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsurancePortal.Data.Repository
{
    public class AnswerRepository : BaseRepository<Answer>, IAnswerRepository
    {
        public AnswerRepository(InsurancePortalEntities dbContext) : base(dbContext)
        {
            
        }

        public List<Answer> GetByQuestion(int questionId)
        {
            var answers = (from ans in _dbContext.Answers
                           where ans.QuestionId == questionId
                           select ans).ToList();

            return answers;
        }
    }
}
