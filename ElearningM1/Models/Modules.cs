using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ElearningM1.Models;
using Npgsql;
using NpgsqlTypes;
using System.Data;
using System.Web.Mvc;
using ElearningM1.BD;

namespace ElearningM1.Models
{
    public static class Modules
    {
        public static List<Module> getModules()
        {
            string select = "SELECT * FROM \"Module\" ORDER BY nom";
            List<Module> module = BDD.Execute(select).AsEnumerable().Select(row =>
                new Module()
                {
                    Id = row.Field<int>("id"),
                    Nom = row.Field<string>("nom"),
                    Coeff = row.Field<double>("coeff"),
                    EstNational = row.Field<bool>("estNational"),
                }
            ).ToList();
            module.Cast<Module>();
            return module;
        }

        public static void AddModule(Module m)
        {
            string select = "INSERT INTO \"Module\" VALUES ('" + m.Nom + "'," + m.Coeff + ",'" + m.EstNational + "', '')";
            BDD.ExecuteNonQuery(select);
        }

        public static void Update(Module m)
        {
            string select = "UPDATE \"Module\" SET nom='" + m.Nom + "', coeff=" + m.Coeff + ", estnational=" + m.EstNational + " WHERE id=" + m.Id + "";
            BDD.ExecuteNonQuery(select);
        }


    }
}