using Ninject;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsurancePortal.Web.App_Start
{
    public class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        public static void Start() { }

        public static void Stop() { }

        private static IKernel CreateKernal()
        {
            return null;
        }

        private static void RegisterServices(IKernel kernal)
        {

        }
    }
}