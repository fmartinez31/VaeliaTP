using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalMVC
{
    public class SessionState
    {
        public static string UserName
        {
            get
            {
                string result = HttpContext.Current.Session["UserName"] as string;
                if (result == null)
                    return "Non Connecté";
                else
                    return result;
            }
            set
            {
                HttpContext.Current.Session["UserName"] = value;
            }
        }

        public static bool? UserIsConnected
        {
            get
            {
                bool? res = HttpContext.Current.Session["UserIsConnected"] as bool?;
                if (res.HasValue == false)
                    return false;
                else
                    return res;
            }
            set
            {
                HttpContext.Current.Session["UserIsConnected"] = value;
            }
        }
    }
}