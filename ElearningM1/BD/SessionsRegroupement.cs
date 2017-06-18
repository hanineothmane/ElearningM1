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
    }
}