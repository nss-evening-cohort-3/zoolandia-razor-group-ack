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
            return 1000;
        }

        public bool Wings(int NumberofWings)
        {
            return NumberofWings >= 2;
        }
    }
}