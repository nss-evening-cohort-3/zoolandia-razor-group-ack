using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZoolandiaRazor.Models;

namespace ZoolandiaRazor.AnimalService
{
    public class AnimalService
    {
        public void CreateAnimal()
        {
            var animal = new Animal();

            animal.Age = 2;
            animal.Name = "Larry";
            var communicate = animal.Communicate();
            var isFed = animal.Eat(31);
        }

        public void CreateDog()
        {
            var dog = new Dog();

            dog.Age = 4;
            dog.Name = "Tobias";
            dog.Communicate();
            dog.Eat(21);
            dog.TailWagging = true;
            dog.Guard(true);
        }        
    }
}