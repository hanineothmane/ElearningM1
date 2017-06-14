using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElearningM1.Models
{
    public class RespPedagogique : Profil
    {
        public RespPedagogique(string nom, string dateNaiss, string prenom, string email, int id, string mdp, string telephone, string adresse) : base(nom, dateNaiss, prenom, email, id, mdp, telephone, adresse)
        {

        }

        public void affecterEnseignantModule(TuteurEnseignant te, Module m) { }

        public void modifierInfosProfil(Profil p) { }

        public void affecterEnseignantApprenant(TuteurEnseignant te, Apprenant a) { }

        public void ajouterProfil(Profil p) { }

        public void ajouterModule(Module m) { }

        public void consulterInfoApprenant(Apprenant a) { }

        public void consulterInfoTE(TuteurEnseignant te) { }

        public void affecterApprenantModule(Apprenant a, Module m) {
            a.add(m);
            m.add(a);
        }


    }
}