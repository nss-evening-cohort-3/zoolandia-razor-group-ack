using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZoolandiaRazor.DAL.Models;

namespace ZoolandiaRazor.DAL
{
    public class ZoolandiaRepo
    {

        //Get all habitats

        //Get habitat by id

        //Get all employees

        //Get employee by id

        private AnimalContext Context { get; set; }
        
        //Dependency injection
        public ZoolandiaRepo(AnimalContext context)
        {
            Context = context;
        }

        public ZoolandiaRepo()
        {
            Context = new AnimalContext();
        }

        //Get all animals
        public List<Animal> GetAllAnimals()
        {
            List <Animal> AnimalList = Context.Animals.ToList();
            return AnimalList;
        }

        //Get animal by id
        public Animal GetAnimalById(int Id)
        {
            var animal = Context.Animals.FirstOrDefault(a => a.AnimalId == Id);
            return animal;

        }


    }
}