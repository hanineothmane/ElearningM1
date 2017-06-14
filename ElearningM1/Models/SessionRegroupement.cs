using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElearningM1.Models
{
    public class SessionRegroupement
    {
        private int id;
        private string nom, date;
        private List<Module> lesModules;

        public SessionRegroupement()
        {

        }

        public SessionRegroupement(int id, string nom, string date)
        {
            this.Id = id;
            this.Nom = nom;
            this.date = date;
        }

        public string Date { get => date; set => date = value; }
        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }

        public bool isPresent(Apprenant a)
        {
            return false;
        }
    }
}