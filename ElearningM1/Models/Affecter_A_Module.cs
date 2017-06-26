using ElearningM1.BD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ElearningM1.Models
{
    public class Affecter_A_Module
    {
        private Apprenant apprenant;
        private Module module;
        private Nullable<double> noteFinale;

        public Affecter_A_Module() { }

        public Affecter_A_Module(Apprenant a, Module m, Nullable<double> nf)
        {
            this.apprenant = a;
            this.module = m;
            this.noteFinale = nf;
        }

        public Apprenant Apprenant { get => apprenant; set => apprenant = value; }
        public Module Module { get => module; set => module = value; }


        [Range(0, 20, ErrorMessage = "La note doit être comprise entre 0 et 20.")]
        public Nullable<double> NoteFinale { get => noteFinale; set => noteFinale = value; }

        
    }
}