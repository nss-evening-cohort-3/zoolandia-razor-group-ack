using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZoolandiaRazor.Models
{
    public class Dog : Animal
    {
        public bool TailWagging { get; set; }

        public void Guard(bool intruder)
        {
            if (intruder)
            {
                Communicate();
            }
        }

        public override string Communicate()
        {
            return "Woof!";
        }

        private string _name;
        public override string Name
        {           
            get
            {
                return _name;
            }

            set
            {
                _name = "baby " + value;
            }
        }

        public Dog()
        {
            Name = "Tobias";
        }

        public Dog(string name)
        {
            Name = name;
        }
    }
}