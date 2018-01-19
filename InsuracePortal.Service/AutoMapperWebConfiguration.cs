using AutoMapper;
using InsurancePortal.Data;
using InsurancePortal.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsurancePortal.Service
{
    public static class AutoMapperWebConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                //cfg.AddProfile(new UserProfile());
                cfg.CreateMap<User, UserViewModel>();
            });
        }
    }
}
