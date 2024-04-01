using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SporSalonuModern
{
    public partial class Sahip_Ana : Form
    {
        public Sahip_Ana()
        {
            InitializeComponent();

            btnUyeEkle.Parent = pictureBox1;
            btnUyeEkle.BackColor = Color.Transparent;
            btnSilGuncelle.Parent = pictureBox1;
            btnSilGuncelle.BackColor = Color.Transparent;
            btnUyeler.Parent = pictureBox1;
            btnUyeler.BackColor = Color.Transparent;
            BtnCikis.Parent = pictureBox1;
            BtnCikis.BackColor = Color.Transparent;
        }
        bool sidebarExpen;
        bool login;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (sidebarExpen)
            {
                sidebar.Width -= 10;
                btnSilGuncelle.Size = new Size(249, 176);
                btnUyeEkle.Size = new Size(249, 176);
                btnUyeler.Size = new Size(249, 176);
                BtnCikis.Size = new Size(249, 176);

                if (sidebar.Width == sidebar.MinimumSize.Width)
                {
                    sidebarExpen = false;
                    timer1.Stop();
                }
            }
            else
            {

                sidebar.Width += 10;
                btnSilGuncelle.Size = new Size(163, 142);
                btnUyeEkle.Size = new Size(163, 142);
                btnUyeler.Size = new Size(163, 142);
                BtnCikis.Size = new Size(163, 142);

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

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Coder by ybolatkiran", "github.com/ybolatkiran1", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Process.Start("https://github.com/ybolatkiran1");

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnUyeler_Click(object sender, EventArgs e)
        {
            Uye_Yönetimi form = new Uye_Yönetimi();
            form.Show();
            this.Hide();
        }

        private void btnUyeEkle_Click(object sender, EventArgs e)
        {
            Personel_Yönetimi form = new Personel_Yönetimi();
            form.Show();
            this.Hide();
        }

        private void btnSilGuncelle_Click(object sender, EventArgs e)
        {
            Ekipman_Yönetimi form = new Ekipman_Yönetimi();
            form.Show();
            this.Hide();
            
        }

        private void BtnCikis_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
    }
}
