using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel_agency.Models
{
    public class Parcours
    {
        public int ParcoursId { get; set; }

        public ICollection<Trajet> Trajets { get; set; }

        public Parcours()
        {
            this.Trajets = new HashSet<Trajet>();
        }
    }
}
