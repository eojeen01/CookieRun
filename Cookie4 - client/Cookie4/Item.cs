using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Cookie4
{
    class Item:Game
    {
        public static Timer aTimer = new System.Timers.Timer(1000);
        public int GoodItemJudge(int h, int j)
        {
            h += j;
            return h;
        }
        public int BadItemJudge(int h, int j)
        {
            h -= j;
            return h;
        }

    }
}
