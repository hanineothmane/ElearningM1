using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElearningM1.Models
{
    public class Administration : Profil
    {
        public Administration(string nom, string dateNaiss, string prenom, string courriel, int id, string mdp, string telephone, String adresse) : base(nom, dateNaiss, prenom, courriel, id, mdp, telephone, adresse)
        {
            
        }

        public void consulterInfoApprenant(Apprenant a)
        {

        }

        public void consulterInfoTE(TuteurEnseignant te)
        {

        }

        public void affecterApprenantModule(Apprenant a, Module m)
        {

        }
    }
}