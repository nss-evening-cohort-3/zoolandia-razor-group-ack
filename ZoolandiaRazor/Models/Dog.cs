using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZoolandiaRazor.Models
{

    //Dog inherits from Animal, all properties for Animal available to Dog
    public class Dog : Animal
    {
        //made specific Dog constructor to leverage overriden name property setter
        public Dog()
        {
            Name = "Quark";
        }

        public Dog(string name)
        {
            Name = name;
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
                _name = "Ralph" + value;
            }
        }
        public override string Communicate()
        {
            return "Arf Arf";
        }
        //Properties and methods for Dog are only available to Dog
        public bool TailWagging { get; set; }

       
        public void Guard(bool intruder)
        {
            if (intruder)
            {
                //Calls animal.Communicate method
                //base.Communicate();

                //will call overriden method specific to Dog
                Communicate();
                
            }
        }
    }
}