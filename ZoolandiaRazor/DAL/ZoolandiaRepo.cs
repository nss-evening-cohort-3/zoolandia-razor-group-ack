using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZoolandiaRazor.DAL.Models;

namespace ZoolandiaRazor.DAL
{
    public class ZoolandiaRepo
    {

        private ZoolandiaContext Context { get; set; }
        
        //Dependency injection
        public ZoolandiaRepo(ZoolandiaContext context)
        {
            Context = context;
        }

        public ZoolandiaRepo()
        {
            Context = new ZoolandiaContext();
        }

        //Get all animals, retuns a list of animals
        public List<Animal> GetAllAnimals()
        {
            List <Animal> AnimalList = Context.Animals.ToList();
            return AnimalList;
        }

        //Get animal by id, returns a single animal by passed in Id
        public Animal GetAnimalById(int Id)
        {
            var animal = Context.Animals.FirstOrDefault(a => a.AnimalId == Id);
            return animal;

        }

        //Get all habitats, returns list of habitats
        public List<Habitat> GetAllHabitats()
        {
            List<Habitat> HabitatList = Context.Habitats.ToList();
            return HabitatList;
        }

        //Gets habitat by Id, returns a single habitat by ID that is passed in
        public Habitat GetHabitatById(int Id)
        {
            var habitat = Context.Habitats.FirstOrDefault(h => h.HabitatId == Id);
            return habitat;
        }

        //Gets all employees, returns list
        public List<Employee> GetAllEmployees()
        {
            List<Employee> EmployeeList = Context.Employees.ToList();
            return EmployeeList;
        }

        //Gets single employee and returnes based on Id that is passed in
        public Employee GetEmployeeById(int Id)
        {
            var employee = Context.Employees.FirstOrDefault(e => e.EmployeeId == Id);
            return employee;
        }

        public List<HabitatType> GetAllHabitatTypes()
        {
            List<HabitatType> HabitatTypeList = Context.HabitatTypes.ToList();
            return HabitatTypeList;
        }

        public HabitatType GetHabitatTypeById(int Id)
        {
            var habitat_type = Context.HabitatTypes.FirstOrDefault(t => t.HabitatTypeId == Id);
            return habitat_type;
        }
    }
}