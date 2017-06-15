using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElearningM1.Models
{

    public class Semestre
    {
        private int id, numSemestre;
        private string dateDebut, dateFin;
        private List<Module> lesModules;

        public Semestre() { }

        public Semestre(string dateDebut, string dateFin, int numSemestre)
        {
            this.Id = Id;
            this.dateDebut = dateDebut;
            this.dateFin = dateFin;
            this.NumSemestre = numSemestre;
        }

        public string DateDebut { get => dateDebut; set => dateDebut = value; }
        public string DateFin { get => dateFin; set => dateFin = value; }
        public int Id { get => id; set => id = value; }
        public int NumSemestre { get => numSemestre; set => numSemestre = value; }
    }
}