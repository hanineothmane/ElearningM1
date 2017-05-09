using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElearningM1.Models
{
    public class TuteurEnseignant
    {
        public int id { get; set; }
        public String nom { get; set; }
        public String prenom { get; set; }

        public List<Models.Apprenant> ListApprenant { get; set; }
    }
}