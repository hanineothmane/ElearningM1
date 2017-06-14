using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ElearningM1.Models
{
    public class Apprenant 
    {
        private string dateInscription;
        private string nom, dateNaiss, prenom, telephone, adresse;
        private int id; 
        private List<Module> lesModules;
        
        public Apprenant(string nom, string dateNaiss, string prenom, int id, string telephone, string dateInscription, string adresse)
        {
            this.nom = nom; 
            this.prenom = prenom;
            this.dateNaiss = dateNaiss;
            this.telephone = telephone;
            this.adresse = adresse;
            this.id = id;
            this.dateInscription = dateInscription;
        }


        public int Id { get; set; }
        public String Nom { get; set; }

        public String Prenom { get; set; }
        public string Telephone { get; set; }
        public String DateNaiss { get; set; }
        public String DateInscription { get; set; }
        public String Adresse { get; set; }

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