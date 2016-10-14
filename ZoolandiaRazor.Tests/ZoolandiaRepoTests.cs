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

        Mock<ZoolandiaContext> zoolandia_context;
        Mock<DbSet<Animal>> animal_table;
        private List<Animal> animals;
        private Animal animal1;
        private Animal animal2;
        Mock<DbSet<Habitat>> habitat_table;
        private List<Habitat> habitats;
        private Habitat habitat1;
        private Habitat habitat2;
        Mock<DbSet<Employee>> employee_table;
        private List<Employee> employees;
        private Employee employee1;
        private Employee employee2;
        Mock<DbSet<HabitatType>> habitat_type_table;
        private List<HabitatType> habitat_types;
        private HabitatType habitattype1;
        private HabitatType habitattype2;



       
        

        [TestInitialize]
        public void Initialize()
        {
            zoolandia_context = new Mock<ZoolandiaContext>();
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
            zoolandia_context.Setup(x => x.Animals).Returns(animal_table.Object);

            habitat_table = new Mock<DbSet<Habitat>>();
            habitat1 = new Habitat
            {
                HabitatId = 1,
                HabitatName = "Savannah Trail"
            };
            habitat2 = new Habitat
            {
                HabitatId = 2,
                HabitatName = "Jungle Adventure"
            };
            habitats = new List<Habitat> { habitat1, habitat2 };
            zoolandia_context.Setup(q => q.Habitats).Returns(habitat_table.Object);

            employee_table = new Mock<DbSet<Employee>>();
            employee1 = new Employee
            {
                EmployeeId = 4,
                EmployeeAge = 32,
                EmployeeName = "Jane Doe"
            };
            employee2 = new Employee
            {
                EmployeeId = 7,
                EmployeeAge = 21,
                EmployeeName = "Danger Mouse"
            };
            employees = new List<Employee> { employee1, employee2 };
            zoolandia_context.Setup(w => w.Employees).Returns(employee_table.Object);

            habitat_type_table = new Mock<DbSet<HabitatType>>();
            habitattype1 = new HabitatType
            {
                HabitatTypeId = 3,
                HabitatTypeName = "Jungle"
            };
            habitattype2 = new HabitatType
            {
                HabitatTypeId = 8,
                HabitatTypeName = "Underwater"
            };
            habitat_types = new List<HabitatType> { habitattype1, habitattype2 };
            zoolandia_context.Setup(t => t.HabitatTypes).Returns(habitat_type_table.Object);
            

            ConnectMocksToDatabase();

            
        }

        public void ConnectMocksToDatabase()
        {
            var queryable_list = animals.AsQueryable();

            animal_table.As<IQueryable<Animal>>().Setup(a => a.Provider).Returns(queryable_list.Provider);
            animal_table.As<IQueryable<Animal>>().Setup(a => a.Expression).Returns(queryable_list.Expression);
            animal_table.As<IQueryable<Animal>>().Setup(a => a.ElementType).Returns(queryable_list.ElementType);
            animal_table.As<IQueryable<Animal>>().Setup(a => a.GetEnumerator()).Returns(queryable_list.GetEnumerator());

            var habitat_list = habitats.AsQueryable();

            habitat_table.As<IQueryable<Habitat>>().Setup(h => h.Provider).Returns(habitat_list.Provider);
            habitat_table.As<IQueryable<Habitat>>().Setup(h => h.Expression).Returns(habitat_list.Expression);
            habitat_table.As<IQueryable<Habitat>>().Setup(h => h.ElementType).Returns(habitat_list.ElementType);
            habitat_table.As<IQueryable<Habitat>>().Setup(h => h.GetEnumerator()).Returns(habitat_list.GetEnumerator());

            var employee_list = employees.AsQueryable();

            employee_table.As<IQueryable<Employee>>().Setup(e => e.Provider).Returns(employee_list.Provider);
            employee_table.As<IQueryable<Employee>>().Setup(e => e.Expression).Returns(employee_list.Expression);
            employee_table.As<IQueryable<Employee>>().Setup(e => e.ElementType).Returns(employee_list.ElementType);
            employee_table.As<IQueryable<Employee>>().Setup(e => e.GetEnumerator()).Returns(employee_list.GetEnumerator());

            var habitat_type_list = habitat_types.AsQueryable();

            habitat_type_table.As<IQueryable<HabitatType>>().Setup(t => t.Provider).Returns(habitat_type_list.Provider);
            habitat_type_table.As<IQueryable<HabitatType>>().Setup(t => t.Expression).Returns(habitat_type_list.Expression);
            habitat_type_table.As<IQueryable<HabitatType>>().Setup(t => t.ElementType).Returns(habitat_type_list.ElementType);
            habitat_type_table.As<IQueryable<HabitatType>>().Setup(t => t.GetEnumerator()).Returns(habitat_type_list.GetEnumerator());
        }

        

        [TestCleanup]
        public void Cleanup()
        {
            zoolandia_context = null;
            animal_table = null;
            habitat_table = null;
            employee_table = null;
            habitat_type_table = null;
            animals = null;
            habitats = null;
            employees = null;
            habitat_types = null;
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
            ZoolandiaRepo my_repo = new ZoolandiaRepo(zoolandia_context.Object);
            Assert.IsNotNull(my_repo);
        }

        [TestMethod]
        public void RepoCanGetAllAnimals()
        {
            //Arrange
            ZoolandiaRepo my_repo = new ZoolandiaRepo(zoolandia_context.Object);

            //Act
            List<Animal> myAnimals = my_repo.GetAllAnimals();

            //Assert
            CollectionAssert.AreEqual(myAnimals, animals);
        }

        [TestMethod]
        public void CanGetAnimalById()
        {
            //Arrange
            ZoolandiaRepo my_repo = new ZoolandiaRepo(zoolandia_context.Object);

            //Act
            Animal myAnimals = my_repo.GetAnimalById(13);

            //Assert
            Assert.AreEqual(myAnimals, animal2);           
        }

        [TestMethod]
        public void RepoCanGetAllHabitats()
        {
            //Arrange
            ZoolandiaRepo my_repo = new ZoolandiaRepo(zoolandia_context.Object);

            //Act
            List<Habitat> myHabitats = my_repo.GetAllHabitats();

            //Assert
            CollectionAssert.AreEqual(myHabitats, habitats);
        }

        [TestMethod]
        public void RepoCanGetHabitatById()
        {
            //Arrange
            ZoolandiaRepo my_repo = new ZoolandiaRepo(zoolandia_context.Object);

            //Act
            Habitat myHabitats = my_repo.GetHabitatById(2);

            //Assert
            Assert.AreEqual(myHabitats, habitat2);
        }

        [TestMethod]
        public void CanGetAllEmployees()
        {
            //Arrange
            ZoolandiaRepo my_repo = new ZoolandiaRepo(zoolandia_context.Object);

            //Act
            List<Employee> myEmployees = my_repo.GetAllEmployees();

            //Assert
            CollectionAssert.AreEqual(myEmployees, employees);

        }

        [TestMethod]
        public void CanGetEmployeeById()
        {
            //Arrange
            ZoolandiaRepo my_repo = new ZoolandiaRepo(zoolandia_context.Object);

            //Act
            Employee myEmployees = my_repo.GetEmployeeById(4);

            //Assert
            Assert.AreEqual(myEmployees, employee1);
        }

        [TestMethod]
        public void CanGetAllHabitatTypes()
        {
            //Arrange
            ZoolandiaRepo my_repo = new ZoolandiaRepo(zoolandia_context.Object);

            //Act
            List<HabitatType> myHabtatTypes = my_repo.GetAllHabitatTypes();

            //Assert
            CollectionAssert.AreEqual(myHabtatTypes, habitat_types);
        }

        [TestMethod]
        public void CanGetHabitatTypeById()
        {
            //Arrange
            ZoolandiaRepo my_repo = new ZoolandiaRepo(zoolandia_context.Object);

            //Act
            HabitatType myHabitatTypes = my_repo.GetHabitatTypeById(8);

            //Assert
            Assert.AreEqual(myHabitatTypes, habitattype2);
        }
    }
}

