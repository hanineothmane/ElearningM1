using ElearningM1.BD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ElearningM1.Models
{
    public static class Affecter_A_Modules
    {
        public static List<Affecter_A_Module> getAffectations(Apprenant a)
        {
            string select = "select \"Affecter_A_Module\".note_final, \"Module\".id_module, \"Apprenant\".id_apprenant from \"Apprenant\", \"Module\", \"Affecter_A_Module\" where \"Apprenant\".id_apprenant = \"Affecter_A_Module\".id_apprenant and \"Affecter_A_Module\".id_module = \"Module\".id_module and \"Affecter_A_Module\".id_apprenant = " + a.Id + "";
            List<Affecter_A_Module> affectation = BDD.Execute(select).AsEnumerable().Select(row =>
                new Affecter_A_Module()
                {
                    NoteFinale = row.Field<Nullable<double>>("note_final"),
                    Module = Modules.getModules().FirstOrDefault(c => c.Id == row.Field<int>("id_module")),
                    Apprenant = Apprenants.getApprenants().FirstOrDefault(c => c.Id == row.Field<int>("id_apprenant")),
                }
            ).ToList();
            affectation.Cast<Affecter_A_Module>();
            return affectation;
        }

        public static void AddNote(Affecter_A_Module aff)
        {
            Dictionary<string, Object> dico = new Dictionary<string, Object>()
            {
                {"@id_a", aff.Apprenant.Id},
                {"@id_m", aff.Module.Id},
                {"@nf", aff.NoteFinale}
            };
            BDD.ExecuteNonQueryPS("ajouter_note", dico);
        }
    }
}