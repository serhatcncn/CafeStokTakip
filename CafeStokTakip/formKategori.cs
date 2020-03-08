using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CafeStokTakip
{
    public partial class formKategori : Form
    {
        public formKategori()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-PL1DD4L\\SQLEXPRESS;Initial Catalog=StokTakip;Integrated Security=True");
        bool durum;
        private void kategorikontrol()
        {
            durum = true;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from kategoribilgileri", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                if (textBox1.Text==read["kategori"].ToString() || textBox1.Text == "")
                {
                    durum = false;
                }
            }
            baglanti.Close();
        }

        private void formKategori_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            kategorikontrol();
            if (durum == true)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into kategoribilgileri(kategori) values('" + textBox1.Text + "')", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                textBox1.Text = "";
                MessageBox.Show("Kategori Eklendi.");
            }
            else
            {
                MessageBox.Show("Böyle Bir Kategori Var.", "Uyarı!");
            }
            textBox1.Text = "";
        }
    }
}
