using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Diagnostics;

namespace SporSalonuModern
{
    public partial class Trainer_Giriş : Form
    {
        bool sidebarExpen;
        bool login;
        public Trainer_Giriş()
        {
            InitializeComponent();
        }
        void PersonelGiris()
        {
            string query = "SELECT * FROM GirisTbl where PKullaniciAd=@p1 and PSifre=@p2";
            SQLiteConnection baglanti = new SQLiteConnection("Data source=.\\SporSalonu.db;Versiyon=3");
            baglanti.Open();
            SQLiteCommand cmd = new SQLiteCommand(query, baglanti);
            cmd.Parameters.AddWithValue("@p1", textBox1.Text);
            cmd.Parameters.AddWithValue("@p2", textBox2.Text);
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                string ad = dt.Rows[0]["PKullaniciAd"].ToString();
                MessageBox.Show($"Hoş geldiniz, {ad}!", "Giriş Başarılı!", MessageBoxButtons.OK, MessageBoxIcon.None);
                Trainer_Ana form = new Trainer_Ana();
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Giriş Başarısız!","Tekrar Dene!",MessageBoxButtons.OK);
            }
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (sidebarExpen)
            {
                sidebar.Width -= 20;
                //panel2.Location = new Point(236,350);
                //pictureBox3.Size = new Size(544, 343);
                //pictureBox3.Location = new Point(236, 12);

                if (sidebar.Width == sidebar.MinimumSize.Width)
                {
                    sidebarExpen = false;
                    timer1.Stop();
                }
            }
            else
            {

                sidebar.Width += 20;
                //pictureBox3.Location = new Point(396, 36);
                //panel2.Location = new Point(417,385);
                if (sidebar.Width == sidebar.MaximumSize.Width)
                {
                    sidebarExpen = true;
                    timer1.Stop();
                }
            }
        }

        private void menubutton_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show("Coder by ybolatkiran", "github.com/ybolatkiran1", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Process.Start("https://github.com/ybolatkiran1");
        }


        private void button4_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (login)
            {
                homecontainer.Height += 20;
                
                
                if (homecontainer.Height == homecontainer.MaximumSize.Height)
                {
                    login = false;
                    timer2.Stop();
                }
            }
            else
            {
                homecontainer.Height -= 20;
                
                if (homecontainer.Height == homecontainer.MinimumSize.Height)
                {
                    login = true;
                    timer2.Stop();

                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            PersonelGiris();
        }

        private void btnSahip_Click(object sender, EventArgs e)
        {
            Sahip_Giriş form = new Sahip_Giriş();
            form.Show();
            this.Hide();
        }
        //küçük ekranda panel 249; 36
        // büyük ekranda panel 726; 529
        private void timer3_Tick(object sender, EventArgs e)
        {
            
        }
        
    }
    }

