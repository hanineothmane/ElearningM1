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
    public static class Modules
    {
        public static List<Module> getModules()
        {

            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User Id=postgres;Password=root;Database=elearningM1;port=5433");

            DataTable MyData = new DataTable();
            NpgsqlDataAdapter da;

            conn.Open();
            string select = "SELECT * FROM \"Module\"";
            NpgsqlCommand MyCmd = new NpgsqlCommand(select, conn);
            da = new NpgsqlDataAdapter(MyCmd);
            da.Fill(MyData);
            conn.Close();



            List<Module> module = MyData.AsEnumerable().Select(row =>

                new Module(row.Field<int>("id_module"),row.Field<string>("nom"), row.Field<double>("coef"), row.Field<string>("typemodule"))
                {
                    Id = row.Field<int>("id_module"),
                    Nom = row.Field<string>("nom"),
                    Coeff = row.Field<double>("coef"),
                    TypeModule = row.Field<String>("typemodule")

                }

            ).ToList();
            module.Cast<Module>();
        


            return module;
            
        }

        
    }
}