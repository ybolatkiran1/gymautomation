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
    public partial class Personel_Yönetimi : Form
    {
        SQLiteConnection baglanti = new SQLiteConnection("Data source=.\\SporSalonu.db;Versiyon=3");
        public Personel_Yönetimi()
        {
            InitializeComponent();
            Listele();
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

        private void menubutton_Click(object sender, EventArgs e)
        {
            timer1.Start();
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

        private void btnTrainer_Click(object sender, EventArgs e)
        {
            Trainer_Giriş form = new Trainer_Giriş();
            form.Show();
            this.Hide();
        }

        private void btnSahip_Click(object sender, EventArgs e)
        {
            Sahip_Giriş form = new Sahip_Giriş();
            form.Show();
            this.Hide();
        }
        void Listele()
        {
            string sql = "Select * From GirisTbl";
            baglanti.Open();
            DataTable dt = new DataTable();
            SQLiteDataAdapter adtr = new SQLiteDataAdapter(sql, baglanti);
            adtr.Fill(dt);
            dataGridView1.DataSource = dt;
            Temizle();
            baglanti.Close();
        }
        void Güncelle()
        {
            string sql = "UPDATE GirisTbl SET PKullaniciAd=@a1, PSifre=@a2 WHERE PId=@a3";
            baglanti.Open();
            SQLiteCommand cmd = new SQLiteCommand(sql,baglanti);
            cmd.Parameters.AddWithValue("@a1", txtKullaniciAdi.Text);
            cmd.Parameters.AddWithValue("@a2",txtSifre.Text);
            cmd.Parameters.AddWithValue("@a3", txtId.Text);
            cmd.ExecuteNonQuery();            
            MessageBox.Show("Personel Başarıyla Güncellendi!");
            Temizle();
            baglanti.Close();
            Listele();
        }
        void Temizle()
        {
            txtId.Text = "";
            txtKullaniciAdi.Text = "";
            txtSifre.Text = "";
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            Method(txtId, secilen, 0);
            Method(txtKullaniciAdi, secilen, 1);
            Method(txtSifre, secilen, 2);
        }
        private void Method(Control control , int secilen , int i)
        {
            control.Text = dataGridView1.Rows[secilen].Cells[i].Value.ToString();
        }

        void PersonelKaydi()
        {
            string sql = "INSERT INTO GirisTbl (PKullaniciAd, PSifre) VALUES (@a1, @a2)";
            baglanti.Open();
            SQLiteCommand cmd = new SQLiteCommand(sql, baglanti);
            cmd.Parameters.AddWithValue("@a1", txtKullaniciAdi.Text);
            cmd.Parameters.AddWithValue("@a2", txtSifre.Text);
            

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Üye Başarıyla Eklendi!");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                
                baglanti.Close();
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            if (txtKullaniciAdi.Text == "" || txtSifre.Text == "")
            {
                MessageBox.Show("Eksik Bilgi Girdiniz!");

            }
            else
            {
                PersonelKaydi();
                Temizle();
                Listele();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult diar = MessageBox.Show("Personeli Silmek İstiyormusunuz?", "Onayla", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (diar == DialogResult.Yes)
            {
                PersonelSil();
                Temizle();
                Listele();
            }
        }
        void PersonelSil()
        {
            baglanti.Open();
            SQLiteCommand komutsil = new SQLiteCommand("Delete From GirisTbl where PId=@k1", baglanti);
            komutsil.Parameters.AddWithValue("@k1", txtId.Text);
            try
            {
                komutsil.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Personel Başarıyla Silindi!");
                
            }
            catch(Exception ex) 
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            Güncelle();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Sahip_Ana form = new Sahip_Ana();
            form.Show();
            this.Hide();
        }
    }
}
