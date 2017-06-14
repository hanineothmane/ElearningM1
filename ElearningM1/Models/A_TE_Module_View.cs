using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElearningM1.Models
{
    public class A_TE_Module_View 
    {
        
        public List<Apprenant> Apprenant { get; set; }

        public List<TuteurEnseignant> Te { get; set; }
        public List<Module> Module { get; set; }

        public List<Examen> Examen { get; set; }

        public List<Semestre> Semestre { get; set; }

    }
}