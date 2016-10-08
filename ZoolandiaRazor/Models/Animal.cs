using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZoolandiaRazor.Models
{
    //All properties and methods available to any class that inherits from animal
    public class Animal
    {
        //public empty constructor
        public Animal()
        {
            Name = "Tom";
        }

        //overloaded method passing in a name to the constructor; gives other ways to get to the same properties(polymorphism)
        public Animal (string name)
        {
            Name = name;
        }
        //virtual allows it to be overridden
        public virtual string Name { get; set; }

        public int Age { get; set; }

        public virtual string Communicate() { 

            return "rawr";
        }

        public bool Eat(int food) {

        if ( food == 0)
            {
                return false;
           
            }
        else
            {
                return true;
            }

        }
       
    }
}