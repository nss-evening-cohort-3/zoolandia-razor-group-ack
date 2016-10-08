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
            animal.Age = 9;
            animal.Name = "Bob";
            var Communicate = animal.Communicate();
            var IsFed = animal.Eat(3);
        
        }

        public void CreateDog()
        {
            var dog = new Dog();
            dog.Age = 12;
            dog.Name = "Carl";
            var Communicate = dog.Communicate();
            var IsFed = dog.Eat(0);
            dog.TailWagging = true;
            dog.Guard(true);

        }

    }
}