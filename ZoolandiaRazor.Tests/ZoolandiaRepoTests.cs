using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZoolandiaRazor.DAL;
using ZoolandiaRazor.DAL.Models;
using Moq;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;

namespace ZoolandiaRazor.Tests
{
    [TestClass]
    public class ZoolandiaRepoTests
    {

        Mock<AnimalContext> animal_context;
        Mock<DbSet<Animal>> animal_table;
        Mock<DbSet<Habitat>> habitat_table;
        private List<Animal> animals;
        private List<Habitat> habitats;
        private Animal animal1;
        private Animal animal2;
        private Habitat habitat1;
        private Habitat habitat2;

       
        

        [TestInitialize]
        public void Initialize()
        {
            animal_context = new Mock<AnimalContext>();
            animal_table = new Mock<DbSet<Animal>>();
            animal1 = new Animal {
                AnimalId = 5,
                AnimalAge = 7,
                AnimalName = "Foxy",
                SpeciesCommonName = "Fox",
                SpeciesScientificName = "Vulpis something"
            };
            animal2 = new Animal {
                AnimalId = 13,
                AnimalAge = 3,
                AnimalName = "Dug",
                SpeciesCommonName = "Dinosaur",
                SpeciesScientificName = "Tyrranosaurus rex"
            };
            animals = new List<Animal> { animal1, animal2 };
            animal_context.Setup(x => x.Animals).Returns(animal_table.Object);

            habitat_table = new Mock<DbSet<Habitat>>();
            habitat1 = new Habitat
            {
                HabitatId = 1,
                HabitatName = "Desert"
            };
            habitat2 = new Habitat
            {
                HabitatId = 2,
                HabitatName = "Jungle"
            };
            habitats = new List<Habitat> { habitat1, habitat2 };
            animal_context.Setup(q => q.Habitats).Returns(habitat_table.Object);


            ConnectMocksToDatabase();

            
        }

        public void ConnectMocksToDatabase()
        {
            var queryable_list = animals.AsQueryable();

            animal_table.As<IQueryable<Animal>>().Setup(a => a.Provider).Returns(queryable_list.Provider);
            animal_table.As<IQueryable<Animal>>().Setup(a => a.Expression).Returns(queryable_list.Expression);
            animal_table.As<IQueryable<Animal>>().Setup(a => a.ElementType).Returns(queryable_list.ElementType);
            animal_table.As<IQueryable<Animal>>().Setup(a => a.GetEnumerator()).Returns(queryable_list.GetEnumerator());
        }

        [TestCleanup]
        public void Cleanup()
        {
            animal_context = null;
            animal_table = null;
            animals = null;
        }
       

        [TestMethod]
        public void CanMakeInstanceofRepo()
        {
            ZoolandiaRepo my_repo = new ZoolandiaRepo();
            Assert.IsNotNull(my_repo);

        }

        [TestMethod]
        public void RepoCanAccessContextWhenPassedIn()
        {
            ZoolandiaRepo my_repo = new ZoolandiaRepo(animal_context.Object);
            Assert.IsNotNull(my_repo);
        }

        [TestMethod]
        public void RepoCanGetAllAnimals()
        {
            //Arrange
            ZoolandiaRepo my_repo = new ZoolandiaRepo(animal_context.Object);

            //Act
            List<Animal> myAnimals = my_repo.GetAllAnimals();

            //Assert
            CollectionAssert.AreEqual(myAnimals, animals);
        }

        [TestMethod]
        public void CanGetAnimalById()
        {
            //Arrange
            ZoolandiaRepo my_repo = new ZoolandiaRepo(animal_context.Object);

            //Act
            Animal myAnimals = my_repo.GetAnimalById(13);

            //Assert
            Assert.AreEqual(myAnimals, animal2);

            
        }
    }
}



//Get animal by id

//Get all habitats

//Get habitat by id

//Get all employees

//Get employee by id
