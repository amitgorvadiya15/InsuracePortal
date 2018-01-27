using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using InsurancePortal.Data;
using InsurancePortal.Transport;

namespace InsuracePortal.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<UserViewModel> GetList()
        {
            List<UserViewModel> lst = new List<UserViewModel>();
            var userlst = _userRepository.ListAll();
            foreach (var item in userlst)
            {
                var userDto = Mapper.Map<User, UserViewModel>(item);
                lst.Add(userDto);
            }
            return lst;
        }

        public UserViewModel GetLoginUser(string UserName, string Password)
        {
            UserViewModel usermodel = new UserViewModel();
            var user = _userRepository.GetByUserNameAndPassword(UserName, Password);
            if (user != null)
            {
                usermodel = Mapper.Map<User, UserViewModel>(user);
                return usermodel;
            }
            return null;
        }

        public UserViewModel GetUser(int UserId)
        {
            UserViewModel usermodel = new UserViewModel();
            var user = _userRepository.GetById(UserId);
            if (user != null)
                usermodel = Mapper.Map<User, UserViewModel>(user);
            return usermodel;
        }

        public bool SetUser(UserViewModel model)
        {
            if (model.UserId > 0)
            {
                User usermodel = _userRepository.GetById(model.UserId);
                if (usermodel != null)
                {
                    usermodel = Mapper.Map<UserViewModel, User>(model);
                    usermodel.ModifiedOn = DateTime.Now;
                    _userRepository.Update(usermodel);
                }
            }
            else
            {
                var usermodel = Mapper.Map<UserViewModel, User>(model);
                _userRepository.Add(usermodel);
            }
            return true;
        }
    }
}
