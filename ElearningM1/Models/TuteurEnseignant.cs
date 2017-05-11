using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElearningM1.Models
{
    public class TuteurEnseignant : Profil
    {
        private List<Module> lesModules;
        private string nom, dateNaiss, prenom, courriel, id, mdp, telephone;

        public TuteurEnseignant(string nom, string dateNaiss, string prenom, string courriel, string id, string mdp, string telephone) : base(nom, dateNaiss, prenom, courriel, id, mdp, telephone)
        {
            
        }
        
        

        public void consulterInfoApprenant(Apprenant a)
        {

        }

        public void verifierRenduDevoir(Apprenant a, Devoir d)
        {

        }
    }
}