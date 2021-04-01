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
    public partial class Kiralama : Form
    {
        SqlConnection baglan = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["baglanti"].ToString());
        public Kiralama()
        {
            InitializeComponent();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void Kiralama_Load(object sender, EventArgs e)
        {
            textBox3.Visible = false;
            dateTimePicker1.Enabled = false;

            dateTimePicker2.MinDate = DateTime.Today;
            
            
            baglan.Open();
            SqlDataAdapter dadapter = new SqlDataAdapter("select * from uyekayitt", baglan);
            DataTable dtable = new DataTable();
            dadapter.Fill(dtable);
            dataGridView1.DataSource = dtable;

            SqlDataAdapter dadapter2 = new SqlDataAdapter("select * from kitapkayit", baglan);
            DataTable dtable2 = new DataTable();
            dadapter2.Fill(dtable2);
            dataGridView2.DataSource = dtable2;
            baglan.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            anasayfa form = new anasayfa();
            form.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string adet12 = dataGridView2.CurrentRow.Cells[7].Value.ToString();
                        int adet13 = int.Parse(adet12);
                        if (adet13 > 0)
                        { 
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Boş Alanları doldurunuz!");

            }
            else
            {
                try
                {
                    baglan.Open();

                    SqlCommand komut = new SqlCommand("INSERT INTO kitapkirala (kitap_no,tc,kiralama_tarihi,teslim_tarihi,kitapid) VALUES (@kitapno,@tc,@kiralamatarihi,@teslimtarihi,@kitapid)", baglan);
                    komut.Parameters.AddWithValue("@kitapno", textBox1.Text);
                    komut.Parameters.AddWithValue("@tc", textBox2.Text);
                    komut.Parameters.AddWithValue("@kitapid", textBox3.Text);
                    komut.Parameters.AddWithValue("@kiralamatarihi", dateTimePicker1.Value);
                    komut.Parameters.AddWithValue("@teslimtarihi", dateTimePicker2.Value);


                    komut.ExecuteNonQuery();

                    string kitapid = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                   string adet= dataGridView2.CurrentRow.Cells[7].Value.ToString();
                   int adet1 = int.Parse(adet);
                   int adet2 = adet1 - 1;
                   string adet3 = Convert.ToString(adet2);
                   SqlCommand guncel = new SqlCommand("UPDATE kitapkayit SET stok=@adet4 WHERE id=@kitapid1 ", baglan);
                   guncel.Parameters.AddWithValue("@adet4", adet3);
                   guncel.Parameters.AddWithValue("@kitapid1", kitapid);
                   guncel.ExecuteNonQuery();

                    baglan.Close();
                    MessageBox.Show("Kiralama İşlemi Tamamlandı.");


                    textBox1.Text = "";
                    textBox2.Text = "";
                    SqlDataAdapter dadapter2 = new SqlDataAdapter("select * from kitapkayit", baglan);
                    DataTable dtable2 = new DataTable();
                    dadapter2.Fill(dtable2);
                    dataGridView2.DataSource = dtable2;
                }



                catch (SqlException)
                {
                    MessageBox.Show("Hata olustu!");
                }
            }
                        }
                        else { MessageBox.Show("Bu Kitap Stokta Yok"); }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
