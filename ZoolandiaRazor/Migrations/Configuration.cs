namespace ZoolandiaRazor.Migrations
{
    using DAL.Models;
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
                p => p.AnimalName,
                new Animal { AnimalAge = 13, AnimalName = "Gus", SpeciesCommonName = "Red Fox", SpeciesScientificName = "Vulpes vuples" },
                new Animal { AnimalAge = 9, AnimalName = "Zorro", SpeciesCommonName = "Fennec Fox", SpeciesScientificName = "Vulpes zerda" },
                new Animal { AnimalAge = 11, AnimalName = "Nosferatu", SpeciesCommonName = "Vampire Bat", SpeciesScientificName = "Desmodus rotundus" },
                new Animal { AnimalAge = 6, AnimalName = "Pork Chop", SpeciesCommonName = "Domestic pig", SpeciesScientificName = "Sus scrofa domesticus" },
                new Animal { AnimalAge = 15, AnimalName = "Hobbes", SpeciesCommonName = "Bengal Tiger", SpeciesScientificName = "Panthera tigris tigris" },
                new Animal { AnimalAge = 12, AnimalName = "Roxy", SpeciesCommonName = "Sumatran Rhinoceros", SpeciesScientificName = "Dicerorhinus sumatrensis" },
                new Animal { AnimalAge = 9, AnimalName = "Murphy", SpeciesCommonName = "Cane Toad", SpeciesScientificName = "Rhinella marina" },
                new Animal { AnimalAge = 7, AnimalName = "Triton", SpeciesCommonName = "River Otter", SpeciesScientificName = "Lontra canadensis" },
                new Animal { AnimalAge = 1, AnimalName = "Moon Moon", SpeciesCommonName = "Grey Wolf", SpeciesScientificName = "Canis lupus" },
                new Animal { AnimalAge = 2, AnimalName = "Blitz", SpeciesCommonName = "Reindeer", SpeciesScientificName = "Rangifer tarandus" },
                new Animal { AnimalAge = 5, AnimalName = "Raven", SpeciesCommonName = "Jaguar", SpeciesScientificName = "Panthera onca" },
                new Animal { AnimalAge = 2, AnimalName = "Spot", SpeciesCommonName = "Snow Leopard", SpeciesScientificName = "Panthera uncia" },
                new Animal { AnimalAge = 18, AnimalName = "Boots", SpeciesCommonName = "Elephant", SpeciesScientificName = "Elephas maximus" },
                new Animal { AnimalAge = 30, AnimalName = "Mrs Fluffy", SpeciesCommonName = "Lion", SpeciesScientificName = "Panthera leo" },
                new Animal { AnimalAge = 16, AnimalName = "Bitey", SpeciesCommonName = "Alligator Snapping Turtle", SpeciesScientificName = "Macrochelys temminckii" },
                new Animal { AnimalAge = 8, AnimalName = "Mr Fluffy", SpeciesCommonName = "Lion", SpeciesScientificName = "Panthera leo" },
                new Animal { AnimalAge = 7, AnimalName = "Pipsqueak", SpeciesCommonName = "Meerkat", SpeciesScientificName = "Suricata suricatta" },
                new Animal { AnimalAge = 12, AnimalName = "Scooter", SpeciesCommonName = "Iguana", SpeciesScientificName = "Iguana iguana" },
                new Animal { AnimalAge = 6, AnimalName = "Jeff", SpeciesCommonName = "Octopus", SpeciesScientificName = "Octopus vulgaris" }
                );

            context.Habitats.AddOrUpdate(
                p => p.HabitatName,
                new Habitat { HabitatName = "Treetop Tangle" },
                new Habitat { HabitatName = "Artic Adventure" },
                new Habitat { HabitatName = "Zoolandia Desert" },
                new Habitat { HabitatName = "Rainforest Retreat" },
                new Habitat { HabitatName = "River Run" },
                new Habitat { HabitatName = "Mountain Pass" },
                new Habitat { HabitatName = "Swamp Secrets" },
                new Habitat { HabitatName = "Tropical Trail" }
                );

            context.Employees.AddOrUpdate(
                p => p.EmployeeName,
                new Employee { EmployeeAge = 32, EmployeeName = "Jehonathan Patterson" },
                new Employee { EmployeeAge = 42, EmployeeName = "Woodrow Stephenson" },
                new Employee { EmployeeAge = 27, EmployeeName = "Malcolm Bentley" },
                new Employee { EmployeeAge = 51, EmployeeName = "Breanna Randell" },
                new Employee { EmployeeAge = 19, EmployeeName = "Martha Tindall" },
                new Employee { EmployeeAge = 36, EmployeeName = "Colin Holzmann" },
                new Employee { EmployeeAge = 32, EmployeeName = "Blanche Fuhrmann" },
                new Employee { EmployeeAge = 22, EmployeeName = "Ace Marsden" },
                new Employee { EmployeeAge = 39, EmployeeName = "Helene Banks" },
                new Employee { EmployeeAge = 24, EmployeeName = "Jody Alvey" },
                new Employee { EmployeeAge = 45, EmployeeName = "Liana Baker" },
                new Employee { EmployeeAge = 40, EmployeeName = "Liana Baker" }
                );

            context.HabitatTypes.AddOrUpdate(
                t => t.HabitatTypeName,
                new HabitatType { HabitatTypeName = "Rivers and Wetlands" },
                new HabitatType { HabitatTypeName = "Artic Tundra" },
                new HabitatType { HabitatTypeName = "Rainforest and Tropical" },
                new HabitatType { HabitatTypeName = "Desert" },
                new HabitatType { HabitatTypeName = "Temperate Forest" }
                );

        }
    }
}
