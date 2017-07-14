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
            var connection = new Npgsql.NpgsqlConnection(ConfigurationManager.ConnectionStrings["datasevenEntitiesADO"].ToString());

            connection.Open();
            var trans = connection.BeginTransaction();

            var command = new Npgsql.NpgsqlCommand("pStammAnzeigen", connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };

            var da = new Npgsql.NpgsqlDataAdapter(command);
            var ds = new DataSet();
            da.Fill(ds);

            trans.Commit();
            connection.Close();

            DataTable firstTable = new DataTable();
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

            connection.Open(); // Invalid Operation
            var trans = connection.BeginTransaction();

            var command = new Npgsql.NpgsqlCommand("fstammfiltern", connection) //Invalid Operationen
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };

            command.Parameters.AddWithValue("vn", vn);
            command.Parameters.AddWithValue("nn", nn);

            var da = new Npgsql.NpgsqlDataAdapter(command);
            var ds = new DataSet();

            da.Fill(ds);
            trans.Commit();
            connection.Close();
            DataTable secoundTable = new DataTable();
            firstTable = ds.Tables[0];

            return firstTable;
            // Count 0? return fistTable
        }
    }
}