using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Web_APP.Models.Model1.edmx.Model1.tt;
using Web_APP.Models;

namespace Web_APP.Controllers
{
    public class TestController : Controller
    {
        //private Model1Entities db = new Model1Entities();


        // GET: Test
        public ActionResult Index()
        {
            TestModel TM = new TestModel();

            Model1Entities db = new Model1Entities();

            List<Model1Entities> meList = new List<Model1Entities>();

            datasevenEntities1 dse = new datasevenEntities1();

            dse.stamm.Where(x => x.id == 100001).ToList();

       




            return View(dse.stamm.Where(x => x.id == 100001).ToList());
        }
    }
}