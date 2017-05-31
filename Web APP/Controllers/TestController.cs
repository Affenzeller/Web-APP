using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Web_APP.Models;

namespace Web_APP.Controllers
{
    public class TestController : Controller
    {
        private TestModel db = new TestModel();
        

        // GET: Test
        public ActionResult IndexTest()
        {
            stamm ST = new stamm();

            //tblMitarbeiter ma = db.tblMitarbeiter.Find(id);
            //stamm ST = db.stamm
            //MitarbeiterModel b = new MitarbeiterModel();
            // b.MAVorname = ma.MAVorname;
            //TM.vorname = stamm.
            // ViewBag.IDMitarbeiter = new SelectList(db.tblLogin, "IDLogin", "Email", ma.IDMitarbeiter);
            //ViewBag.idStamm = new SelectList(, ST.vorname, ST.name)

            ST.id = 1;
            ST.indikation = "dsd";
            ST.vorname = "Test VN";
            ST.name= "Test NN";

            return View(ST);
        }
    }
}