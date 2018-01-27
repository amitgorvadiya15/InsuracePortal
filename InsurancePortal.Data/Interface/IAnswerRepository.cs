using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsurancePortal.Data
{
    public interface IAnswerRepository : IBaseRepository<Answer>
    {
        List<Answer> GetByQuestion(int questionId);
    }
}
