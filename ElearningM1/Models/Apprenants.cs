using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElearningM1.Models
{
    public class Apprenants
    {
        public List<Apprenant> getApprenants()
        {
            return new List<Apprenant>
            {
                new Apprenant("Ajili","12/03/1996","Wassim","wassim-ajili@hotmail.fr","wass","000","06","hier"),
                new Apprenant("Toto","01/01/2010","Titi","titi-toto@hotmail.fr","toto","000","06","demain")
            };
        }
    }
}