using AutoMapper;
using InsurancePortal.Data;
using InsurancePortal.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsurancePortal.Business.Respositories
{
    public class UserRepository
    {
        
        public List<UserViewModel> GetList()
        {
            List<UserViewModel> lst = new List<UserViewModel>();
            using (InsurancePortalEntities db = new InsurancePortalEntities())
            {
                var userlst = db.Users.ToList();
                foreach (var item in userlst)
                {
                    var userDto = Mapper.Map<User, UserViewModel>(item);
                    lst.Add(userDto);
                }
            }
            return lst;
        }

        public UserViewModel GetLoginUser(string UserName, string Password)
        {
            UserViewModel usermodel = new UserViewModel();
            using (InsurancePortalEntities db = new InsurancePortalEntities())
            {
                var user = db.Users.Where(x => x.UserName == UserName && x.Password == Password).FirstOrDefault();
                if (user != null)
                    usermodel = Mapper.Map<User, UserViewModel>(user);
            }
            return usermodel;
        }

        public UserViewModel GetUser(int UserId)
        {
            UserViewModel usermodel = new UserViewModel();
            using (InsurancePortalEntities db = new InsurancePortalEntities())
            {
                var user = db.Users.Where(x => x.UserId == UserId).FirstOrDefault();
                if (user != null)
                    usermodel = Mapper.Map<User, UserViewModel>(user);
            }
            return usermodel;
        }

        public bool SetUser(UserViewModel model)
        {
            using (InsurancePortalEntities db = new InsurancePortalEntities())
            {
                User usermodel = db.Users.Where(x => x.UserId == model.UserId).FirstOrDefault();
                if (usermodel != null)
                {
                    usermodel = Mapper.Map<UserViewModel, User>(model);
                    usermodel.ModifiedOn = DateTime.Now;
                }
                else
                {
                    usermodel = Mapper.Map<UserViewModel, User>(model);
                    db.Users.Add(usermodel);
                }
                db.SaveChanges();
            }
            return false;
        }
    }
}
