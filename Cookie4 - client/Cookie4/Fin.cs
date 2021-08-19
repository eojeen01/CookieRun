using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cookie4
{
    public partial class Fin : Form
    {
        public Fin(GameStartScreen gameStartScreen)
        {
            InitializeComponent();
            ClientSize = new Size(1000, 600);
            this.CenterToScreen();
            labelFin.Location = new Point(265, 53);
            
        }

        private void Fin_Load(object sender, EventArgs e)
        {

        }
    }
}
