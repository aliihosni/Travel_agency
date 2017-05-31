using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Travel_agency.Models
{
    public class Circuit
    {
        public int CircuitId { get; set; }
        public string Theme { get; set; }
        public string  Description { get; set; }
        public string MoyenTransport { get; set; }

        [ForeignKey("Voyage")]
        public int NumeroVoyage { get; set; }
        public Voyage Voyage { get; set; }

        [ForeignKey("Parcours")]
        public int ParcoursId { get; set; }
        public Parcours Parcours { get; set; }
    }
}
