﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElearningM1.Models
{
    public class Examen
    {
        private string date, type;
        private int id;
        private Module leModule;


        public Examen()
        {

        }


        public Examen(string date, string type, Module leModule)
        {
            this.date = date;
            this.type = type;
            this.LeModule = leModule;
        }

        public string Date { get => date; set => date = value; }
        public string Type { get; set; }
        public int Id { get ; set ; }
        public Module LeModule { get; set; }
    }

}