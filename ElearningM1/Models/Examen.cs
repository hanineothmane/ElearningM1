using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ElearningM1.Models
{
    public class Examen
    {
        private string date, type;
        private int id;
        private Module leModule;

        public Examen() { }


        public Examen(int id, string date, string type, Module leModule) { }

        public Examen(string date, string type, Module leModule)
        {
            this.date = date;
            this.type = type;
            this.leModule = leModule;
        }

        [Required(ErrorMessage = "La date est obligatoire.")]
        [RegularExpression(@"(\d{2}/\d{2}/\d{4})", ErrorMessage = "Le format saisit doit être de type : jj/mm/aaaa.")]
        public string Date { get => date; set => date = value; }
        public string Type { get => type; set => type = value; }
        public int Id { get => id; set => id = value; }
        public Module LeModule { get => leModule; set => leModule = value; }
    }

}