using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElearningM1.Models
{
    public class Apprenant
    {
        private string nom, dateNaiss, prenom, email, telephone, adresse, dateInscription;
        private int id;
        private List<Module> lesModules;

        public Apprenant()
        {

        }

        public Apprenant(string nom, string dateNaiss, string prenom, string email, int id, string telephone, string dateInscription, string adresse)
        {
            this.nom = nom;
            this.dateNaiss = dateNaiss;
            this.prenom = prenom;
            this.email = email;
            this.id = id;
            this.telephone = telephone;
            this.dateInscription = dateInscription;
            this.adresse = adresse;
        }

        public string Nom { get => nom; set => nom = value; }
        public string DateNaiss { get => dateNaiss; set => dateNaiss = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Email { get => email; set => email = value; }
        public string Telephone { get => telephone; set => telephone = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public string DateInscription { get => dateInscription; set => dateInscription = value; }
        public int Id { get => id; set => id = value; }
        public List<Module> LesModules { get => Modules.getModules(Id); set => lesModules = value; }

        public void add(Module m)
        {
            this.LesModules.Add(m);
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