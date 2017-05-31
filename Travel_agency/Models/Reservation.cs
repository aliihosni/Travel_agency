using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel_agency.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public string Status { get; set; }
        public int NumeroVoyage { get; set; }
        public Voyage Voyage { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
