using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_APP.Controllers
{
    public class LoginController : Controller
    {
        //1.Schritt Login
        public ActionResult Login()
        {
            //LoginModel test = new LoginModel();
            //ViewBag.IDKunde = new SelectList(dataseven.Login, "id", "name", "password");

            return View(
                //test
                );
        }
        //[HttpPost]
        //public ActionResult Login(id, name, password)
        //{
        //    return View();
        //}

        

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}