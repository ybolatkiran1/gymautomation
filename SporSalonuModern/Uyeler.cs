using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SporSalonuModern
{
    
    public partial class Uyeler : Form
    {
        SQLiteConnection baglanti = new SQLiteConnection("Data source=.\\SporSalonu.db;Versiyon=3");
        
        public Uyeler()
        {
            InitializeComponent();
            Üyeler();
             
        }
        bool sidebarExpend;
        bool login;
        SidebarAnimasyon animasyon = new SidebarAnimasyon();

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (sidebarExpend)
            {
                sidebar.Width -= 20;
                if (sidebar.Width == sidebar.MinimumSize.Width)
                {
                    sidebarExpend = false;
                    timer1.Stop();
                }
            }
            else
            {
                sidebar.Width += 20;
                if (sidebar.Width == sidebar.MaximumSize.Width)
                {
                    sidebarExpend = true;
                    timer1.Stop();
                }
            }
        }

        private void menubutton_Click(object sender, EventArgs e)
        {
            timer1.Start();

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

        private void btnSahip_Click(object sender, EventArgs e)
        {
            Sahip_Giriş form = new Sahip_Giriş();
            form.Show();
            this.Hide();
        }

        private void btnTrainer_Click(object sender, EventArgs e)
        {
            Trainer_Giriş form = new Trainer_Giriş();
            form.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        void Üyeler()
        {
            string sql = "Select * from UyeTbl";
            SQLiteConnection baglanti = new SQLiteConnection("Data source=.\\SporSalonu.db;Versiyon=3");
            baglanti.Open();
            DataTable dt=new DataTable();
            SQLiteDataAdapter adtr = new SQLiteDataAdapter(sql, baglanti);
            adtr.Fill(dt);
            dataGridView1.DataSource = dt;
        }

       

        private void button5_Click_2(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            Trainer_Ana form =new Trainer_Ana();
            form.Show();
            this.Hide();
        }
    }
    
}
