using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_APP.Models
{
    public class TestModel
    {

        public int Id
        {
            get; set;
        }
        public string Vorname
        {
            get; set;
        }
        public string Name
        {
            get; set;
        }
        public string Anrede
        {
            get; set;
        }
        public string Straße
        {
            get; set;
        }
        public string PLZ
        {
            get; set;
        }
        public string Ort
        {
            get; set;
        }
        public DateTime? Gebdat
        {
            get; set;
        }
        public string Telefon //Festnetz Telefon
        {
            get; set;
        }
        public string Telefon1 //Handy
        {
            get; set;
        }
        public string Telefon2 //Fax
        {
            get; set;
        }


        public List<TestModel> Stammliste
        {
            get; set;
        }

        public class PagingInfo
        {
            public int TotalItems
            {
                get; set;
            }
            public int ItemsPerPage
            {
                get; set;
            }
            public int CurrentPage
            {
                get; set;
            }
            public int TotalPages
            {
                get
                {
                    return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
                }
            }
        }
        //public class QuestionsListViewModel
        //{
        //    public IEnumerable<Question> Questions
        //    {
        //        get; set;
        //    }
        //    public PagingInfo PagingInfo
        //    {
        //        get; set;
        //    }
        //}
    }
}