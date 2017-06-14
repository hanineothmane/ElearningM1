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
                    Id = row.Field<int>("id_module"),
                    Nom = row.Field<string>("nom"),
                    DateCreation = row.Field<string>("datecreation"),
                    Coef = row.Field<double>("coef"),
                    TypeModule = row.Field<string>("typemodule"),
                    Ens = TuteursEnseignant.getTuteursEnseignant().FirstOrDefault(c => c.Id == row.Field<int>("id_te")),
                    Sr = SessionsRegroupement.getSessionsRegroupement().FirstOrDefault(c => c.Id == row.Field<int>("id_session")),
                }
            ).ToList();
            module.Cast<Module>();
            return module;
        }

        public static List<Module> getModules(int id)
        {
            string select = "select \"Module\".* from \"Apprenant\", \"Module\", \"Affecter_A_Module\" where \"Apprenant\".id_apprenant = \"Affecter_A_Module\".id_apprenant and \"Affecter_A_Module\".id_module = \"Module\".id_module and \"Affecter_A_Module\".id_apprenant = " + id + "";
            List<Module> module = BDD.Execute(select).AsEnumerable().Select(row =>
                new Module()
                {
                    Id = row.Field<int>("id_module"),
                    Nom = row.Field<string>("nom"),
                    DateCreation = row.Field<string>("datecreation"),
                    Coef = row.Field<double>("coef"),
                    TypeModule = row.Field<string>("typemodule"),
                    Ens = TuteursEnseignant.getTuteursEnseignant().FirstOrDefault(c => c.Id == row.Field<int>("id_te")),
                    Sr = SessionsRegroupement.getSessionsRegroupement().FirstOrDefault(c => c.Id == row.Field<int>("id_session")),
                }
            ).ToList();
            module.Cast<Module>();
            return module;
        }

        public static void AddModule(Module m)
        {
            // string select = "INSERT INTO \"Module\" VALUES ('" + m.Nom + "'," + m.Coef + ",'" + m.EstNational + "', '')";
            string select = "SELECT inserer_module('" + m.Nom + "','" + m.DateCreation + "', " + m.Coef + ", '" + m.TypeModule + "', '" + m.Ens.Id + "' ,'" + m.Sr.Id + "' )";
            BDD.ExecuteNonQuery(select);
        }

        public static void Update(Module m)
        {
            string select = "SELECT modifier_module('" + m.Id + "','" + m.Nom + "','" + m.DateCreation + "', " + m.Coef + ", '" + m.TypeModule + "', '" + m.Ens.Id + "' ,'" + m.Sr.Id + "' )";
            BDD.ExecuteNonQuery(select);
        }


    }
}