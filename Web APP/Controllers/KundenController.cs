using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Web_APP.Helper;
using Web_APP.Models;

namespace Web_APP.Controllers
{
    public class KundenController : Controller
    {
        private datasevenEntities1 db = new datasevenEntities1();
        // GET: Kunden
        public ActionResult IndexKunden()
        {
            //TestModel in tm benenen
            KundenModel km;
            //Aus TestModel die Liste holen und tm_List benenen
            List<KundenModel> km_List = new List<KundenModel>();
            //foreach holt items aus db.stamm (Datenbank + welche tabelle)
            foreach (var item in db.stamm)
            {   //tm wird als neues TestModel befüllt (um alle vordifinierten Felder mit zu nehmen)
                km = new KundenModel();
                //tm.id mit dem item.id füllen
                km.Id = item.id;
                km.Name = item.name;
                km.Vorname = item.vorname;
                km.Anrede = item.anrede;
                km.Gebdat = item.gebdat; //DateTime? Problem?
                km.Ort = item.ort;
                km.PLZ = item.plz;
                km.Straße = item.strasse;
                km.Telefon1 = item.telefon1; //Festnetz Telefon
                km.Telefon2 = item.telefon2; //Handy
                km.Telefon3 = item.telefon3; //Fax
                km.Kassa = item.kasse;
                km.Beruf = item.beruf;
                km.Email = item.mailkenn;

                km_List.Add(km);
            }
            //Erzeuge wieder ein neues TestModel
            km = new KundenModel();
            //nim vom TestModel die Liste (id, vorname, nachname) und mach daraus eine neue Liste vom TestModel
            km.StammKundenListe = new List<KundenModel>();
            //befülle die TestModel<Liste>(id, vorname, nachname) mit der Liste von tm_List
            km.StammKundenListe = km_List;
            //Schicke 
            return View(km);
        }

        [HttpPost] //KundenSuche
        public ActionResult IndexKunden(string _SearchString, KundenModel km)
        {
            SQL_Helper sql_Helper = new SQL_Helper();

            if (_SearchString != null)
            {
                //Aus TestModel die Liste holen und tm_List benenen
                List<KundenModel> km_List = new List<KundenModel>();
                //foreach holt items aus db.stamm (Datenbank + welche tabelle)

                DataTable dt = new DataTable();

                dt = sql_Helper.SearchKunden(_SearchString);

                Debug.WriteLine("Anzahl der Rows: " + dt.Rows.Count);

                foreach (DataRow _row in dt.Rows)
                {   //tm wird als neues TestModel befüllt (um alle vordifinierten Felder mit zu nehmen)

                    km = new KundenModel();
                    km.Name = _row["name"].ToString();
                    km.Vorname = _row["vorname"].ToString();

                    km_List.Add(km);
                }

               KundenFilterModel kfm = new KundenFilterModel();
                //nim vom TestModel die Liste (id, vorname, nachname) und mach daraus eine neue Liste vom TestModel
                kfm.StammKundenFilterListe = new List<KundenModel>();
                //befülle die TestModel<Liste>(id, vorname, nachname) mit der Liste von tm_List
                kfm.StammKundenFilterListe = km_List;

                //return View("~/View/Kunden/IndexKunden.cshtml", km);
                //if (ModelState.IsValid)
                //{
                //    return RedirectToAction("IndexKunde", "Kunden");
                //}

                ModelState.Clear();
                return RedirectToAction("SearchKunden", "Kunden",kfm);
                //!Fehler! Richtiges Verändertes Model (Für die Kunden Suche) Wird rüber geschickt zur View !Fehler!
                //!Fehler! Zu einer völlig unberührten View wo noch nichts erstellt ist. Wo die Foreach     !Fehler!
                //!Fehler! auch die richtigen einträge macht, Jedoch wird trozdem das Alte Model angezeigt  !Fehler!

               //return RedirectToAction("IndexKunde", "Kunden");
            }
            else
            {
                km = new KundenModel();
                km.StammKundenListe = new List<KundenModel>();

                return View(km);
            } 
        }

        //[HttpPost]
        //public ActionResult IndexKunden(KundenModel km)
        //{
        //    List<KundenModel> km_List = new List<KundenModel>();

        //    datasevenEntities1 context = new datasevenEntities1();
        //    var query = from stamm in context.stamm
        //                where stamm.vorname == km.Vorname      
        //                select stamm;



        //    foreach (Web_APP.Models.stamm item in query)
        //    {  

        //        //tm wird als neues TestModel befüllt (um alle vordifinierten Felder mit zu nehmen)
        //        km = new KundenModel();
        //        //tm.id mit dem item.id füllen
        //        km.Id = item.id;
        //        km.Name = item.name;
        //        km.Vorname = item.vorname;
        //        km.Anrede = item.anrede;
        //        km.Gebdat = item.gebdat; //DateTime? Problem?
        //        km.Ort = item.ort;
        //        km.PLZ = item.plz;
        //        km.Straße = item.strasse;
        //        km.Telefon1 = item.telefon1; //Festnetz Telefon
        //        km.Telefon2 = item.telefon2; //Handy
        //        km.Telefon3 = item.telefon3; //Fax
        //        km.Kassa = item.kasse;
        //        km.Beruf = item.beruf;
        //        km.Email = item.mailkenn;

        //        km_List.Add(km);
        //    }

        //    //Erzeuge wieder ein neues TestModel
        //   KundenModel test = new KundenModel();
        //    //nim vom TestModel die Liste (id, vorname, nachname) und mach daraus eine neue Liste vom TestModel
        //    test.StammKundenListe = new List<KundenModel>();
        //    //befülle die TestModel<Liste>(id, vorname, nachname) mit der Liste von tm_List
        //    test.StammKundenListe = km_List;
        //    //Schicke 
        //    return View(test);
        //}
    }
}