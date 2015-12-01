using FinalMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleAuthentification.Controllers
{
    public class CustomLoginController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string userName, string password)
        {
            SessionState.UserIsConnected = true;
            SessionState.UserName = userName;

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Disconnect()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Disconnect(string resultat)
        {
            if (resultat == "Oui")
            {
                SessionState.UserIsConnected = false;
                SessionState.UserName = null;
            }

            return RedirectToAction("Index", "Home");
        }
    }
}