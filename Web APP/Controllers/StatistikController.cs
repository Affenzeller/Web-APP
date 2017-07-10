using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_APP.Models;
using System.Web.Mvc;

namespace Web_APP.Controllers
{
    public class StatistikController : Controller
    {
        private datasevenEntities1 db = new datasevenEntities1();
        // GET: Statistik
        public ActionResult IndexStatistik()
        {
            StatistikModel sm = new StatistikModel();
            List<StatistikModel> sm_List = new List<StatistikModel>();

            sm.Filiale1 = "Filale";
            sm.Filiale2 = "Filale2";
            sm.Filiale3 = "Filale2";
            sm.Gruppe1 = "Gruppe1";
            sm.Gruppe2 = "Gruppe2";
            sm.Gruppe3 = "Gruppe3";
            sm.POS1 = "POS1";
            sm.POS2 = "POS2";
            sm.POS3 = "POS3";
            sm.Vergleich1 = false;
            sm.Vergleich2 = true;
            sm.Periode1 = DateTime.Today;
            sm.Periode2 = DateTime.UtcNow;
            sm.Periode3 = DateTime.Now;
            sm.Von = DateTime.Today;
            sm.Bis = DateTime.Today;


            //foreach (var item in db.stamm)
            //{
            //    sm = new StatistikModel();
            //    sm.Filiale1 = item.Filale1;
            //    sm.Filiale2 = item.Filale2;
            //    sm.Filiale3 = item.Filiale3;
            //    sm.Gruppe1 = item.Gruppe1;
            //    sm.Gruppe2 = item.Gruppe2;
            //    sm.Gruppe3 = item.Gruppe3;
            //    sm.POS1 = item.POS1;
            //    sm.POS2 = item.POS2;
            //    sm.POS3 = item.POS3;
            //    sm.Vergleich1 = item.Vergleich1;
            //    sm.Vergleich2 = item.Vergleich2;
            //    sm.Periode1 = item.Periode1;
            //    sm.Periode2 = item.Periode2;
            //    sm.Periode3 = item.Periode3;

            //    sm_List.Add(sm); 
            //}

            //sm = new StatistikModel();
            //sm.StatistikListe = new List<StatistikModel>();
            //sm.StatistikListe = sm_List;
            return View(sm);
        }
    }
}