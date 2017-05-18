using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElearningM1.Models
{
    public class TuteurEnseignant : Profil
    {
        private List<Module> lesModules;
        //private string nom, dateNaiss, prenom, courriel,  mdp, telephone;
        //private int id;
        public TuteurEnseignant(string nom, string dateNaiss, string prenom, string courriel, int id, string mdp, string telephone,String adresse) : base(nom, dateNaiss, prenom, courriel, id, mdp, telephone,adresse)
        {
             
        }
        
        



        public void verifierRenduDevoir(Apprenant a, Devoir d)
        {

        }
    }
}