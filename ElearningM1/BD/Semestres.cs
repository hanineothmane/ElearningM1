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
            Dictionary<string, Object> dico = new Dictionary<string, Object>()
            {
                {"@numero_semestre", s.NumSemestre},
                {"@date_debut", s.DateDebut},
                {"@date_fin", s.DateFin}
            };
            BDD.ExecuteNonQueryPS("inserer_semestre", dico);
        }

        public static void UpdateSemestre(Semestre s)
        {
            Dictionary<string, Object> dico = new Dictionary<string, Object>()
            {
                {"@id_s", s.NumSemestre},
                {"@num_s", s.NumSemestre},
                {"@date_d", s.DateDebut},
                {"@date_f", s.DateFin}
            };
            BDD.ExecuteNonQueryPS("inserer_semestre", dico);
        }
    }
}