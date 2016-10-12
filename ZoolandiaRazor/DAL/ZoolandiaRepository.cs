using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZoolandiaRazor.DAL.NewModels;

namespace ZoolandiaRazor.DAL
{
    public class ZoolandiaRepository
    {
        private ZoolandiaContext Context { get; set; }

        public ZoolandiaRepository(ZoolandiaContext context)
        {
            Context = context;
        }

        public ZoolandiaRepository()
        {
            Context = new ZoolandiaContext();
        }

        // Get all Animals
        public List<Animal> GetAllAnimals()
        {
            return Context.Animals.ToList();
        }

        // Get AnimalById

        public Animal GetAnimalById(int AnimalId)
        {
            return Context.Animals.FirstOrDefault(x => x.AnimalId == AnimalId);
        }

        // Get all Habitats
        public List<Habitat> GetAllHabitats()
        {
            return Context.Habitats.ToList();
        }

        // Get HabitatById
        public Habitat GetHabitatById(int HabitatId)
        {
            return Context.Habitats.FirstOrDefault(x => x.HabitatId == HabitatId);
        }

        // Get all Employees
        public List<Employee> GetAllEmployees()
        {
            return Context.Employees.ToList();
        }

        // Get EmployeeById
        public Employee GetEmployeesById(int EmployeeId)
        {
            return Context.Employees.FirstOrDefault(x => x.EmployeeId == EmployeeId);
        }
    }
}