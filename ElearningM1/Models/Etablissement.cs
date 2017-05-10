using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElearningM1.Models
{
    public class Etablissement
    {
        private string nom, ville;
        private List<ExamenLocal> lesExamens;

        public Etablissement(string nom, string ville)
        {
            this.nom = nom;
            this.ville = ville;
        }

        public string Nom { get => nom; set => nom = value; }
        public string Ville { get => ville; set => ville = value; }
    }
}