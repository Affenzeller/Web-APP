using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Web_APP.Helper;
using Web_APP.Models;

namespace Web_APP.Controllers
{
    public class KundenController : Controller
    {
        private datasevenEntities1 db = new datasevenEntities1();

        public ActionResult IndexKunden()
        {
            KundenModel km = new KundenModel();
            km.StammKundenListe = new List<KundenModel>();
            List<KundenModel> km_List = new List<KundenModel>();
            foreach (var item in db.stamm)
            {
                km = new KundenModel();
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

            KundenModel nkm = new KundenModel();
            nkm.StammKundenListe = new List<KundenModel>();
            nkm.StammKundenListe = km_List;
            return View(nkm);
        }

        [HttpPost] 
        public ActionResult SearchKunden(string _SearchString, KundenModel km)
        {
            List <KundenModel> kfm_List = new List<KundenModel>();
            DataTable dt = new DataTable();
            SQL_Helper sql_Helper = new SQL_Helper();
            dt = sql_Helper.SearchKunden(_SearchString);
            foreach (DataRow _row in dt.Rows)
            {               
                km = new KundenModel();
                km.Name = _row["name"].ToString(); ;
                km.Vorname = _row["vorname"].ToString(); 
                kfm_List.Add(km);
            }
            KundenFilterModel kfm = new KundenFilterModel();              
            kfm.StammKundenFilterListe = new List<KundenModel>();      
            kfm.StammKundenFilterListe = kfm_List;
            //ModelState.Clear();
            return View("SearchKunden", kfm);
        }
    }
}