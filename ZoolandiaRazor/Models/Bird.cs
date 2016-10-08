using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZoolandiaRazor.Models
{
    public class Bird : Animal, IFlying
    {
        public int Distance()
        {
            return 500;
        }

        public bool Wings(int NumberOfWings)
        {
            return NumberOfWings >= 2;
        }
    }
}