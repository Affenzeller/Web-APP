using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_APP.Models
{
    public class StatistikModel
    {
        public StatistikModel()
        {
            FilialenOptionen = new SelectList(new[] { Filiale1, Filiale2, Filiale3 });
            GruppenOptionen = new SelectList(new[] { "Gruppe1", "Gruppe2", "Gruppe3" });
            POSOptionen = new SelectList(new[] { "POS1", "POS2", "POS3" });
            VergleichOptionen = new SelectList(new[] { "Vergleich1", "Vergleich2" });
            PeriodeOptionen = new SelectList(new[] { "Periode1", "Periode2", "Periode3" });
        }
        public SelectList FilialenOptionen
        {
            get; set;
        }
        public SelectList GruppenOptionen
        {
            get; set;
        }
        public SelectList POSOptionen
        {
            get; set;
        }
        public SelectList VergleichOptionen
        {
            get; set;
        }
        public SelectList PeriodeOptionen
        {
            get; set;
        }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? Von
        {
            get; set;
        }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? Bis
        {
            get; set;
        }
        public string Filiale1
        {
            get; set;
        }
        public string Filiale2
        {
            get; set;
        }
        public string Filiale3
        {
            get; set;
        }
        public string Gruppe1
        {
            get; set;
        }
        public string Gruppe2
        {
            get; set;
        }
        public string Gruppe3
        {
            get; set;
        }
        public string POS1
        {
            get; set;
        }
        public string POS2
        {
            get; set;
        }
        public string POS3
        {
            get; set;
        }
        public bool Vergleich1
        {
            get; set;
        }
        public bool Vergleich2
        {
            get; set;
        }
        public  DateTime Periode1
        {
            get; set;
        }
        public DateTime Periode2
        {
            get; set;
        }
        public DateTime Periode3
        {
            get; set;
        }

        public List<StatistikModel> StatistikListe
            {
    get; set;
            }


}
}