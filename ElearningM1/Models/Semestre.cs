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

        public Semestre(int id, int numSemestre, string dateDebut, string dateFin)
        {
            this.Id = id;
            this.NumSemestre = numSemestre;
            this.dateDebut = dateDebut;
            this.dateFin = dateFin;
        }

        public string DateDebut { get => dateDebut; set => dateDebut = value; }
        public string DateFin { get => dateFin; set => dateFin = value; }
        public int Id { get => id; set => id = value; }
        public int NumSemestre { get => numSemestre; set => numSemestre = value; }
    }
}