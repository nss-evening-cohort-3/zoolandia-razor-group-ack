namespace ZoolandiaRazor.Migrations
{
    using DAL.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ZoolandiaRazor.DAL.AnimalContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ZoolandiaRazor.DAL.AnimalContext context)
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

            context.Animals.AddOrUpdate(
                p => p.AnimalName,
                new Animal { AnimalAge = 3, AnimalName = "Dug", SpeciesCommonName = "Dinosaur", SpeciesScientificName = "Tyrannosaurus rex" },
                new Animal { AnimalAge = 5, AnimalName = "Spot", SpeciesCommonName = "Fox", SpeciesScientificName = "Vulpes something" }
                );

        }
    }
}
