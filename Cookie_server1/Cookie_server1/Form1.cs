using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cookie_server1
{
    public partial class Form1 : Form
    {
        public static Socket Server, Client;
        public const int sPort = 5000;
        bool booServer = false;
        Thread mainTh = null;
        static int count = 0;
        public static byte[] getByte = new byte[1024];
        public static byte[] setByte = new byte[1024];

        public Form1()
        {
            InitializeComponent();
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
          
        }

        private void buttonServer_Click(object sender, EventArgs e)
        {

            if (!booServer)
            {
                serverOpen();
            }
            else
            {
                serverClose();
            }


        }
        void serverOpen()
        {
            try
            {

                mainTh = new Thread(new ThreadStart(Running));
                mainTh.Start();
                booServer = true;
            }
            catch (Exception exe)
            {
                listBoxText.Items.Add("System Error = "+ exe.Message);

                booServer = false;
                return;
            }
        }
        void Running()
        {
            IPAddress serverIP = IPAddress.Parse("127.0.0.1");
            IPEndPoint serverEndPoint = new IPEndPoint(serverIP, sPort);
            
            try
            {
                Server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                Server.Bind(serverEndPoint);
                Server.Listen(10);
                listBoxText.Items.Add("Server Open");
                buttonServer.Text = "Stop";
                
                while (true)
                {
                    Client = Server.Accept();

                    if (Client.Connected)
                    {
                        listBoxText.Items.Add("Server Connected");
                        setByte = Encoding.UTF7.GetBytes("F");
                        Client.Send(setByte);
                        count++;
                        listBoxText.Items.Add(count + "명 접속");
                        if (count == 2)
                        {
                            listBoxText.Items.Add("모든 player 접속 완료");
                        }
                        Thread checking = new Thread(new ThreadStart(Check));
                        checking.IsBackground = true;
                        checking.Start();

                    }
                }
            }
            catch(Exception exe)
            {
                listBoxText.Items.Add("Server Error = " + exe.Message);
                buttonServer.Text = "Start";
               
                booServer = false;
                return;
            }

            
            

        }
        void serverClose()
        {
            try
            {
                Server.Close();
                listBoxText.Items.Add("Server closed");
                buttonServer.Text = "Start";
                booServer = false;
            }
            catch (Exception exe)
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    listBoxText.Items.Add("Server Closed Error = " + exe.Message);
                }));
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Server.Close();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            listBoxText.Items.Clear();
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
        private void Check()
        {
            string stringbyte;
            while (true) //무한Loop
            {
                Client.Receive(getByte);
                stringbyte = Encoding.UTF7.GetString(getByte);

                if (stringbyte != String.Empty)
                {
                    stringbyte = Encoding.UTF7.GetString(getByte);
                    listBoxText.Items.Add("수신데이터: " + stringbyte);

                }
                getByte = new byte[1024];
                setByte = new byte[1024];
            }




        }
    }
}
