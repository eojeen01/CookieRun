using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookie4
{
    class Character1:Player, IItem2
    {

        public int Item2()
        {
            return rand.Next(55, 145)+400;
        }

        public override int speed()
        {
            return 12;
        }

    }
}
