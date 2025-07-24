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
    public partial class Frmİstatistik : Form
    {
        public Frmİstatistik()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=TALHA_PC\\MSSQLSERVER02;Initial Catalog=PersonelVeritabani;Integrated Security=True;Encrypt=False;");
        private void Frmİstatistik_Load(object sender, EventArgs e)
        {


            try
            {
                using (SqlConnection baglanti = new SqlConnection("Data Source=TALHA_PC\\MSSQLSERVER02;Initial Catalog=PersonelVeritabani;Integrated Security=True;Encrypt=False;"))
                {
                    baglanti.Open();

                    // 1. Toplam personel sayısı
                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Tbl_Personel", baglanti))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                            label2.Text = reader[0].ToString();
                    }

                    // 2. Aktif personel sayısı (PerDurum = 1)
                    using (SqlCommand cmd2 = new SqlCommand("SELECT COUNT(*) FROM Tbl_Personel WHERE PerDurum = 1", baglanti))
                    using (SqlDataReader reader2 = cmd2.ExecuteReader())
                    {
                        if (reader2.Read())
                            label3.Text = reader2[0].ToString();
                    }

                    // 3. Pasif personel sayısı (PerDurum = 0)
                    using (SqlCommand cmd3 = new SqlCommand("SELECT COUNT(*) FROM Tbl_Personel WHERE PerDurum = 0", baglanti))
                    using (SqlDataReader reader3 = cmd3.ExecuteReader())
                    {
                        if (reader3.Read())
                            label5.Text = reader3[0].ToString(); // Örnek: label4 pasif personel
                    }


                    using (SqlCommand cmd3 = new SqlCommand("select count(distinct(persehir)) from tbl_personel" , baglanti))
                    using(SqlDataReader reader4 = cmd3.ExecuteReader())
                    {

                        if(reader4.Read())
                        {

                            label7.Text = reader4[0].ToString();


                        }
                    }

                    using (SqlCommand cmd3 = new SqlCommand("select sum(permaas) from tbl_personel", baglanti))
                    using (SqlDataReader reader4 = cmd3.ExecuteReader())
                    {


                        if(reader4.Read())
                        {

                            label9.Text = reader4[0].ToString();
                        }


                    }




                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
        }




   

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {
        
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
