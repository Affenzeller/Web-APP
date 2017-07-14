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
            StatistikModel sm;
            //Aus TestModel die Liste holen und tm_List benenen
            List<StatistikModel> sm_List = new List<StatistikModel>();
            //foreach holt items aus db.stamm (Datenbank + welche tabelle)
            foreach (var item in db.stamm)
            {   //tm wird als neues TestModel befüllt (um alle vordifinierten Felder mit zu nehmen)
                sm = new StatistikModel();
                //tm.id mit dem item.id füllen
                sm.Id = item.id;
                sm.Name = item.name;
                sm.Vorname = item.vorname;
                //sm.Anrede = item.anrede;
                //sm.Gebdat = item.gebdat; //DateTime? Problem?
                //sm.Ort = item.ort;
                //sm.PLZ = item.plz;
                //sm.Straße = item.strasse;
                //sm.Telefon1 = item.telefon1; //Festnetz Telefon
                //sm.Telefon2 = item.telefon2; //Handy
                //sm.Telefon3 = item.telefon3; //Fax
                //sm.Kassa = item.kasse;
                //sm.Beruf = item.beruf;
                //sm.Email = item.mailkenn;

                sm_List.Add(sm);
            }
            //Erzeuge wieder ein neues TestModel
            sm = new StatistikModel();
            //nim vom TestModel die Liste (id, vorname, nachname) und mach daraus eine neue Liste vom TestModel
            sm.StatistikListe = new List<StatistikModel>();
            //befülle die TestModel<Liste>(id, vorname, nachname) mit der Liste von tm_List
            sm.StatistikListe = sm_List;
            //Schicke 
            return View(sm);
        }
    }
}