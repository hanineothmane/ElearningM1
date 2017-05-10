using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElearningM1.Models
{
    public class Modules
    {
        public List<Module> getModules()
        {
            TuteurEnseignant ens = new TuteurEnseignant("Benzakki", "01/01/1980", "Judith", "@fR.F", "jb", "000", "01");
            TuteurEnseignant ens1 = new TuteurEnseignant("Djafri", "01/01/1980", "Bachir", "@fR.F", "bd", "000", "01");
            TuteurEnseignant ens2 = new TuteurEnseignant("Melliti", "01/01/1980", "Tarek", "@fR.F", "tm", "000", "01");
            return new List<Module>
            {
                new Module("UE320. Technologie Objet Avancé",4,true,ens),
                new Module("UE450. Méthodes Formelles", 4, false, ens2),
                new Module ("UE100. Gestion Commerciale",2,true,ens),
                new Module ("UE490. Technologies Logicielles et Applications Métiers",3,true,ens1)
            };
        }

        
    }
}