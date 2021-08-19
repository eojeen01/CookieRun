using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Cookie4
{
    class SpeedUp:Item
    {
        public static int suSpeed()
        {
            return rand.Next(1,2);
        }
        

    }
}
