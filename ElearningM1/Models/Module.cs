using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ElearningM1.Models
{
    public class Module
    {
        private string nom, dateCreation, typeModule;
        private int id;
        private double coef;
        private List<Apprenant> lesApprenants;
        private TuteurEnseignant ens;
        private SessionRegroupement sr;
        private List<Devoir> lesDevoirs;
        private List<Examen> lesExamens;
        private List<Semestre> lesSemestres;

        public Module()
        {

        }

        public Module(int id, string nom, string dateCreation, double coef, string typeModule, TuteurEnseignant ens, SessionRegroupement sr)
        {
            this.id = id;
            this.nom = nom;
            this.dateCreation = dateCreation;
            this.coef = coef;
            this.typeModule = typeModule;
            this.ens = ens;
            this.sr = sr;
        }

        [Required(ErrorMessage = "Le nom est obligatoire")]
        public string Nom { get => nom; set => nom = value; }
        public double Coef { get => coef; set => coef = value; }
        public List<Apprenant> LesApprenants { get => lesApprenants; set => lesApprenants = value; }
        public TuteurEnseignant Ens { get => ens; set => ens = value; }
        public SessionRegroupement Sr { get => sr; set => sr = value; }
        public List<Devoir> LesDevoirs { get => lesDevoirs; set => lesDevoirs = value; }
        public List<Examen> LesExamens { get => lesExamens; set => lesExamens = value; }
        public List<Semestre> LesSemestres { get => lesSemestres; set => lesSemestres = value; }
        public int Id { get => id; set => id = value; }
        [Required(ErrorMessage = "La date de création est obligatoire")]
        public string DateCreation { get => dateCreation; set => dateCreation = value; }
        [Required(ErrorMessage = "Le type de module est obligatoire")]
        public string TypeModule { get => typeModule; set => typeModule = value; }

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
        
    }
}