using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ElearningM1.Models;
using Npgsql;
using NpgsqlTypes;
using System.Data;
using System.Web.Mvc;

namespace ElearningM1.Models
{
    public class Modules
    {
        public List<Module> getModules()
        {

            BDD.Initialize();

            DataTable MyData = new DataTable();
            NpgsqlDataAdapter da;

            BDD.Open();
            string select = "SELECT * FROM \"Module\"";
            NpgsqlCommand MyCmd = new NpgsqlCommand(select, BDD.Connexion());
            da = new NpgsqlDataAdapter(MyCmd);
            da.Fill(MyData);
            BDD.Close();



            List<Module> module = MyData.AsEnumerable().Select(row =>

                new Module(row.Field<string>("nom"), row.Field<double>("coeff"), row.Field<bool>("estNational"),null)
                {

                    Nom = row.Field<string>("nom"),
                    Coeff = row.Field<double>("coeff"),
                    EstNational = row.Field<bool>("estNational"),

                }

            ).ToList();
            module.Cast<Module>();
        


            return module;
            
        }

        
    }
}