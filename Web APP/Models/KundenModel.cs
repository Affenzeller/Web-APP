using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_APP.Models
{
    public class KundenModel
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
        public string Telefon1 //Festnetz Telefon
        {
            get; set;
        }
        public string Telefon2 //Handy
        {
            get; set;
        }
        public string Telefon3 //Fax
        {
            get; set;
        }
        public string Kassa
        {
            get; set;
        }
        public string Beruf
        {
            get; set;
        }
        public string Email
        {
            get; set;
        }


        public List<KundenModel> StammKundenListe
        {
            get; set;
        }
    }
}