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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=TALHA_PC\\MSSQLSERVER02;Initial Catalog=PersonelVeritabani;Integrated Security=True;Encrypt=False;");

        public void temizle()
        {

            txtad.Text = "";
            txtmeslek.Text = "";
            txtsoyad.Text = "";
            mskmaas.Text = "";
            cmbsehir.Text = "";
            textperid.Text = "";
            radioButton1.Checked=false;
            radioButton2.Checked=false;
            txtad.Focus();

        }



        private void Form1_Load(object sender, EventArgs e)
        {
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State != ConnectionState.Open)
                    baglanti.Open();

                using (SqlCommand cmd = new SqlCommand("INSERT INTO Tbl_Personel (PerAd, PerSoyad,PerSehir,PerMaas,PerMeslek,PerDurum) VALUES (@p1, @p2,@p3,@p4,@p5,@p6)", baglanti))
                {
                    cmd.Parameters.AddWithValue("@p1", txtad.Text);
                    cmd.Parameters.AddWithValue("@p2", txtsoyad.Text);
                    cmd.Parameters.AddWithValue("@p3",cmbsehir.Text);
                    cmd.Parameters.AddWithValue("@p4", mskmaas.Text);
                    cmd.Parameters.AddWithValue("@p5", txtmeslek.Text);
                    cmd.Parameters.AddWithValue("@p6", radioButton1.Checked); // True/False olarak gider



                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Kayıt başarıyla eklendi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
            finally
            {
                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
            }





        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'personelVeritabaniDataSet.Tbl_Personel' table. You can move, or remove it, as needed.
            this.tbl_PersonelTableAdapter.Fill(this.personelVeritabaniDataSet.Tbl_Personel);
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {

            try
            {
                if (baglanti.State != ConnectionState.Open)
                    baglanti.Open();

                using (SqlCommand cmd = new SqlCommand("Update Tbl_Personel set PerAd= @p1,PerSoyad=@p2,PerSehir=@p3,PerMaas=@p4,PerDurum=@p6,PerMeslek=@p5 where Perid=@p0", baglanti))
                {
                    cmd.Parameters.AddWithValue("@p0", textperid.Text);
                    cmd.Parameters.AddWithValue("@p1", txtad.Text);
                    cmd.Parameters.AddWithValue("@p2", txtsoyad.Text);
                    cmd.Parameters.AddWithValue("@p3", cmbsehir.Text);
                    cmd.Parameters.AddWithValue("@p4", mskmaas.Text);
                    cmd.Parameters.AddWithValue("@p5", txtmeslek.Text);
                    cmd.Parameters.AddWithValue("@p6", radioButton1.Checked);



                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("güncellendi");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
            finally
            {
                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
            }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {



        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            


        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;


            textperid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString(); 

          txtad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtsoyad.Text= dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmbsehir.Text= dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            mskmaas.Text= dataGridView1.Rows[secilen].Cells[4].Value.ToString();


          



            txtmeslek.Text= dataGridView1.Rows[secilen].Cells[6].Value.ToString();
           


        }

        private void label8_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State != ConnectionState.Open)
                    baglanti.Open();

                using (SqlCommand cmd = new SqlCommand("delete from Tbl_Personel where Perid=@p1", baglanti))
                {

                    cmd.Parameters.AddWithValue("@p1", textperid.Text);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("istenilen deger silimdi");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
            finally
            {
                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
            }
        }

        private void btnistatistik_Click(object sender, EventArgs e)
        {
            Frmİstatistik frm =new Frmİstatistik();

            frm.ShowDialog();
        }
    }
}
