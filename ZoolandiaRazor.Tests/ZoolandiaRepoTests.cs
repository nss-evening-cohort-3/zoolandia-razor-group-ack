using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZoolandiaRazor.DAL.NewModels;
using ZoolandiaRazor.DAL;
using Moq;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;

namespace ZoolandiaRazor.Tests
{
    [TestClass]
    public class ZoolandiaRepoTests
    {

        private Mock<ZoolandiaContext> MockContext;
        private Mock<DbSet<Animal>> Animals;
        private Mock<DbSet<Habitat>> Habitats;
        private Mock<DbSet<Employee>> Employees;
        private List<Animal> animals;
        private Animal animal1;
        private List<Habitat> habitats;
        private Habitat habitat1;
        private List<Employee> employees;
        private Employee employee1;

        [TestInitialize]
        public void Setup()
        {
            MockContext = new Mock<ZoolandiaContext>();
            Animals = new Mock<DbSet<Animal>>();
            Habitats = new Mock<DbSet<Habitat>>();
            Employees = new Mock<DbSet<Employee>>();

            MockContext.Setup(x => x.Animals).Returns(Animals.Object);
            MockContext.Setup(x => x.Habitats).Returns(Habitats.Object);
            MockContext.Setup(x => x.Employees).Returns(Employees.Object);

            employee1 = new Employee
            {
                EmployeeId = 1,
                EmployeeAge = 43,
                EmployeeName = "Fred"
            };

            habitat1 = new Habitat
            {
                HabitatId = 1,
                HabitatName = "Steve's Safari"
            };

            animal1 = new Animal
            {
                AnimalId = 2,
                AnimalAge = 7,
                AnimalName = "Larry",
                SpeciesCommonName = "Elephant",
                SpeciesScientificName = "EL"
            };

            employees = new List<Employee>
            {
                employee1,

                new Employee
                {
                    EmployeeId = 2,
                    EmployeeName = "Winston",
                    EmployeeAge = 74
                }
            };

            habitats = new List<Habitat>
            {
                habitat1,
                new Habitat
                {
                    HabitatId = 2,
                    HabitatName = "Jeff's Jungle"
                }
            };

            animals = new List<Animal>
            {
                new Animal
                {
                    AnimalId = 1,
                    AnimalAge = 4,
                    AnimalName = "Bob",
                    SpeciesCommonName = "Giraffe",
                    SpeciesScientificName = "GI",
                },
                animal1,
                new Animal
                {
                    AnimalId = 3,
                    AnimalAge = 17,
                    AnimalName = "Steve",
                    SpeciesCommonName = "Penguin",
                    SpeciesScientificName = "PE"
                }
            };
          ConnectMocksToDatastore();
        }


        public void ConnectMocksToDatastore()
        {
            var queryableAnimals = animals.AsQueryable();
            Animals.As<IQueryable<Animal>>().Setup(x => x.Provider).Returns(queryableAnimals.Provider);
            Animals.As<IQueryable<Animal>>().Setup(x => x.Expression).Returns(queryableAnimals.Expression);
            Animals.As<IQueryable<Animal>>().Setup(x => x.ElementType).Returns(queryableAnimals.ElementType);
            Animals.As<IQueryable<Animal>>().Setup(x => x.GetEnumerator()).Returns(queryableAnimals.GetEnumerator());

            var queryableHabitats = habitats.AsQueryable();
            Habitats.As<IQueryable<Habitat>>().Setup(x => x.Provider).Returns(queryableHabitats.Provider);
            Habitats.As<IQueryable<Habitat>>().Setup(x => x.Expression).Returns(queryableHabitats.Expression);
            Habitats.As<IQueryable<Habitat>>().Setup(x => x.ElementType).Returns(queryableHabitats.ElementType);
            Habitats.As<IQueryable<Habitat>>().Setup(x => x.GetEnumerator()).Returns(queryableHabitats.GetEnumerator());

            var queryableEmployees = employees.AsQueryable();
            Employees.As<IQueryable<Employee>>().Setup(x => x.Provider).Returns(queryableEmployees.Provider);
            Employees.As<IQueryable<Employee>>().Setup(x => x.Expression).Returns(queryableEmployees.Expression);
            Employees.As<IQueryable<Employee>>().Setup(x => x.ElementType).Returns(queryableEmployees.ElementType);
            Employees.As<IQueryable<Employee>>().Setup(x => x.GetEnumerator()).Returns(queryableEmployees.GetEnumerator());

        }

        [TestCleanup]
        public void TestCleanup()
        {
            MockContext = null;
            Animals = null;
            animals = null;
            Habitats = null;
            habitats = null;
            Employees = null;
            employees = null;
        }


        [TestMethod]
        public void CanMakeInstanceOfRepo()
        {
            ZoolandiaRepository myRepo = new ZoolandiaRepository();
            Assert.IsNotNull(myRepo);
        }

        [TestMethod]
        public void EnsureMyRepoCanAccessContext()
        {
            ZoolandiaRepository myRepo = new ZoolandiaRepository(MockContext.Object);
        }

        // Get all Animals
        [TestMethod]
        public void CanGetAllAnimals()
        {
            ZoolandiaRepository myRepo = new ZoolandiaRepository(MockContext.Object);
            List<Animal> MyAnimals = myRepo.GetAllAnimals();
            CollectionAssert.AreEqual(MyAnimals, animals);
        }

        // Get AnimalById
        [TestMethod]
        public void CanIGetAnimalsById()
        {
            ZoolandiaRepository myRepo = new ZoolandiaRepository(MockContext.Object);
            Animal MyAnimals = myRepo.GetAnimalById(2);
            Assert.AreEqual(MyAnimals, animal1);
        }

        // Get all Habitats
        [TestMethod]
        public void CanIGetAllHabitats()
        {
            ZoolandiaRepository myRepo = new ZoolandiaRepository(MockContext.Object);
            List<Habitat> MyHabitats = myRepo.GetAllHabitats();
            CollectionAssert.AreEqual(MyHabitats, habitats);
        }


        // Get HabitatById
        [TestMethod]
        public void CanIGetHabitatsById()
        {
            ZoolandiaRepository myRepo = new ZoolandiaRepository(MockContext.Object);
            Habitat MyHabitats = myRepo.GetHabitatById(1);
            Assert.AreEqual(MyHabitats, habitat1);
        }

        // Get all Employees
        [TestMethod]
        public void CanIGetAllEmployees()
        {
            ZoolandiaRepository myRepo = new ZoolandiaRepository(MockContext.Object);
            List<Employee> MyEmployee = myRepo.GetAllEmployees();
            CollectionAssert.AreEqual(MyEmployee, employees);
        }

        // Get EmployeeById
        [TestMethod]
        public void CanIGetEmployeesById()
        {
            ZoolandiaRepository myRepo = new ZoolandiaRepository(MockContext.Object);
            Employee MyEmployees = myRepo.GetEmployeesById(1);
            Assert.AreEqual(MyEmployees, employee1);
        }

    }
}
