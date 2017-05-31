using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Travel_agency.Models
{
    public class Sejour
    {
        public int SejourId { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }

        [ForeignKey("Voyage")]
        public int NumeroVoyage { get; set; }
        public Voyage Voyage { get; set; }

        [ForeignKey("Hebergement")]
        public int HebergementId { get; set; }
        public Hebergement Hebergement { get; set; }
    }
}
