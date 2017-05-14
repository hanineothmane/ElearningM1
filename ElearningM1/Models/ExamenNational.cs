using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElearningM1.Models
{
    public class ExamenNational : Examen
    {
        public ExamenNational(string date, string lieu, double noteEF) : base(date, lieu, noteEF)
        {

        }
    }
}