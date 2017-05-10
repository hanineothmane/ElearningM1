using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElearningM1.Models
{
    public class Examen
    {
        private string date, lieu;
        private double noteEF;
        private Module leModule;

        public Examen(string date, string lieu, double noteEF)
        {
            this.date = date;
            this.lieu = lieu;
            this.noteEF = noteEF;
        }

        public string Date { get => date; set => date = value; }
        public string Lieu { get => lieu; set => lieu = value; }
        public double NoteEF { get => noteEF; set => noteEF = value; }
    }
}