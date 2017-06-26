using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElearningM1.Models
{
    public class Utilisateurs
    {
        private String Nom { get; set; }
        private String Mdp { get; set; }

        public Utilisateurs()
        {

        }

        public Utilisateurs(String Nom, String Mdp)
        {
            this.Nom = Nom;
            this.Mdp = Mdp; 
        }




   



    }
}