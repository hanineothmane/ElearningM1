using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElearningM1.Models
{
    public class Module
    {
        private string nom;
        private double coeff, noteCC;
        private bool estNational;
        private List<Apprenant> lesApprenants;
        private TuteurEnseignant ens;
        private SessionRegroupement sr;
        private List<Devoir> lesDevoirs;
        private List<Examen> lesExamens;
        private List<Semestre> lesSemestres;

        public Module(string nom, double coeff, bool estNational, TuteurEnseignant ens)
        {
            this.nom = nom;
            this.coeff = coeff;
            this.ens = ens;
            this.estNational = estNational;
        }

        public string Nom { get => nom; set => nom = value; }
        public double Coeff { get => coeff; set => coeff = value; }
        public double NoteCC { get => noteCC; set => noteCC = value; }
        public bool EstNational { get => estNational; set => estNational = value; }
        public List<Apprenant> LesApprenants { get => lesApprenants; set => lesApprenants = value; }
        public TuteurEnseignant Ens { get => ens; set => ens = value; }
        public SessionRegroupement Sr { get => sr; set => sr = value; }
        public List<Devoir> LesDevoirs { get => lesDevoirs; set => lesDevoirs = value; }
        public List<Examen> LesExamens { get => lesExamens; set => lesExamens = value; }
        public List<Semestre> LesSemestres { get => lesSemestres; set => lesSemestres = value; }

        public void add(Apprenant a)
        {
            this.lesApprenants.Add(a);
        }

        public void add(Devoir d)
        {
            this.lesDevoirs.Add(d);
        }

        public void add(Examen e)
        {
            this.lesExamens.Add(e);
        }

        public void add(Semestre s)
        {
            this.lesSemestres.Add(s);
        }

        public List<Apprenant> getApprenants()
        {
            return new List<Apprenant>
            {
                //new Apprenant("Ajili","12/03/1996","Wassim","wassim-ajili@hotmail.fr","wass","000","06","hier"),
                //new Apprenant("Toto","01/01/2010","Titi","titi-toto@hotmail.fr","toto","000","06","demain")
            };
        }
    }
}