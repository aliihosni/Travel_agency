using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Travel_agency.Models
{
    public class Depart
    {
        public int DepartId { get; set; }
        public DateTime DateTime { get; set; }

        [ForeignKey("Trajet")]
        public int TrajetId { get; set; }
        public Trajet Trajet { get; set; }

        public ICollection<Transporteur> Transporteurs { get; set; }

        public Depart()
        {
            this.Transporteurs = new HashSet<Transporteur>();
        }
    }
}
