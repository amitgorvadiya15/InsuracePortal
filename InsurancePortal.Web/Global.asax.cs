﻿using InsurancePortal.Business;
using InsurancePortal.Business.Interfaces;
//using InsurancePortal.Web.App_Start;
//using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace InsurancePortal.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

         
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutoMapperWebConfiguration.Configure();
            //Bind Ninject Dependency
            //DependencyResolver.SetResolver(new NinjectResolver());

        }
    }
}
