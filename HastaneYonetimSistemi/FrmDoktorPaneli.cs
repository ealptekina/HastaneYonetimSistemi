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

namespace HastaneYonetimSistemi
{
    public partial class FrmDoktorPaneli : Form
    {
        public FrmDoktorPaneli()
        {
            InitializeComponent();
        }

        sqlBaglantisi bgl = new sqlBaglantisi();

        private void FrmDoktorPaneli_Load(object sender, EventArgs e)
        {


            // DataTable oluşturuluyor
            DataTable dt = new DataTable();

            // Veritabanı bağlantısı için SQL komutu parametre kullanılarak oluşturuluyor
            SqlDataAdapter da = new SqlDataAdapter("select * from Doktor", bgl.baglanti());

            // DataTable dolduruluyor
            da.Fill(dt);

            // DataGridView'e DataTable atanıyor
            dataGridView1.DataSource = dt;

            #region Brans Combobox Doldurma
            // Branşları ComboBox'a dolduruyoruz
            SqlCommand komutBrans = new SqlCommand("SELECT BransAd FROM Brans", bgl.baglanti());
            SqlDataReader drBrans = komutBrans.ExecuteReader();
            while (drBrans.Read())
            {
                comboBoxBrans.Items.Add(drBrans[0]);
            }
            bgl.baglanti().Close();
            #endregion
        }

        //Kaydet Butonu
        private void buttonEkle_Click(object sender, EventArgs e)
        {
            SqlCommand komutEkle = new SqlCommand("insert into Doktor (DoktorAd,DoktorSoyad,DoktorBrans,DoktorTC,DoktorSifre) values (@d1,@d2,@d3,@d4,@d5)", bgl.baglanti());
            komutEkle.Parameters.AddWithValue("@d1", textBoxAd.Text);
            komutEkle.Parameters.AddWithValue("@d2", textBoxSoyad.Text);
            komutEkle.Parameters.AddWithValue("@d3", comboBoxBrans.Text);
            komutEkle.Parameters.AddWithValue("@d4",textBoxTC.Text);
            komutEkle.Parameters.AddWithValue("@d5", textBoxSifre.Text);

            komutEkle.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Doktor Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // datagridde herhangi bir hücreye tıklayınca form alanına ilgili verileri aktarıyor.
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBoxTC.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textBoxAd.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            textBoxSoyad.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            comboBoxBrans.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            textBoxSifre.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
        }

        // Sil Butonu
        private void buttonSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutSil = new SqlCommand("delete from Doktor where DoktorTC=@p1",bgl.baglanti());
            komutSil.Parameters.AddWithValue("@p1",textBoxTC.Text);
            komutSil.ExecuteNonQuery();

            bgl.baglanti().Close();
            MessageBox.Show("Kayıt Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        //Güncelle Butonu
        private void buttonDuzenlemeKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komutGuncelle = new SqlCommand("update Doktor set DoktorAd=@d1,DoktorSoyad=@d2,DoktorBrans=@d3,doktorSifre=@d5 where DoktorTC=@d4", bgl.baglanti());
            komutGuncelle.Parameters.AddWithValue("@d1", textBoxAd.Text);
            komutGuncelle.Parameters.AddWithValue("@d2", textBoxSoyad.Text);
            komutGuncelle.Parameters.AddWithValue("@d3", comboBoxBrans.Text);
            komutGuncelle.Parameters.AddWithValue("@d4", textBoxTC.Text);
            komutGuncelle.Parameters.AddWithValue("@d5", textBoxSifre.Text);
            
            komutGuncelle.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Doktor Bilgisi Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
