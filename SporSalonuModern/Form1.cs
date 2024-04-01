using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Diagnostics;

namespace SporSalonuModern
{
    public partial class Form1 : Form
    {
        bool sidebarExpend;
        bool login;
      
        public Form1()
        {
            InitializeComponent();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (sidebarExpend)
            {
                
                sidebar.Width -= 20;
                //label2.Location = new Point(139,360);
                //pictureBox3.Location = new Point(263, 59);
                if (sidebar.Width==sidebar.MinimumSize.Width)
                {
                    sidebarExpend = false;
                    timer1.Stop();
                    timer4.Start();

                }
            }
            else
            {
                
                sidebar.Width += 20;
                label2.Visible = false;
                //label2.Location = new Point(252,376);
                //pictureBox3.Location = new Point(385, 93);
                if (sidebar.Width==sidebar.MaximumSize.Width) {
                    label2.Visible = true;
                    sidebarExpend = true;

                    timer1.Stop();

                    timer3.Start();
                    
                    
                }
            }
            
            
        }

        

        

        private void menubutton_Click_1(object sender, EventArgs e)
        {
            
            timer1.Start();
            
            
            //timer3.Start();





        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (login)
            {
                homecontainer.Height += 20;
                if(homecontainer.Height==homecontainer.MaximumSize.Height) 
                { 
                    login=false;
                    timer2.Stop();
                }
            }
            else
            {
                homecontainer.Height -= 20;
                if (homecontainer.Height == homecontainer.MinimumSize.Height)
                {
                    login=true;
                    timer2.Stop();

                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }
        
        private void btnTrainer_Click(object sender, EventArgs e)
        {
            Trainer_Giriş form = new Trainer_Giriş();
            form.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            MessageBox.Show("Coder by ybolatkiran","github.com/ybolatkiran1",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            Process.Start("https://github.com/ybolatkiran1");
        }

        private void btnSahip_Click(object sender, EventArgs e)
        {
            Sahip_Giriş form = new Sahip_Giriş();
            form.Show();
            this.Hide();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            Animasyon();
        }
       
        //büyük ekranda picturebox 263; 45 
        //küçük ekranda picturebox 385, 93
        //büyük ekranda label 139,360
        //küçük ekranda label 252,376

        private void timer4_Tick(object sender, EventArgs e)
        {
            GeriAnimasyon();
        }
         public void Animasyon()
        {
            
            for (int i = 0; i < pictureBox3.Location.X; i++)
            {
                int a = pictureBox3.Location.X;
                a = a + 1;
                pictureBox3.Location = new Point(a, 45);
                if (a == 385)
                {
                    break;
                }

            }
            for (int i = 0; i < pictureBox3.Location.Y; i++)
            {
                int b = pictureBox3.Location.Y;
                b = b + 1;
                pictureBox3.Location = new Point(385, b);
                if (b == 95)
                {
                    break;
                }
                
                for (int a = 0; a < label2.Location.X; a++)
                {
                    int c = label2.Location.X;
                    c = c + 1;
                    label2.Location = new Point(c, 360);
                    if (c > 252)
                    {
                        break;
                    }
                    
                }
                for (int a = 0; a < label2.Location.Y; a++)
                {
                    int c = label2.Location.Y;
                    c = c + 1;
                    label2.Location = new Point(252, c);
                    if (c > 376)
                    {
                        break;
                    }
                }
            }
            timer3.Stop();
        }
        public void GeriAnimasyon()
        {
            for (int i = 0; i < pictureBox3.Location.X; i++)
            {
                int a = pictureBox3.Location.X;
                a = a - 1;


                pictureBox3.Location = new Point(a, 45);
                if (a < 263)
                {
                    break;
                }

            }
            for (int i = 0; i < pictureBox3.Location.Y; i++)
            {
                int a = pictureBox3.Location.Y;
                a = a - 1;


                pictureBox3.Location = new Point(263, a);
                if (a < 263)
                {
                    break;
                }

            }
            for (int i = 0; i < label2.Location.X; i++)
            {
                int a = label2.Location.X;
                a = a - 1;
                label2.Location = new Point(a, 376);
                if (a < 139) { break; }

                timer4.Stop();
            }
            for (int i = 0; i < label2.Location.Y; i++)
            {
                int a = label2.Location.Y;
                a = a - 1;
                label2.Location = new Point(139, a);
                if (a < 360) { break; }

                timer4.Stop();
            }
        
    }
    }
}
