namespace SFB.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using SFB.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<SFB.Models.SFBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SFB.Models.SFBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Users.AddOrUpdate(x => x.ID,

                new User() { ID = 1, Username = "Valledasmesser" }
                );

            context.TauschObjs.AddOrUpdate(x => x.ID,

               new TauschObj() { ID = 1, Name = "Holz", Beschreibung = "Valle ist ein Messer" }
               );

        }
    }
}
