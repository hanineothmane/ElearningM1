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
            
            return new List<Module>
            {
                new Module("UE320. Technologie Objet Avancé",4,true,null),
                new Module("UE450. Méthodes Formelles", 4, false, null),
                new Module ("UE100. Gestion Commerciale",2,true,null),
                new Module ("UE490. Technologies Logicielles et Applications Métiers",3,true,null)
            };
        }

        
    }
}