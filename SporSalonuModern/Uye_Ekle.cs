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
using System.Data.SQLite;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics;

namespace SporSalonuModern
{
    public partial class Uye_Ekle : Form
    {
        public Uye_Ekle()
        {
            InitializeComponent();
        }
        bool sidebarExpend;
        bool login;
        private void timer1_Tick(object sender, EventArgs e)
        {

            if (sidebarExpend)
            {

                sidebar.Width -= 20;
                
                //label2.Location = new Point(139,360);
                //pictureBox3.Location = new Point(263, 59);
                if (sidebar.Width == sidebar.MinimumSize.Width)
                {
                    sidebarExpend = false;
                    timer1.Stop();
                    

                }
            }
            else
            {

                sidebar.Width += 20;
                
                //label2.Location = new Point(252,376);
                //pictureBox3.Location = new Point(385, 93);
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
            Form1 form= new Form1();
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

        private void sidebar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (txtAd.Text == "" || txtTel.Text == "" || txtTutar.Text == "" || txtYas.Text == "" || cmbCins.Text == "" || cmbZaman.Text == "")
            {
                MessageBox.Show("Eksik Kayıt İşlemi!");
            }
            else
            {
                UyeKaydi();
            }
            
        }
        void UyeKaydi()
        {
            string query = "insert into UyeTbl (UAdSoyad,UTelefon,UCinsiyet,UTutar,Uzaman,UYas) values (@p1,@p2,@p3,@p4,@p5,@p6)";
            SQLiteConnection baglanti = new SQLiteConnection("Data source=.\\SporSalonu.db;Versiyon=3");
            baglanti.Open();
            SQLiteCommand cmd = new SQLiteCommand(query, baglanti);
            cmd.Parameters.AddWithValue("@p1", txtAd.Text);
            cmd.Parameters.AddWithValue("@p2", txtTel.Text);
            cmd.Parameters.AddWithValue("@p3", cmbCins.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@p4", txtTutar.Text);
            cmd.Parameters.AddWithValue("@p5", cmbZaman.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@p6", txtYas.Text);
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            MessageBox.Show("Üye Başarıyla Eklendi!");
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            Trainer_Ana form = new Trainer_Ana();
            form.Show();
            this.Hide();
        }
    }
}
