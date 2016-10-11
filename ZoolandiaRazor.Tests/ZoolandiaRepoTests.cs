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
            animal_context.Setup(w => w.Employees).Returns(employee_table.Object);

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
        }

        [TestCleanup]
        public void Cleanup()
        {
            animal_context = null;
            animal_table = null;
            animals = null;
            habitats = null;
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

        [TestMethod]
        public void RepoCanGetAllHabitats()
        {
            //Arrange
            ZoolandiaRepo my_repo = new ZoolandiaRepo(animal_context.Object);

            //Act
            List<Habitat> myHabitats = my_repo.GetAllHabitats();

            //Assert
            CollectionAssert.AreEqual(myHabitats, habitats);
        }

        [TestMethod]
        public void RepoCanGetHabitatById()
        {
            //Arrange
            ZoolandiaRepo my_repo = new ZoolandiaRepo(animal_context.Object);

            //Act
            Habitat myHabitats = my_repo.GetHabitatById(2);

            //Assert
            Assert.AreEqual(myHabitats, habitat2);
        }

        [TestMethod]
        public void CanGetAllEmployees()
        {
            //Arrange
            ZoolandiaRepo my_repo = new ZoolandiaRepo(animal_context.Object);

            //Act
            List<Employee> myEmployees = my_repo.GetAllEmployees();

            //Assert
            CollectionAssert.AreEqual(myEmployees, employees);

        }

        [TestMethod]
        public void CanGetEmployeeById()
        {
            //Arrange
            ZoolandiaRepo my_repo = new ZoolandiaRepo(animal_context.Object);

            //Act
            Employee myEmployees = my_repo.GetEmployeeById(4);

            //Assert
            Assert.AreEqual(myEmployees, employee1);
        }
    }
}









//Get employee by id
