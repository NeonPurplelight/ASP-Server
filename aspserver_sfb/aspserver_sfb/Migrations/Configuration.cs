namespace aspserver_sfb.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<aspserver_sfb.Models.InseratDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "aspserver_sfb.Models.InseratDBContext";
        }

        protected override void Seed(aspserver_sfb.Models.InseratDBContext context)
        {
            context.Inserat.AddOrUpdate(
                new Inserat[] {

                new Inserat() { ID = 1, Name = "Holzstapel", Beschreibung = "Ein paar Holzbretter"},
                new Inserat() { ID = 2, Name = "Stahlrohre", Beschreibung = "Bündel Stahlrohre"},
                new Inserat() { ID = 3, Name = "Schrauben", Beschreibung = "Messing Schrauben"},
                });
        }
    }
}
