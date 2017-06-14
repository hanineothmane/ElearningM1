using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElearningM1.Models
{
    public class Devoir
    {
        private string nom, date;
        private int id;
        private Module leModule;

        public Devoir(int id, string nom, string date, Module leModule)
        {
            this.id = id;
            this.date = date;
            this.LeModule = leModule;
        }

        public string Date { get => date; set => date = value; }
        public string Nom { get => nom; set => nom = value; }
        public int Id { get => id; set => id = value; }
        public Module LeModule { get => leModule; set => leModule = value; }
    }
}