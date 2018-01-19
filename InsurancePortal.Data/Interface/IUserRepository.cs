using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsurancePortal.Data
{
    public  interface IUserRepository : IBaseRepository<User>
    {
        User GetByUserNameAndPassword(string userName,string password);
    }
}
