using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SporSalonuModern
{
    public partial class UyeSil_Guncelle : Form
    {
        SQLiteConnection baglanti = new SQLiteConnection("Data source=.\\SporSalonu.db;Versiyon=3");

        bool sidebarExpend;
        bool login;
        public UyeSil_Guncelle()
        {
            InitializeComponent();
            Listele();
        }

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

        void Listele()
        {
            string sql = "Select * from UyeTbl";
            SQLiteConnection baglanti = new SQLiteConnection("Data source=.\\SporSalonu.db;Versiyon=3");
            baglanti.Open();
            DataTable dt = new DataTable();
            SQLiteDataAdapter adtr = new SQLiteDataAdapter(sql, baglanti);
            adtr.Fill(dt);
            dataGridView1.DataSource = dt;
            Temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            Method(txtId, secilen, 0);
            Method(txtAdSoyad, secilen, 1);
            Method(txtTelefon, secilen, 2);
            Method(txtYas, secilen, 6);
            Method(cmbCins, secilen, 3);
            Method(txtÜcret, secilen, 4);
            Method(cmbZaman, secilen, 5);
        }
        private void Method(Control control, int secilen, int i)
        {
            control.Text = dataGridView1.Rows[secilen].Cells[i].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Listele();
        }
        void Guncelle()
        {
            string query = "Update UyeTbl Set UAdSoyad=@a1,UTelefon=@a2,UYas=@a6,UCinsiyet=@a3,UTutar=@a4,Uzaman=@a5 where UId=@a7";
            baglanti.Open();
            SQLiteCommand cmd= new SQLiteCommand(query,baglanti);
            cmd.Parameters.AddWithValue("@a1",txtAdSoyad.Text);
            cmd.Parameters.AddWithValue("@a2",txtTelefon.Text);
            cmd.Parameters.AddWithValue("@a6", txtYas.Text);
            cmd.Parameters.AddWithValue("@a3",cmbCins.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@a4", txtÜcret.Text);
            cmd.Parameters.AddWithValue("@a5",cmbZaman.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@a7", txtId.Text);
            cmd.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Üye Başarıyla Güncellendi!");
            Temizle();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            DialogResult diar = MessageBox.Show("Üyeyi Güncellemek İstiyormusunuz?", "Onayla", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (diar == DialogResult.Yes) { Guncelle(); }
        }
        void Temizle()
        {
            txtId.Text = "";
            txtAdSoyad.Text = "";
            txtTelefon.Text = "";
            txtYas.Text = "";
            txtÜcret.Text = "";
            txtTelefon.Text = "";
            cmbCins.Text = "";
            cmbZaman.Text = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult diar=  MessageBox.Show("Üyeyi Silmek İstiyormusunuz?","Onayla",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(diar==DialogResult.Yes)
            {
                baglanti.Open();
                SQLiteCommand komutsil = new SQLiteCommand("Delete From UyeTbl where UId=@k1", baglanti);
                komutsil.Parameters.AddWithValue("@k1", txtId.Text);
                komutsil.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Üye Başarıyla Silindi!");
                Temizle();
            }
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Trainer_Ana form = new Trainer_Ana();
            form.Show();
            this.Hide();
        }
    }
    
}
