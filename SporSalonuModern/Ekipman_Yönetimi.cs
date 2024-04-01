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
    public partial class Ekipman_Yönetimi : Form
    {
        public Ekipman_Yönetimi()
        {
            InitializeComponent();
            Listele();
            txtEkipmanAdet.Text = "0";
        }
        SQLiteConnection baglanti = new SQLiteConnection("Data source=.\\SporSalonu.db;Versiyon=3");
        bool sidebarExpen;
        bool login;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (sidebarExpen)
            {
                sidebar.Width -= 10;
                

                if (sidebar.Width == sidebar.MinimumSize.Width)
                {
                    sidebarExpen = false;
                    timer1.Stop();
                }
            }
            else
            {

                sidebar.Width += 10;
                

                if (sidebar.Width == sidebar.MaximumSize.Width)
                {
                    sidebarExpen = true;
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
        void Listele()
        {
            string sql = "Select * From EkipmanTbl";
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
            string sql = "UPDATE EkipmanTbl SET EkipmanAdı=@a1, Adet=@a2 WHERE EId=@a3";
            baglanti.Open();
            SQLiteCommand cmd = new SQLiteCommand(sql, baglanti);
            cmd.Parameters.AddWithValue("@a1", txtEkipmanAdi.Text);
            cmd.Parameters.AddWithValue("@a2", txtEkipmanAdet.Text);
            cmd.Parameters.AddWithValue("@a3", txtEkipmanId.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Ekipman Başarıyla Güncellendi!");
            Temizle();
            baglanti.Close();
            Listele();
        }
        void Temizle()
        {
            txtEkipmanAdet.Text = "";
            txtEkipmanAdi.Text = "";
            txtEkipmanId.Text = "";
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            Method(txtEkipmanId, secilen, 0);
            Method(txtEkipmanAdi, secilen, 1);
            Method(txtEkipmanAdet, secilen, 2);
        }
        private void Method(Control control , int secilen , int i)
        {
            control.Text = dataGridView1.Rows[secilen].Cells[i].Value.ToString();
        }
        void Ekle()
        {
            string sql = "insert into EkipmanTbl (EkipmanAdı,Adet) values (@p1,@p2)";
            baglanti.Open();
            SQLiteCommand cmd = new SQLiteCommand(sql,baglanti);
            cmd.Parameters.AddWithValue("@p1", txtEkipmanAdi.Text);
            cmd.Parameters.AddWithValue("@p2", txtEkipmanAdet.Text);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Ekipman Başarıyla Eklendi!");

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

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (txtEkipmanAdet.Text == "" || txtEkipmanAdi.Text == "")
            {
                MessageBox.Show("Eksik Bilgi Girdiniz!");

            }
            else
            {
                Ekle();
                Temizle();
                Listele();
            }
            
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            DialogResult diar = MessageBox.Show("Ekipmanı Güncellemek İstiyormusunuz?", "Onayla", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (diar == DialogResult.Yes)
            {
                Güncelle();
                Temizle();
                Listele();
            }
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult diar = MessageBox.Show("Ekipmanı Silmek İstiyormusunuz?", "Onayla", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (diar == DialogResult.Yes)
            {
                EkipmanSil();
                Temizle();
                Listele();
            }
        }
        void EkipmanSil()
        {
            baglanti.Open();
            SQLiteCommand komutsil = new SQLiteCommand("Delete From EkipmanTbl where EId=@k1", baglanti);
            komutsil.Parameters.AddWithValue("@k1", txtEkipmanId.Text);
            try
            {
                komutsil.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Ekipman Başarıyla Silindi!");

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

        private void button5_Click(object sender, EventArgs e)
        {
            Sahip_Ana form = new Sahip_Ana();
            form.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void btnArttır_Click(object sender, EventArgs e)
        {
            
            int i = Convert.ToInt32(txtEkipmanAdet.Text);
            i++;
            txtEkipmanAdet.Text= i.ToString();

        }

        private void btnAzalt_Click(object sender, EventArgs e)
        {
            
            int i = Convert.ToInt32(txtEkipmanAdet.Text);
            i--;
            txtEkipmanAdet.Text = i.ToString();
        }
    }
}
