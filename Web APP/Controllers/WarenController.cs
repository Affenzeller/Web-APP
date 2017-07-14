using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_APP.Models;

namespace Web_APP.Controllers
{
    public class WarenController : Controller
    {
        private datasevenEntities1 db = new datasevenEntities1();
        // GET: Waren
        public ActionResult IndexWaren()
        {
            WarenModel wm;
            //Aus TestModel die Liste holen und tm_List benenen
            List<WarenModel> wm_List = new List<WarenModel>();
            //foreach holt items aus db.stamm (Datenbank + welche tabelle)
            foreach (var item in db.stamm)
            {   //tm wird als neues TestModel befüllt (um alle vordifinierten Felder mit zu nehmen)
                wm = new WarenModel();
                //tm.id mit dem item.id füllen
                wm.Id = item.id;
                wm.Name = item.name;
                wm.Vorname = item.vorname;
                wm.Anrede = item.anrede;
                wm.Gebdat = item.gebdat; //DateTime? Problem?
                wm.Ort = item.ort;
                wm.PLZ = item.plz;
                wm.Straße = item.strasse;
                wm.Telefon1 = item.telefon1; //Festnetz Telefon
                wm.Telefon2 = item.telefon2; //Handy
                wm.Telefon3 = item.telefon3; //Fax
                wm.Kassa = item.kasse;
                wm.Beruf = item.beruf;
                wm.Email = item.mailkenn;

                wm_List.Add(wm);
            }
            //Erzeuge wieder ein neues TestModel
            wm = new WarenModel();
            //nim vom TestModel die Liste (id, vorname, nachname) und mach daraus eine neue Liste vom TestModel
            wm.StammWarenListe = new List<WarenModel>();
            //befülle die TestModel<Liste>(id, vorname, nachname) mit der Liste von tm_List
            wm.StammWarenListe = wm_List;
            //Schicke 
            return View(wm);
        }
    }
}