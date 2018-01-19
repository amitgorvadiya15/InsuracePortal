using InsurancePortal.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuracePortal.Service
{
    public interface IUserService
    {
        List<UserViewModel> GetList();

        UserViewModel GetLoginUser(string UserName, string Password);

        UserViewModel GetUser(int UserId);

        bool SetUser(UserViewModel model);
    }
}
