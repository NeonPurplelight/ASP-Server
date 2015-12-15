using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace aspserver_sfb.Models
{
    public class Inserat
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Beschreibung { get; set; }
        public int BildNr { get; set; }  //FK
    }

    public class InseratDBContext : DbContext
    {
        public DbSet<Inserat> Inserat { get; set; }
    }

}