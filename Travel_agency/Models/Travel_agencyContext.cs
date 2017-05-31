using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Travel_agency.Models
{
    public class Travel_agencyContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Travel_agencyContext() : base("name=Travel_agencyContext")
        {
        }

        public System.Data.Entity.DbSet<Travel_agency.Models.Accompagnateur> Accompagnateurs { get; set; }

        public System.Data.Entity.DbSet<Travel_agency.Models.Circuit> Circuits { get; set; }

        public System.Data.Entity.DbSet<Travel_agency.Models.Parcours> Parcours { get; set; }

        public System.Data.Entity.DbSet<Travel_agency.Models.Voyage> Voyages { get; set; }

        public System.Data.Entity.DbSet<Travel_agency.Models.Client> Clients { get; set; }

        public System.Data.Entity.DbSet<Travel_agency.Models.Depart> Departs { get; set; }

        public System.Data.Entity.DbSet<Travel_agency.Models.Trajet> Trajets { get; set; }

        public System.Data.Entity.DbSet<Travel_agency.Models.Hebergement> Hebergements { get; set; }

        public System.Data.Entity.DbSet<Travel_agency.Models.Reservation> Reservations { get; set; }

        public System.Data.Entity.DbSet<Travel_agency.Models.Sejour> Sejours { get; set; }

        public System.Data.Entity.DbSet<Travel_agency.Models.Transporteur> Transporteurs { get; set; }

        public System.Data.Entity.DbSet<Travel_agency.Models.User> Users { get; set; }
    }
}
