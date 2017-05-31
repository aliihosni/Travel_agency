using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Travel_agency.Models
{
    public class Voyage
    {
        [Key]
        public int NumeroVoyage { get; set; }
        public int Duree { get; set; }
    }
}
