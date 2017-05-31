using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Travel_agency.Models
{
    public class Transporteur
    {
        [Key]
        public int NumeroTransporteur { get; set; }
        public string Nom { get; set; }
        public string Type { get; set; }

    }
}
