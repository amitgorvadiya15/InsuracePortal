using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsurancePortal.Data
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(InsurancePortalEntities dbContext) : base(dbContext)
        {
        }

        public User GetByUserNameAndPassword(string userName, string password)
        {
            var user = _dbContext.Users.Where(x => x.UserName == userName && x.Password == password).FirstOrDefault();
            return user;
        }
    }
}
