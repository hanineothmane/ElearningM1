using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElearningM1.Models
{
    public class Profil
    {
        private string nom, dateNaiss, prenom, email, mdp, telephone, adresse;
        private int id;

        public Profil()
        { }

        public Profil(string nom, string dateNaiss, string prenom, string email, int id, string mdp, string telephone, string adresse)
        {
            this.nom = nom;
            this.dateNaiss = dateNaiss;
            this.prenom = prenom;
            this.email = email;
            this.id = id;
            this.mdp = mdp;
            this.telephone = telephone;
            this.adresse = adresse;
        }

        public string Nom { get => nom; set => nom = value; }
        public string DateNaiss { get => dateNaiss; set => dateNaiss = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Email { get => email; set => email = value; }
        public int Id { get => id; set => id = value; }
        public string Mdp { get => mdp; set => mdp = value; }
        public string Telephone { get => telephone; set => telephone = value; }
        public string Adresse { get; set; }
    }
}