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
using System.Security.Cryptography;


namespace ElearningM1.Models
{
    public static class RespPedagogiques
    {

        public static List<RespPedagogique> getRPs()
        {
            string select = "SELECT * FROM \"RP\" ORDER BY nom";
            return BDD.Execute(select).AsEnumerable().Select(row =>
                new RespPedagogique()
                {
                    Nom = row.Field<string>("nom"),
                    Prenom = row.Field<string>("prenom"),
                    DateNaiss = row.Field<string>("datenaissance"),
                    Id = row.Field<int>("id_rp"),
                    Email = row.Field<string>("email"),
                    Adresse = row.Field<string>("adresse"),
                    Mdp = row.Field<String>("mdp"),
                    Telephone = row.Field<string>("telephone"),
                }
            ).ToList();
        }

        public static void Aff_A_Module(int id_module , int id_A)
        {
            string select = "Insert Into \"Affecter_A_Module\"(id_module,id_apprenant) Values(" + id_module + "," + id_A + ") ";
            BDD.ExecuteNonQuery(select);
        }

        public static void Aff_A_Te(int id_app, int id_tuteur)
        {
            string select = "Insert Into \"Affecter_A_TE\"(id_apprenant,id_te) Values(" + id_app + "," + id_tuteur + ") ";
            BDD.ExecuteNonQuery(select);
        }

        public static void Aff_Module_Semestre(int id_semestre, int id_module)
        {
            string select = "Insert Into \"Affecter_Module_Semestre\"(id_semestre,id_module) Values(" + id_semestre + "," + id_module + ") ";
            BDD.ExecuteNonQuery(select);
        }
        
        public static void Aff_A_Exam(int id_app, int id_exam)
        {

     
            string select = "Insert Into \"Affecter_A_Examen\"(id_apprenant,id_examen,note_examen) Values(" + id_app + "," + id_exam + ",NULL) ";

            BDD.ExecuteNonQuery(select);
        }

        public static string Utilisateur_Nom
        {
            get
            {
                if (HttpContext.Current.Session["nom_utlisateur"] != null)
                    return HttpContext.Current.Session["nom_utlisateur"].ToString();
                else
                    return null;
            }
            set { HttpContext.Current.Session["nom_utlisateur"] = value; }
        }

        public static void AddRP(Profil te)
        {
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
            BDD.ExecuteNonQueryPS("inserer_rp", dico);
        }

        public static void DeleteRP(RespPedagogique rp)
        {
            Dictionary<string, Object> dico = new Dictionary<string, Object>()
            {
                {"@id_r", rp.Id},
            };
            BDD.ExecuteNonQueryPS("supprimer_rp", dico);
        }

        public static void UpdateRP(RespPedagogique rp)
        {
            Dictionary<string, Object> dico = new Dictionary<string, Object>()
            {
                {"@id_r", rp.Id},
                {"@n", rp.Nom},
                {"@p", rp.Prenom},
                {"@adr", rp.Adresse},
                {"@tel", rp.Telephone},
                {"@datenaiss", rp.DateNaiss},
                {"@mail", rp.Email},
                {"@pass",  BDD.GenerateMD5(rp.Mdp)}
            };
            BDD.ExecuteNonQueryPS("modifier_rp", dico);
        }
    }
}
