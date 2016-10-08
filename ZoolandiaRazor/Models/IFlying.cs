using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZoolandiaRazor.Models
{
    //group of method/property signatures that anything that implements the interface has to include
    interface IFlying
    {
        bool Wings(int NumberofWings);

        int Distance();   
    }
}
