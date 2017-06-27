using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required(ErrorMessage = "La date de la session est obligatoire.")]
        [RegularExpression(@"(\d{2}/\d{2}/\d{4})", ErrorMessage = "Le format saisit doit être de type : jj/mm/aaaa.")]
        public string Date { get => date; set => date = value;
        }
        public int Id { get => id; set => id = value; }

        public string Nom { get => nom; set => nom = value; }

        public bool EstPresent(Apprenant a) //En cours de développement
        {
            return false;
        }
    }
}