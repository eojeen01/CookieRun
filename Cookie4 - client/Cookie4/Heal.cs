using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Cookie4
{
    class Heal:Item
    {
        public static int healing()
        {
           return rand.Next(1, 3);
        }
    }
}
