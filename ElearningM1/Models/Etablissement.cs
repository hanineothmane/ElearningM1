using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElearningM1.Models
{
    public class Etablissement
    {
        private string nom, adresse;
        private int id;
        private List<Examen> lesExamens;

        public Etablissement(int id, string nom, string adresse, Examen unExamen)
        {
            this.id = id;
            this.nom = nom;
            this.adresse = adresse;
        }

        public string Nom { get => nom; set => nom = value; }
        public string Adresse { get => adresse; set => adresse = value; }
    }
}