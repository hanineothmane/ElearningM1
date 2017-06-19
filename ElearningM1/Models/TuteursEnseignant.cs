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
    public static class TuteursEnseignant
    {
        public List<TuteurEnseignant> getTuteursEnseignant()
        {
            
            string select = "SELECT * FROM \"TE\" ORDER BY nom";
            
            List<TuteurEnseignant> te = BDD.Execute(select).AsEnumerable().Select(row =>

                new TuteurEnseignant(row.Field<string>("nom"), row.Field<string>("datenaissance"), row.Field<string>("prenom"), row.Field<string>("email"), row.Field<int>("id_te"), row.Field<string>("mdp"), row.Field<string>("telephone"), row.Field<string>("adresse"))
                {
                    Nom = row.Field<string>("nom"),
                    Prenom = row.Field<string>("prenom"),
                    DateNaiss = row.Field<string>("datenaissance"),
                    Id = row.Field<int>("id_te"),
                    Email = row.Field<string>("email"),
                    Adresse = row.Field<string>("adresse"),
                    Mdp = row.Field<string>("mdp"),
                    Telephone = row.Field<string>("telephone"),
                }

            ).ToList();
            te.Cast<TuteurEnseignant>();



            return te;
        }

        public static List<Apprenant> getAllApprenant(int id_te)
        {

            String requette = "Select * from \"TE\" where id in(Select * from \"Affecter_A_Te\" where id_Te =" + id_te + ")";

            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User Id=postgres;Password=root;Database=elearningM1;port=5433");

            DataTable MyData = new DataTable();
            NpgsqlDataAdapter da;

            conn.Open();
           
            NpgsqlCommand MyCmd = new NpgsqlCommand(requette, conn);
            da = new NpgsqlDataAdapter(MyCmd);
            da.Fill(MyData);
            conn.Close();

            List<Apprenant> apprenant = MyData.AsEnumerable().Select(row =>

              new Apprenant(row.Field<string>("nom"), row.Field<string>("datenaissance"), row.Field<string>("prenom"), row.Field<int>("id_apprenant"), row.Field<string>("telephone"), row.Field<string>("adresse"), null)
              {
                  Id = row.Field<int>("id_apprenant"),
                  Nom = row.Field<string>("nom"),
                  Prenom = row.Field<string>("prenom"),
                  DateNaiss = row.Field<string>("datenaissance"),
                  Telephone = row.Field<string>("telephone"),
                  Adresse = row.Field<string>("adresse")

              }

            ).ToList();
            apprenant.Cast<Apprenant>();



            return apprenant;

           
        }
    }
}