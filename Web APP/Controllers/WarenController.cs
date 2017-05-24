using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_APP.Controllers
{
    public class WarenController : Controller
    {
        // GET: Waren
        public ActionResult IndexWaren()
        {
            return View();
        }
    }
}