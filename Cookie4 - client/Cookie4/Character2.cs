using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookie4
{
    class Character2:Player,IItem1
    {

        public int Item1()
        {
            return rand.Next(55, 145) +1000;
        }

        public override int speed()
        {
            return 8;
        }
    }
}
