using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElearningM1.Models
{

    public class Semestre
    {
        private string dateDebut, dateFin;
        private List<Module> lesModules;

        public Semestre(string dateDebut, string dateFin)
        {
            this.dateDebut = dateDebut;
            this.dateFin = dateFin;
        }

        public string DateDebut { get => dateDebut; set => dateDebut = value; }
        public string DateFin { get => dateFin; set => dateFin = value; }

    }
}