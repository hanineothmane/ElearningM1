using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElearningM1.Models
{
    public class Apprenant : Profil
    {
        private string dateInscription;
        private List<Module> lesModules;


        public Apprenant(string nom, string dateNaiss, string prenom, string courriel, int id, string mdp, string telephone, string dateInscription, string adresse) : base(nom, dateNaiss, prenom, courriel, id, mdp, telephone, adresse)
        {
            this.dateInscription = dateInscription;
        }
        

        public void add(Module m)
        {
            this.lesModules.Add(m);
        }

        public Boolean aRendu(Devoir d)
        {
            return false;
        }

        public void modifierInfos()
        {

        }
    }
}