using Cookie4.Properties;
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
    public partial class Intro : Form
    {
        Form1 form1;
        public Intro()
        {
            InitializeComponent();
            ClientSize = new Size(1000,600);
            this.CenterToScreen();
        }


        private void exit_Click(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void Intro_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

    

        private void Intro_Load(object sender, EventArgs e)
        {

        }

        private void pictureBoxPlay_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBoxPlay.Image = Resources.StartButton_3;
        }

        private void pictureBoxPlay_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBoxPlay.Image = Resources.StartButton;

        }

        private void pictureBoxPlay_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.form1 = new Form1(this);
            this.form1.Show();//다른 창 보여주기
            this.form1.FormClosed += new FormClosedEventHandler(exit_Click);
        }
    }
}
