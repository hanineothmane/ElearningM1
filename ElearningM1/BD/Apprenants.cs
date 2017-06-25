using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using ElearningM1.BD;

namespace ElearningM1.Models
{
    public static class Apprenants
    {
        public static List<Apprenant> getApprenants()
        {

            string select = "SELECT * FROM \"Apprenant\" ORDER BY nom";

            return BDD.Execute(select).AsEnumerable().Select(row =>

                new Apprenant()
                {
                    Id = row.Field<int>("id_apprenant"),
                    Nom = row.Field<String>("nom"),
                    Prenom = row.Field<String>("prenom"),
                    DateNaiss = row.Field<String>("datenaissance"),
                    Email = row.Field<String>("email"),
                    Telephone = row.Field<String>("telephone"),
                    Adresse = row.Field<String>("adresse"),
                    DateInscription = row.Field<String>("dateinscription"),
                }

            ).ToList();
        }

        public static List<Apprenant> getApprenant(int id)
        {
            string select = "SELECT * FROM \"Apprenant\" WHERE id_apprenant =" + id;
            List<Apprenant> app = BDD.Execute(select).AsEnumerable().Select(row =>
                new Apprenant()
                {
                    Id = row.Field<int>("id"),
                    Nom = row.Field<String>("nom"),
                    Prenom = row.Field<String>("prenom"),
                    DateNaiss = row.Field<String>("datenaissance"),
                    Telephone = row.Field<String>("telephone"),
                    Adresse = row.Field<String>("adresse")
                }
            ).ToList();
            app.Cast<Apprenant>();
            return app;
        }

        public static void AddApprenant(Apprenant a)
        {
            Dictionary<string, Object> dico = new Dictionary<string, Object>()
            {
                {"@nom", a.Nom},
                {"@prenom", a.Prenom},
                {"@adresse", a.Adresse},
                {"@telephone", a.Telephone},
                {"@datenaissance", a.DateNaiss},
                {"@email", a.Email},
                {"@dateinscription", a.DateInscription}
            };
            BDD.ExecuteNonQueryPS("inserer_apprenant", dico);
        }

        public static void Update(Apprenant a)
        {
            Dictionary<string, Object> dico = new Dictionary<string, Object>()
            {
                {"@id_a", a.Id},
                {"@n", a.Nom},
                {"@p", a.Prenom},
                {"@adr", a.Adresse},
                {"@tel", a.Telephone},
                {"@datenaiss", a.DateNaiss},
                {"@e", a.Email},
                {"@dateinsc", a.DateInscription}
            };
            BDD.ExecuteNonQueryPS("modifier_apprenant", dico);
        }
    }
}