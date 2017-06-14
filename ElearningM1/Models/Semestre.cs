using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElearningM1.Models
{

    public class Semestre
    {
        private string dateDebut, dateFin;
        private int numSemestre;
        private List<Module> lesModules;

        public Semestre(string dateDebut, string dateFin, int numSemestre)
        {
            this.dateDebut = dateDebut;
            this.dateFin = dateFin;
            this.numSemestre = numSemestre;
        }

        public string DateDebut { get => dateDebut; set => dateDebut = value; }
        public string DateFin { get => dateFin; set => dateFin = value; }

        public int NumSemestre { get; set; }

    }
}