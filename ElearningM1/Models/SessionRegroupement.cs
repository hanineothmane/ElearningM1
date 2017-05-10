using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElearningM1.Models
{
    public class SessionRegroupement
    {
        private string date;
        private List<Module> lesModules;

        public SessionRegroupement(string date)
        {
            this.date = date;
        }

        public string Date { get => date; set => date = value; }

        public bool isPresent(Apprenant a)
        {
            return false;
        }
    }
}