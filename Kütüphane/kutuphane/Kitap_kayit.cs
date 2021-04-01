using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace kutuphane
{
    public partial class Kitap_kayit : Form
    {
        SqlConnection baglan = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["baglanti"].ToString());
        public Kitap_kayit()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Kitap_kayit_Load(object sender, EventArgs e)
        {
            baglan.Open();
            SqlDataAdapter dadapter = new SqlDataAdapter("select * from kitapkayit", baglan);
            DataTable dtable = new DataTable();
            dadapter.Fill(dtable);
            dataGridView1.DataSource = dtable;
            baglan.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            numericUpDown1.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            anasayfa form = new anasayfa();
            form.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                baglan.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM kitapkayit WHERE id=@id", baglan);

                cmd.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value);

                cmd.ExecuteNonQuery();

                baglan.Close();


                SqlDataAdapter dadapter = new SqlDataAdapter("select * from kitapkayit", baglan);
                DataTable dtable = new DataTable();
                dadapter.Fill(dtable);
                dataGridView1.DataSource = dtable;

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                numericUpDown1.Text = "";

                MessageBox.Show("Kayıt Silindi.");

            }
            catch (SqlException)
            {
                MessageBox.Show("Hata olustu!");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            numericUpDown1.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();

            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || numericUpDown1.Text == "")
            {
                MessageBox.Show("Boş Alanları doldurunuz!");

            }
            else
            {
                try
                {
                    baglan.Open();

                    SqlCommand komut = new SqlCommand("INSERT INTO kitapkayit (kitap_no,kitap_adi,kitap_turu,basim_tarihi,yazar,yayin_evi,stok) VALUES (@kitapno,@kitapadi,@kitapturu,@basimtarihi,@yazar,@yayinevi,@stok)", baglan);
                    komut.Parameters.AddWithValue("@kitapno", textBox1.Text);
                    komut.Parameters.AddWithValue("@kitapadi", textBox2.Text);
                    komut.Parameters.AddWithValue("@kitapturu", textBox3.Text);
                    komut.Parameters.AddWithValue("@yazar", textBox4.Text);
                    komut.Parameters.AddWithValue("@yayinevi", textBox5.Text);
                    komut.Parameters.AddWithValue("@stok", numericUpDown1.Text);
                    komut.Parameters.AddWithValue("@basimtarihi", dateTimePicker1.Value);


                    komut.ExecuteNonQuery();

                    SqlDataAdapter dadapter = new SqlDataAdapter("select * from kitapkayit", baglan);
                    DataTable dtable = new DataTable();
                    dadapter.Fill(dtable);
                    dataGridView1.DataSource = dtable;

                    baglan.Close();
                    MessageBox.Show("Yeni Kayıt Oluştu.");


                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    numericUpDown1.Text = "";
                }



                catch (SqlException)
                {
                    MessageBox.Show("Hata olustu!");
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || numericUpDown1.Text == "")
            {
                MessageBox.Show("Boş Alanları doldurunuz!");

            }
            else
            {
                try
                {
                    baglan.Open();

                    SqlCommand komut = new SqlCommand("UPDATE kitapkayit SET kitap_no=@kitapno,kitap_adi=@kitapadi,kitap_turu=@kitapturu,yazar=@yazar,yayin_evi=@yayinevi,stok=@stok,basim_tarihi=@basimtarihi WHERE id=@id ", baglan);

                    komut.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value);

                    komut.Parameters.AddWithValue("@kitapno", textBox1.Text);
                    komut.Parameters.AddWithValue("@kitapadi", textBox2.Text);
                    komut.Parameters.AddWithValue("@kitapturu", textBox3.Text);
                    komut.Parameters.AddWithValue("@yazar", textBox4.Text);
                    komut.Parameters.AddWithValue("@yayinevi", textBox5.Text);
                    komut.Parameters.AddWithValue("@stok", numericUpDown1.Text);
                    komut.Parameters.AddWithValue("@basimtarihi", dateTimePicker1.Value);

                    komut.ExecuteNonQuery();

                    SqlDataAdapter dadapter = new SqlDataAdapter("select * from kitapkayit", baglan);
                    DataTable dtable = new DataTable();
                    dadapter.Fill(dtable);
                    dataGridView1.DataSource = dtable;

                    baglan.Close();
                    MessageBox.Show("Güncellendi.");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    numericUpDown1.Text = "";
                }



                catch (SqlException)
                {
                    MessageBox.Show("Hata olustu!");
                }
            }
        }
    }
}
