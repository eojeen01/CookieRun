using Cookie4.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cookie4
{
    public partial class GameStartScreen : Form
    {
        Item item = new Item();
        Stopwatch sw;
        Random rand;
        Obstacle ob;
        Character1 ch1;
        Character2 ch2;
        Character3 ch3;
        GameOver gameover;
        Fin fin;
        bool jumping = false;
        int jumpSpeed;
        int force = 12;
        int Life = 300;
        int score = 0;
        int obstacleSpeed;
        public static int sec;
        public static bool isGameFin = false;
        public static bool isGameOver = false;
        public GameStartScreen() //test
        {
            
            
        }


        public GameStartScreen(Form1 form1)
        {
            InitializeComponent();
            ch1 = new Character1();
            ch2 = new Character2();
            ch3 = new Character3();
            rand = new Random();
            ob = new Obstacle();
            sw = new Stopwatch();  
            sw.Start();
            ClientSize = new Size(1000, 600);
            this.CenterToScreen();
            this.MaximizeBox = false;
            if (Form1.count == 0)
            {
                pictureBoxPlayer1.Image = Resources.cookie0007_run01;
                obstacleSpeed = ch1.speed();
            }
            if (Form1.count == 1)
            {
                pictureBoxPlayer1.Image = Resources.cookie0063_run01;
                obstacleSpeed = ch2.speed();
            }
            if (Form1.count == 2)
            {
                pictureBoxPlayer1.Image = Resources.cookie0135_run01;
                obstacleSpeed = ch3.speed();
            }
            
            pictureBoxObstacle1.Top = 450;
            pictureBox19.Top = 470;
            StartRunTimer();
            GameSet();

            //progressBar - life
            progressBarLife.Style = ProgressBarStyle.Continuous;
            progressBarLife.Maximum = 300;
            progressBarLife.Minimum = 0;
            progressBarLife.Step = 0;
            progressBarLife.Value = Life;
            //progressBar - score
            progressBarScore.Style = ProgressBarStyle.Continuous;
            progressBarScore.Maximum = 200;
            progressBarScore.Minimum = 0;
            progressBarScore.Step = 0;
            progressBarScore.Value = score;
            //바닥
            pictureBox1.Location = new Point(60, 545);
            pictureBox2.Location = new Point(2, 545);
            pictureBox3.Location = new Point(115, 545);
            pictureBox4.Location = new Point(173, 545);
            pictureBox5.Location = new Point(230, 545);
            pictureBox6.Location = new Point(287, 545);
            pictureBox7.Location = new Point(344, 545);
            pictureBox8.Location = new Point(401, 545);
            pictureBox9.Location = new Point(458, 545);
            pictureBox10.Location = new Point(515, 545);
            pictureBox11.Location = new Point(572, 545);
            pictureBox12.Location = new Point(629, 545);
            pictureBox13.Location = new Point(686, 545);
            pictureBox14.Location = new Point(743, 545);
            pictureBox16.Location = new Point(800, 545);
            pictureBox17.Location = new Point(870, 545);
            pictureBox15.Location = new Point(925, 545);
            pictureBox18.Location = new Point(971, 545);

            



        }

        private void GameStartScreen_Load(object sender, EventArgs e)
        {
           
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {

            labelConnecting.Text = sw.ElapsedMilliseconds.ToString() + "ms";
            pictureBoxPlayer1.Top += jumpSpeed;

            if (jumping==true && force < 0)
            {
                jumping = false;
            }
            if (jumping == true)
            {
                jumpSpeed = -18;
                force -= 1;
            }
            else
            {
                jumpSpeed = 12;
            }

            if(pictureBoxPlayer1.Top>415 && jumping == false)
            {
                force = 12;
                pictureBoxPlayer1.Top = 415;
                jumpSpeed = 0;
            }
            //아이템 속도
            pictureBox20.Left -= obstacleSpeed;
            pictureBoxObstacle1.Left -= obstacleSpeed;
            pictureBox19.Left -= obstacleSpeed;
            pictureBoxCoin.Left -= obstacleSpeed;
            pictureBoxItem1.Left -= obstacleSpeed;
            pictureBoxItem2.Left -= obstacleSpeed;
            pictureBoxItem3.Left -= obstacleSpeed;
            //아이템 재생성
            if (pictureBox20.Left < -100)
            {

                pictureBox20.Left = this.ClientSize.Width + ob.obHang();
            }


            if (pictureBoxObstacle1.Left < -100)
            {

                pictureBoxObstacle1.Left = this.ClientSize.Width + ob.obBottom1();
            }


            if (pictureBox19.Left < -100)
            {

                pictureBox19.Left = this.ClientSize.Width + ob.obBottom2();
            }
            if (pictureBoxCoin.Left < -100)
            {
                pictureBoxCoin.Visible = true;
                pictureBoxCoin.Left = this.ClientSize.Width + ob.Coin();
                pictureBoxCoin.Top = rand.Next(350, 450);
            }
            if(pictureBoxItem1.Left < -100)
            {
                if (Form1.count == 2)
                {
                    pictureBoxItem1.Visible = true;
                    pictureBoxItem1.Left = this.ClientSize.Width + ch2.Item1();
                    pictureBoxItem1.Top = rand.Next(350, 450);
                }
                else
                {
                    pictureBoxItem1.Visible = true;
                    pictureBoxItem1.Left = this.ClientSize.Width + ob.Item1();
                    pictureBoxItem1.Top = rand.Next(350, 450);
                }
                
            }
            if (pictureBoxItem2.Left < -100)
            {
                if (Form1.count == 0)
                {
                    pictureBoxItem2.Visible = true;
                    pictureBoxItem2.Left = this.ClientSize.Width + ch1.Item2();
                    pictureBoxItem2.Top = rand.Next(350, 450);
                }
                else
                {
                    pictureBoxItem2.Visible = true;
                    pictureBoxItem2.Left = this.ClientSize.Width + ob.Item2();
                    pictureBoxItem2.Top = rand.Next(350, 450);
                }
               
            }
            if (pictureBoxItem3.Left < -100)
            {
                
                    pictureBoxItem3.Visible = true;
                    pictureBoxItem3.Left = this.ClientSize.Width + ob.Item3();
                    pictureBoxItem3.Top = rand.Next(350, 450);
                
            }
            //speed가 음수면
            if (obstacleSpeed < 4)
            {
                obstacleSpeed += 10;
            }
            //체력, 점수 관리
            Judge();;
            if (isGameOver == true)
            {
                sw.Stop();
                sec = (int)sw.ElapsedMilliseconds;
                timer1.Stop();
                this.Visible = false;
                this.gameover = new GameOver(this);
                this.gameover.Show();//다른 창 보여주기

                Form1.setbyte = Encoding.UTF7.GetBytes(Form1.name + " : Game Over");
                Form1.socket.Send(Form1.setbyte);

                this.gameover.FormClosed += new FormClosedEventHandler(exit_Click);
            }
            if (isGameFin == true)
            {
                sw.Stop();
                sec = (int)sw.ElapsedMilliseconds;
                timer1.Stop();
                this.Visible = false;
                this.fin = new Fin(this);
                this.fin.Show();//다른 창 보여주기

                Form1.setbyte = Encoding.UTF7.GetBytes(Form1.name + " : " + sec);
                Form1.socket.Send(Form1.setbyte);

                this.fin.FormClosed += new FormClosedEventHandler(exit_Click);

            }
            // 아이템에 닿으면
            if (pictureBoxPlayer1.Bounds.IntersectsWith(pictureBoxItem1.Bounds))
            {
                int n = Heal.healing();
                Life = item.GoodItemJudge(Life, n);
                progressBarLife.Step = n;
                progressBarLife.PerformStep();
                
            }
            if (pictureBoxPlayer1.Bounds.IntersectsWith(pictureBoxItem2.Bounds))
            {
                obstacleSpeed =item.GoodItemJudge(obstacleSpeed,SpeedUp.suSpeed());
            }
            if (pictureBoxPlayer1.Bounds.IntersectsWith(pictureBoxItem3.Bounds))
            {
                obstacleSpeed = item.BadItemJudge(obstacleSpeed, SpeedDown.sdSpeed());
            }
        }
        //캐릭터별 뛰는 모습
        int num = 1;
        private void RunTimeFunction()
        {
            num = num + 1;
            if (num > 4)
            {
                num = 1;
            }
            if(jumping == false)
            {
                if (Form1.count == 0)
                {
                    
                    
                    switch (num)
                    {

                        case 1:
                            pictureBoxPlayer1.Image = Resources.cookie0007_run01;
                            break;
                        case 2:
                            pictureBoxPlayer1.Image = Resources.cookie0007_run02;
                            break;
                        case 3:
                            pictureBoxPlayer1.Image = Resources.cookie0007_run03;
                            break;
                        case 4:
                            pictureBoxPlayer1.Image = Resources.cookie0007_run04;
                            
                            break;
                        default:
                            break;
                    }
                }
                if (Form1.count == 1)
                {
                    
                    switch (num)
                    {

                        case 1:
                            pictureBoxPlayer1.Image = Resources.cookie0063_run01;
                            break;
                        case 2:
                            pictureBoxPlayer1.Image = Resources.cookie0063_run02;
                            break;
                        case 3:
                            pictureBoxPlayer1.Image = Resources.cookie0063_run03;
                            
                            break;
                        case 4:
                            pictureBoxPlayer1.Image = Resources.cookie0063_run04;
                            break;
                        default:
                            break;
                    }
                }
                if (Form1.count == 2)
                {
                    switch (num)
                    {

                        case 1:
                            pictureBoxPlayer1.Image = Resources.cookie0135_run01;
                            break;
                        case 2:
                            pictureBoxPlayer1.Image = Resources.cookie0135_run02;
                            break;
                        case 3:
                            pictureBoxPlayer1.Image = Resources.cookie0135_run03;
                            break;
                        case 4:
                            pictureBoxPlayer1.Image = Resources.cookie0135_run04;
                            break;
                        default:
                            break;
                    }
                }
               
            }
        }
        private void StartRunTimer()
        {
            timerRun.Interval = 100;
            timerRun.Enabled = true;
        }
        private void timerRun_Tick(object sender, EventArgs e)
        {
            RunTimeFunction();
        }
        //키 누를때
        private void GameStartScreen_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Space && jumping==false)
            {
                jumping = true;
                if (Form1.count == 0)
                {
                    pictureBoxPlayer1.Image = Resources.cookie0007_chest01;
                }
                if (Form1.count == 1)
                {
                    pictureBoxPlayer1.Image = Resources.cookie0063_chest01;
                }
                if (Form1.count == 2)
                {
                    pictureBoxPlayer1.Image = Resources.cookie0135_chest01;
                }
               

            }
            if(e.KeyCode==Keys.Down && jumping == false)
            {
                timerRun.Stop();
                if (Form1.count == 0)
                {
                    pictureBoxPlayer1.Image = Resources.cookie0007_chest02;
                }
                if (Form1.count == 1)
                {
                    pictureBoxPlayer1.Image = Resources.cookie0063_chest02;
                }
                if (Form1.count == 2)
                {
                    pictureBoxPlayer1.Image = Resources.cookie0135_chest02;
                }
            }

            if (e.KeyCode == Keys.Up)
            {

                if (jumping == true)
                {
                    jumping = false;
                }

            }

        }

        private void GameStartScreen_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void timerSlide_Tick(object sender, EventArgs e)
        {
        }
        //키에서 손을 떼다
        private void GameStartScreen_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Down)
            {
                timerRun.Start();
            }
        }

        private void GameSet()
        {
            force = 12;
            jumpSpeed = 0;
            jumping = false;
            Life = 300;
            labelConnecting.Text = sw.ElapsedMilliseconds.ToString()+"ms";
            StartRunTimer();// 달리는 모션
            isGameOver = false;
            pictureBoxPlayer1.Top = 415;
            pictureBoxObstacle1.Left = this.ClientSize.Width + ob.obBottom1();
            pictureBox19.Left = this.ClientSize.Width + ob.obBottom2();
            pictureBox20.Left = this.ClientSize.Width + ob.obHang();
            pictureBoxCoin.Left = this.ClientSize.Width + ob.Coin();
            pictureBoxItem1.Left = this.ClientSize.Width + ob.Item1();
            pictureBoxItem3.Left = this.ClientSize.Width + ob.Item3(); 
            pictureBoxCoin.Top = rand.Next(350, 450);
            pictureBoxItem1.Top = rand.Next(350, 450);
        }
        public void Judge()
        {
            if (pictureBoxPlayer1.Bounds.IntersectsWith(pictureBoxObstacle1.Bounds))
            {
                Life--;
                progressBarLife.Step =-1;
                progressBarLife.PerformStep();
                if (Life < 0)
                {
                    isGameOver = true;
                }
               
            }
            if (pictureBoxPlayer1.Bounds.IntersectsWith(pictureBox20.Bounds))
            {
                Life--;
                progressBarLife.Step = -1;
                progressBarLife.PerformStep();
                if (Life < 0)
                {
                    isGameOver = true;

                }
            }
            if (pictureBoxPlayer1.Bounds.IntersectsWith(pictureBox19.Bounds))
            {
                Life--;
                progressBarLife.Step = -1;
                progressBarLife.PerformStep();
                if (Life < 0)
                {
                    isGameOver = true;
                }
                

            }
            if (pictureBoxPlayer1.Bounds.IntersectsWith(pictureBoxCoin.Bounds))
            {
                score++;
                pictureBoxCoin.Visible = false;
                progressBarScore.Step = 1;
                progressBarScore.PerformStep();
                
                if (score > 200)
                {
                    isGameFin = true;
                    
                }
                
            }
            if (pictureBoxPlayer1.Bounds.IntersectsWith(pictureBoxItem1.Bounds))
            {
               
                pictureBoxItem1.Visible = false;
                
            }
            if (pictureBoxPlayer1.Bounds.IntersectsWith(pictureBoxItem2.Bounds))
            {
                pictureBoxItem2.Visible = false;
            }
            if (pictureBoxPlayer1.Bounds.IntersectsWith(pictureBoxItem3.Bounds))
            {
                pictureBoxItem3.Visible = false;
            }
            
        }

        private void progressBar2_Click(object sender, EventArgs e)
        {

        }

        private void progressBarLife_Click(object sender, EventArgs e)
        {

        }
        private void exit_Click(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
        public void Check()
        {
           
        }

        private void GameStartScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            

        }
    }
}
