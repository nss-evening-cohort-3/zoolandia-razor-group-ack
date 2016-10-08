using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZoolandiaRazor.Models
{
    public class Animal
    {
        public virtual string Name { get; set; }
        public int Age { get; set; }

        public virtual string Communicate()
        {
            return "yowza";
        }

        public bool Eat(int food)
        {
            if (food > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Animal()
        {
            Name = "Susan";
        }
        
        public Animal(string name)
        {
            Name = name;
        }       
    }
}