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
    public partial class GameOver : Form
    {
        public GameOver(GameStartScreen gameStartScreen)
        {

            InitializeComponent();

            ClientSize = new Size(1000, 600);
            this.CenterToScreen();
            labelGameOver.Location = new Point(270, 153);
            
        }

        private void GameOver_Load(object sender, EventArgs e)
        {

        }

        private void labelFin_Click(object sender, EventArgs e)
        {

        }
    }
}
