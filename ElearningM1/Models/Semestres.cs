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
    public static class Semestres
    {
        public static List<Semestre> getAllSemestre()
        {
            string select = "SELECT * FROM \"Semestre\" ORDER BY numero_semestre";
            List<Semestre> semestre = BDD.Execute(select).AsEnumerable().Select(row =>
                new Semestre()
                {
                    Id = row.Field<int>("id_semestre"),
                    NumSemestre = row.Field<int>("numero_semestre"),
                    DateDebut = row.Field<string>("date_debut"),
                    DateFin = row.Field<string>("date_fin")
                }
            ).ToList();
            semestre.Cast<Semestre>();
            return semestre;
        }

        public static void AddSemestre(Semestre s)
        {
            string select = "SELECT inserer_semestre(" + s.NumSemestre + ",'" + s.DateDebut + "', '" + s.DateFin + "')";
            BDD.ExecuteNonQuery(select);
        }

        public static void UpdateSemestre(Semestre s)
        {
            string select = "SELECT modifier_semestre(" + s.Id + "," + s.NumSemestre + ",'" + s.DateDebut + "', '" + s.DateFin + "')";
            BDD.ExecuteNonQuery(select);
        }
    }
}