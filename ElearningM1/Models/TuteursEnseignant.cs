﻿using System;
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
    public class TuteursEnseignant
    {
        public List<TuteurEnseignant> getTuteursEnseignant()
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User Id=postgres;Password=wassim;Database=postgres;port=5432");

            DataTable MyData = new DataTable();
            NpgsqlDataAdapter da;

            conn.Open();
            string select = "SELECT * FROM \"Utilisateur\"";
            NpgsqlCommand MyCmd = new NpgsqlCommand(select, conn);
            da = new NpgsqlDataAdapter(MyCmd);
            da.Fill(MyData);
            conn.Close();



            List<TuteurEnseignant> te = MyData.AsEnumerable().Select(row =>

                new TuteurEnseignant(row.Field<string>("nom"), row.Field<string>("dateNaiss"), row.Field<string>("prenom"), row.Field<string>("courriel"), row.Field<int>("id"), row.Field<string>("mdp"), row.Field<string>("telephone"), row.Field<string>("adresse"))
                {

                    Nom = row.Field<string>("nom"),
                    Prenom = row.Field<string>("prenom"),
                    DateNaiss = row.Field<string>("dateNaiss"),
                    Courriel = row.Field<string>("courriel"),
                    Telephone = row.Field<string>("telephone"),


                }

            ).ToList();
            te.Cast<TuteurEnseignant>();



            return te;
        }
    }
}