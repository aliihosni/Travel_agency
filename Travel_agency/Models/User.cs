using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Travel_agency.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}