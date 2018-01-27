using InsurancePortal.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsurancePortal.Web.Common
{
    public static class SessionManager
    {
        public static UserViewModel CurrentUser
        {
            get
            {
                if (HttpContext.Current != null && HttpContext.Current.Session["LoginUser"] != null)
                    return HttpContext.Current.Session["LoginUser"] as UserViewModel;
                else
                    return null;
            }
            set
            {
                HttpContext.Current.Session["LoginUser"] = value;
            }
        }

        public static string LoginType
        {
            get
            {
                if (HttpContext.Current != null && HttpContext.Current.Session["LoginType"] != null)
                    return HttpContext.Current.Session["LoginType"] as string;
                else
                    return null;
            }
            set
            {
                HttpContext.Current.Session["LoginType"] = value;
            }
        }

        public static string Theme
        {
            get
            {
                if (HttpContext.Current != null && HttpContext.Current.Session["Theme"] != null)
                    return HttpContext.Current.Session["Theme"] as string;
                else
                    return null;
            }
            set
            {
                HttpContext.Current.Session["Theme"] = value;
            }
        }
    }
}