﻿using ElearningM1.BD;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ElearningM1.Models
{
    public class Examens
    {

        public static List<Examen> getExamens()
        {
            string select = "SELECT * FROM \"Examen\"";
            return BDD.Execute(select).AsEnumerable().Select(row =>
                new Examen()
                {
                    Id = row.Field<int>("id_examen"),
                    Type = row.Field<string>("type_examen"),
                    Date = row.Field<string>("date"),
                    LeModule = Modules.getModules().FirstOrDefault(m => m.Id == row.Field<int>("id_module"))
                }
            ).ToList();
        }

        public static void AddModule(Examen e)
        {
            Dictionary<string, Object> dico = new Dictionary<string, Object>()
            {
                {"@type_examen", e.Type},
                {"@date", e.Date},
                {"@id_module", e.LeModule.Id}
            };
            BDD.ExecuteNonQueryPS("inserer_examen", dico);
        }

        public static void Update(Examen e)
        {
            Dictionary<string, Object> dico = new Dictionary<string, Object>()
            {
                {"@id_e", e.Type},
                {"@type_e", e.Type},
                {"@d", e.Date},
                {"@id_m", e.LeModule.Id}
            };
            BDD.ExecuteNonQueryPS("modifier_examen", dico);
        }

        public static void DeleteExamen(Examen e)
        {
            Dictionary<string, Object> dico = new Dictionary<string, Object>()
            {
                {"@id_e", e.Id},
            };
            BDD.ExecuteNonQueryPS("supprimer_examen", dico);
        }
    }


}

