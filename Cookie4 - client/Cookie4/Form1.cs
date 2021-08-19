using Cookie4.Properties;
using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Cookie4
{

    public partial class Form1 : Form

    {
        Thread thread;
        public static Socket socket;
        public static byte[] getbyte = new byte[1024];
        public static byte[] setbyte = new byte[1024];
        public const int sPort = 5000;
        public static string getstring = null;
        int getValueLength = 0;
        public static string name;

        GameStartScreen game;
        public static int count=0;
        public Form1(Intro intro)
        {
            InitializeComponent();
            ClientSize = new Size(1000,600);
            this.CenterToScreen();
            pictureBoxReady.Location = new Point(354, 406);
            pictureBoxCharacter.Location = new Point(358, 107);
            labelCookieName.Location = new Point(395, 24);
            textBoxID.Location = new Point(418, 457);
            this.MaximizeBox = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void pictureBoxLeft_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBoxLeft.Image = Resources.LeftPush;
           
        }

        private void pictureBoxLeft_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBoxLeft.Image = Resources.left;
        }

        private void pictureBoxRight_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBoxRight.Image = Resources.RightPush;
        }

        private void pictureBoxRight_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBoxRight.Image = Resources.right;
            
        }

        private void pictureBoxReady_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBoxReady.Image = Resources.ReadyPush;
        }

        private void pictureBoxReady_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBoxReady.Image = Resources.Ready;

        }

        private void pictureBoxRight_Click(object sender, EventArgs e)
        {
            count++;
            if (count > 2)
            {
                count = 0;
            }
            Counting(count);

        }

        private void pictureBoxLeft_Click(object sender, EventArgs e)
        {
            count--;
            if (count < 0)
            {
                count = 2;
            }
            Counting(count);
        }
        public void Counting(int num)
        {


            if (num == 0)
            {
                pictureBoxCharacter.Image = Resources.Ninja_cookie;
                labelCookieName.Text = "Ninja Cookie";
                
            }
            else if(num==1)
            {
                pictureBoxCharacter.Image = Resources.Herb_cookie;
                labelCookieName.Text = "Herb Cookie";
            }
            else if (num == 2)
            {
                pictureBoxCharacter.Image = Resources.Milk_cookie;
                labelCookieName.Text = "Milk Cookie";
            }

        }
        private void pictureBoxReady_Click(object sender, EventArgs e)
        {
            if(textBoxID.Text==""||textBoxID.Text=="ID 입력")
            {
                MessageBox.Show("ID를 입력하세요");
                return;
            }
            name = textBoxID.Text;
            Open();
            game.Visible = false;
            thread = new Thread(new ThreadStart(Run));
            thread.Start();
            
        }
        public static int byteArrayDefrag(byte[] sData)
        {
            int endLength = 0;
            for (int i = 0; i < sData.Length; i++)
            {
                if ((byte)sData[i] != (byte)0)
                {
                    endLength = i;
                }
            }
            return endLength;
        }

        public void Run()
        {
            IPAddress serverIP = IPAddress.Parse("127.0.0.1");
            IPEndPoint serverEndPoint = new IPEndPoint(serverIP, sPort);
            
            
            try
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(serverEndPoint);
                if (count == 0)
                {
                    setbyte = Encoding.UTF7.GetBytes("ch1");
                    socket.Send(setbyte);
                }
                if (count == 1)
                {
                    setbyte = Encoding.UTF7.GetBytes("ch2");
                    socket.Send(setbyte);
                }
                if (count == 2)
                {
                    setbyte = Encoding.UTF7.GetBytes("ch3");
                    socket.Send(setbyte);
                }
                while (true)
                {
                    socket.Receive(getbyte, 0, getbyte.Length, SocketFlags.None);
                    getValueLength = byteArrayDefrag(getbyte);
                    getstring = Encoding.UTF7.GetString(getbyte, 0, getValueLength + 1);
                    if (getstring == "F")
                    {
                        game.Visible = true;
                        if (count == 0)
                        {
                            game.pictureBoxPlayer1.Image = Resources.cookie0007_run01;
                        }
                        if (count == 1)
                        {
                            game.pictureBoxPlayer1.Image = Resources.cookie0063_run01;
                        }
                        if (count == 2)
                        {
                            game.pictureBoxPlayer1.Image = Resources.cookie0135_run01;
                        }
                        
                    }
                    getbyte = new byte[1024];
                }
                
            }
            catch (Exception e2)
            {
                MessageBox.Show(e2+ "연결 실패!");
                this.Close();
            }
        }
        private void exit_Click(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
        private void Receive()
        {
            socket.Receive(getbyte);
            getstring = Encoding.UTF7.GetString(getbyte);
        }
        private void Open()
        {
            this.Visible = false;
            this.game = new GameStartScreen(this);//GameStartScreen에서 이 폼을 제어할 수 있게 됨
            this.game.Show();//다른 창 보여주기
            this.game.FormClosed += new FormClosedEventHandler(exit_Click);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void textBoxID_MouseClick(object sender, MouseEventArgs e)
        {
            textBoxID.Text = "";
        }
    }
}
