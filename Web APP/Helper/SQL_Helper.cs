using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using Web_APP.Models;

namespace Web_APP.Helper
{
    public class SQL_Helper
    {
        public DataTable SelectStamm()
        {
            // ConnectionString
            var connection = new Npgsql.NpgsqlConnection(ConfigurationManager.ConnectionStrings["datasevenEntitiesADO"].ToString());

            // Verbindung öffnen
            connection.Open();
            var trans = connection.BeginTransaction();

            // Prozedur mittels Namen(Postgres DB) und Connection aufrufen
            var command = new Npgsql.NpgsqlCommand("pStammAnzeigen", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };

            //command.Parameters.AddWithValue("_filiale", 2);

            var da = new Npgsql.NpgsqlDataAdapter(command);
            var ds = new DataSet();
            // DataSet füllen
            da.Fill(ds);

            // Abfrage abschließen
            trans.Commit();
            // Verbindung schließen
            connection.Close();

            // Tabelle erzeugen
            DataTable firstTable = new DataTable();
            // erhaltene Daten Tabelle speichern
            return firstTable = ds.Tables[0];
        }

        public DataTable SearchKunden(string _SearchString)
        {
            DataTable firstTable = new DataTable();

            NpgsqlConnection connection = new Npgsql.NpgsqlConnection(ConfigurationManager.ConnectionStrings["datasevenEntitiesADO"].ToString());
            List<string> namenliste = new List<string>();
            string value = _SearchString;

            string[] substrings = new string[2];
            char delimiter = ' ';

            substrings = value.Split(delimiter); 

            foreach (var substring in substrings)
            {
                namenliste.Add(substring);
            }

            string vn = namenliste[0];
            string nn = namenliste[1];
            //string vn = "Lisa";
            //string nn = "Baumgartner";

            // Verbindung öffnen

            connection.Open(); // Invalid Operation
            var trans = connection.BeginTransaction();

            // Prozedur mittels Namen(Postgres DB) und Connection aufrufen
            var command = new Npgsql.NpgsqlCommand("fstammfiltern", connection) //Invalid Operationen
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };

            command.Parameters.AddWithValue("vn", vn);
            command.Parameters.AddWithValue("nn", nn);

            var da = new Npgsql.NpgsqlDataAdapter(command);

            var ds = new DataSet();

            // DataSet füllen
            da.Fill(ds);


            // Abfrage abschließen
            trans.Commit();
            // Verbindung schließen
            connection.Close();

            // Tabelle erzeugen
            DataTable secoundTable = new DataTable();
            // erhaltene Daten Tabelle speichern
            firstTable = ds.Tables[0];

            return firstTable;
        }
    }
}