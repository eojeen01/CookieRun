using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cookie4
{
    class Obstacle : Game
    {
        public int obHang()
        {
            return rand.Next(0, 150);
        }
        public int obBottom1()
        {
            return rand.Next(580, 1000);
        }
        public int obBottom2()
        {
            return rand.Next(250, 450);
        }
        public Obstacle()
        {

        }
        public int Coin()
        {
            return rand.Next(0, 45);
        }
        public int Item1()
        {
            return rand.Next(55, 145) + 3000;
        }
        public int Item2()
        {
            return rand.Next(55, 145) + 2000;
        }
        public int Item3()
        {
            return rand.Next(55, 145) + 1000;
        }
    }
}
