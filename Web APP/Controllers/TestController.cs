using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Web_APP.Models;
using System.Configuration;
using Web_APP.Helper;
using System.Data;
using System.Diagnostics;


namespace Web_APP.Controllers
{
    public class TestController : Controller
    {
        // Datenbank reinholen und als db benenen
        private datasevenEntities1 db = new datasevenEntities1();

        // GET: Test
        public ActionResult IndexTest()
        {
            //TestModel in tm benenen
            TestModel tm;
            //Aus TestModel die Liste holen und tm_List benenen
            List<TestModel> tm_List = new List<TestModel>();
            //foreach holt items aus db.stamm (Datenbank + welche tabelle)
            foreach (var item in db.stamm)
            {   //tm wird als neues TestModel befüllt (um alle vordifinierten Felder mit zu nehmen)
                tm = new TestModel();
                //tm.id mit dem item.id füllen
                tm.Id = item.id;
                tm.Name = item.name;
                tm.Vorname = item.vorname;
                tm.Anrede = item.anrede;
                tm.Gebdat = item.gebdat; //DateTime? Problem?
                tm.Ort = item.ort;
                tm.PLZ = item.plz;
                tm.Straße = item.strasse;
                tm.Telefon = item.telefon; //Festnetz Telefon
                tm.Telefon1 = item.telefon1; //Handy
                tm.Telefon2 = item.telefon2; //Fax
                
                tm_List.Add(tm);
            }     
            //Erzeuge wieder ein neues TestModel
            tm = new TestModel();
            //nim vom TestModel die Liste (id, vorname, nachname) und mach daraus eine neue Liste vom TestModel
            tm.Stammliste = new List<TestModel>();
            //befülle die TestModel<Liste>(id, vorname, nachname) mit der Liste von tm_List
            tm.Stammliste = tm_List;
            //Schicke 
            return View(tm);
        }
        //public ViewResult Questions(int page = 1)
        //{
        //    QuestionsListViewModelmodel = new QuestionsListViewModel
        //    {
        //        // we need to get all items till now to render again 
        //        Questions = repository.Questions
        //                              .Take(page * PageSize),
        //        PagingInfo = new PagingInfo
        //        {
        //            CurrentPage = page,
        //            ItemsPerPage = 25,
        //            TotalItems = repository.Questions.Count()
        //        }
        //    };

        //    return View(model);
        //}

        public ActionResult Bla()
        {
            return View();
        }
    }
   
    }