using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZoolandiaRazor.Models
{
    interface IFlying
    {
        bool Wings(int NumberOfWings);
        int Distance();
    }
}
