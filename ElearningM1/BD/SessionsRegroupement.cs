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
    public static class SessionsRegroupement
    {
        public static List<SessionRegroupement> getSessionsRegroupement()
        {

            string select = "SELECT * FROM \"SessionReg\" ORDER BY datesession";

            List<SessionRegroupement> sr = BDD.Execute(select).AsEnumerable().Select(row =>

                new SessionRegroupement()
                {
                    Id = row.Field<int>("id_session"),
                    Nom = row.Field<string>("nom"),
                    Date = row.Field<string>("datesession"),
                }

            ).ToList();
            sr.Cast<SessionRegroupement>();
            
            return sr;
        }

        public static void AddSessionReg(SessionRegroupement sr)
        {
            Dictionary<string, Object> dico = new Dictionary<string, Object>()
            {
                {"@nom", sr.Nom},
                {"@datesession", sr.Date}
            };
            BDD.ExecuteNonQueryPS("inserer_sr", dico);
        }

        public static void UpdateSessionReg(SessionRegroupement sr)
        {
            Dictionary<string, Object> dico = new Dictionary<string, Object>()
            {
                {"@id_s", sr.Id},
                {"@n", sr.Nom},
                {"@d", sr.Date}
            };
            BDD.ExecuteNonQueryPS("modifier_sr", dico);
        }

        public static void DeleteSessionReg(SessionRegroupement sr)
        {
            Dictionary<string, Object> dico = new Dictionary<string, Object>()
            {
                {"@id_s", sr.Id},
            };
            BDD.ExecuteNonQueryPS("supprimer_sr", dico);
        }
    }
}