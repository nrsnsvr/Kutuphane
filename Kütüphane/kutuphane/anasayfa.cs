using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kutuphane
{
    public partial class anasayfa : Form
    {
        public anasayfa()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            uye_kayit frm1 = new uye_kayit();
            frm1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Kitap_kayit frm2 = new Kitap_kayit();
            frm2.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Kiralama frm3 = new Kiralama();
            frm3.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Teslim_alma frm4 = new Teslim_alma();
            frm4.Show();
            this.Hide();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void anasayfa_Load(object sender, EventArgs e)
        {

        }
    }
}
