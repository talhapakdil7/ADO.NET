using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class GirisSayfa : Form
    {
        public GirisSayfa()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=TALHA_PC\\MSSQLSERVER02;Initial Catalog=PersonelVeritabani;Integrated Security=True;Encrypt=False;");
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void GirisSayfa_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            baglanti.Open();

            SqlCommand cmd = new SqlCommand("select *from Yonetici where kullaniciAd=@p1 and sifre=@p2",baglanti);


            cmd.Parameters.AddWithValue("@p1",textBox1.Text);
            cmd.Parameters.AddWithValue("@p2", textBox2.Text);


            SqlDataReader rd=  cmd.ExecuteReader();


            if (rd.Read())
            {

                Form1 form = new Form1();

                form.Show();

                this.Hide();
            }

            else
            {

                MessageBox.Show("hatalı kullanıcı");
            }

            baglanti.Close();

        }
    }
}
