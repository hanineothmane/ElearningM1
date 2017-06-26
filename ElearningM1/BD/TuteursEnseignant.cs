using System;
using System.Collections.Generic;
using System.Linq;
using Npgsql;
using System.Data;
using ElearningM1.BD;

namespace ElearningM1.Models
{
    public static class TuteursEnseignant
    {
        public static List<TuteurEnseignant> getTuteursEnseignant()
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

        public static List<TuteurEnseignant> getInfoTE(int id)
        {
            string select = "SELECT * FROM \"TE\" WHERE id_te =" + id;
            List<TuteurEnseignant> te = BDD.Execute(select).AsEnumerable().Select(row =>
                new TuteurEnseignant()
                {
                    Id = row.Field<int>("id_te"),
                    Nom = row.Field<String>("nom"),
                    Prenom = row.Field<String>("prenom"),
                    DateNaiss = row.Field<String>("datenaissance"),
                    Email = row.Field<String>("email"),
                    Mdp = row.Field<String>("mdp"),
                    Telephone = row.Field<String>("telephone"),
                    Adresse = row.Field<String>("adresse")
                }
            ).ToList();
            te.Cast<TuteurEnseignant>();
            return te;
        }

        public static List<Apprenant> getAllApprenant(int id_te)
        {

           
            string requete2 = "SELECT * FROM \"Apprenant\" where id_apprenant in (select id_apprenant from \"Affecter_A_TE\" where id_te = "+ id_te+ ")";
            //NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User Id=postgres;Password=root;Database=elearningM1;port=5433");
            BDD.Initialize();
            DataTable MyData = new DataTable();
            NpgsqlDataAdapter da;

            BDD.Open();
           
            NpgsqlCommand MyCmd = new NpgsqlCommand(requete2, BDD.Connexion());
            da = new NpgsqlDataAdapter(MyCmd);
            da.Fill(MyData);
            BDD.Connexion().Close();

            List<Apprenant> apprenant = MyData.AsEnumerable().Select(row =>

              new Apprenant()
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

        public static void AddTE(Profil te)
        {
           //string requette = "Insert Into \"TE\"(nom,prenom,adresse,telephone,datenaissance,email,mdp) Values(" + te.Nom+ "," + te.Prenom + "," + te.Adresse + "," + te.Telephone + "," + te.DateNaiss + "," + te.Email + "," + te.Mdp + ") ";
            Dictionary<string, Object> dico = new Dictionary<string, Object>()
            {
                
                {"@nom", te.Nom},
                {"@prenom", te.Prenom},
                {"@adresse", te.Adresse},
                {"@telephone", te.Telephone},
                {"@datenaissance", te.DateNaiss},
                {"@email", te.Email},
                {"@mdp", BDD.GenerateMD5(te.Mdp)}
            };
            BDD.ExecuteNonQueryPS("inserer_te", dico);
            //BDD.Execute(requette);
        }

        public static void UpdateTE(TuteurEnseignant te)
        {
            Dictionary<string, Object> dico = new Dictionary<string, Object>()
            {
                {"@id_t", te.Id},
                {"@n", te.Nom},
                {"@p", te.Prenom},
                {"@adr", te.Adresse},
                {"@tel", te.Telephone},
                {"@datenaiss", te.DateNaiss},
                {"@mail", te.Email},
                {"@pass",  BDD.GenerateMD5(te.Mdp)}
            };
            BDD.ExecuteNonQueryPS("modifier_te", dico);
        }

        public static List<Module> getModuleAffecterTe(int id_te)
        {
           
            string select =  "Select * from \"Module\" where id_te = " + id_te ;
            

            List<Module> module = BDD.Execute(select).AsEnumerable().Select(row =>

            new Module()
            {
                Id = row.Field<int>("id_module"),
                Nom = row.Field<string>("nom"),
                DateCreation = row.Field<string>("datecreation"),
                Coef = row.Field<Double>("coef"),
                TypeModule = row.Field<string>("typemodule")
            }

          ).ToList();
            return module;
        }
        
    }
}