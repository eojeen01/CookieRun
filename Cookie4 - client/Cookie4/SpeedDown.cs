using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Cookie4
{
    class SpeedDown:Item
    {
        public static int sdSpeed()
        {
            return rand.Next(1,2); 
        }
    }
}
