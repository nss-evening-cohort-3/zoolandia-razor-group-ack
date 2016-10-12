namespace ZoolandiaRazor.Migrations
{
    using DAL.NewModels;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ZoolandiaRazor.DAL.ZoolandiaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ZoolandiaRazor.DAL.ZoolandiaContext context)
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
               x => x.AnimalName,
                new Animal
                {
                    AnimalAge = 17,
                    AnimalName = "Steve",
                    SpeciesCommonName = "Penguin",
                    SpeciesScientificName = "PE"
                },
                new Animal
                { 
                    AnimalAge = 12,
                    AnimalName = "Bob",
                    SpeciesCommonName = "Giraffe",
                    SpeciesScientificName = "GI"
                },
                new Animal
                {
                    AnimalAge = 47,
                    AnimalName = "Larry",
                    SpeciesCommonName = "Elephant",
                    SpeciesScientificName = "EL"
                }

              );
        }
    }
}
