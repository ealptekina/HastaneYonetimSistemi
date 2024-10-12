using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HastaneYonetimSistemi
{
    public partial class FrmHastaDetay : Form
    {
        public FrmHastaDetay()
        {
            InitializeComponent();
        }

        // Hastanın TC kimlik numarası
        public string tc;

        // Veritabanı bağlantısı
        sqlBaglantisi bgl = new sqlBaglantisi();

        private void FrmHastaDetay_Load(object sender, EventArgs e)
        {
            #region Kullanıcının TC kimlik numarasını ekranda gösteriyoruz

            labelTC.Text = tc;

            // Hasta tablosundan HastaAd ve HastaSoyad bilgilerini çekmek için SQL komutu
            SqlCommand komut = new SqlCommand("select HastaAd, HastaSoyad from Hasta where HastaTC=@h1", bgl.baglanti());
            komut.Parameters.AddWithValue("@h1", labelTC.Text);

            // Komutu çalıştırıp sonucu okuyacak bir SqlDataReader oluşturuyoruz
            SqlDataReader dr = komut.ExecuteReader();

            // Veritabanından gelen bilgileri okuyup etiketlere yazıyoruz
            while (dr.Read())
            {
                labelAdSoyad.Text = dr["HastaAd"] + " " + dr["HastaSoyad"];
            }

            bgl.baglanti().Close();

            #endregion

            #region Randevu Geçmişi

            // DataTable oluşturuluyor
            DataTable dt = new DataTable();

            // Veritabanı bağlantısı için SQL komutu parametre kullanılarak oluşturuluyor
            SqlDataAdapter da = new SqlDataAdapter("select * from Randevu where HastaTC=" + tc, bgl.baglanti());

            // DataTable dolduruluyor
            da.Fill(dt);

            // DataGridView'e DataTable atanıyor
            dataGridView1.DataSource = dt;
            #endregion

            #region Branşları Çekme

            SqlCommand komutBrans = new SqlCommand("select BransAd from Brans", bgl.baglanti());

            // Komutu çalıştırıp sonucu okuyacak bir SqlDataReader oluşturuyoruz
            SqlDataReader brBrans = komutBrans.ExecuteReader();

            while (brBrans.Read())
            {
                comboBoxBrans.Items.Add(brBrans["BransAd"]);
            }

            bgl.baglanti().Close();

            #endregion


        }

        private void comboBoxBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region Doktorları Çekme

            comboBoxDoktor.Items.Clear();

            // Seçilen branşa göre SQL sorgusu yapıyoruz
            SqlCommand komutDoktor = new SqlCommand("select DoktorAd, DoktorSoyad from Doktor where DoktorBrans=@p1", bgl.baglanti());

            // @p1 parametresine, seçilen branşın adını ekliyoruz
            komutDoktor.Parameters.AddWithValue("@p1", comboBoxBrans.Text);

            // Komutu çalıştırıp sonucu okuyacak bir SqlDataReader oluşturuyoruz
            SqlDataReader drDoktor = komutDoktor.ExecuteReader();

            // Doktor ad ve soyadlarını comboBox'a ekliyoruz
            while (drDoktor.Read())
            {
                comboBoxDoktor.Items.Add(drDoktor["DoktorAd"].ToString() + " " + drDoktor["DoktorSoyad"].ToString());
            }

            // SqlDataReader işini bitirdikten sonra bağlantıyı kapatıyoruz
            drDoktor.Close();
            bgl.baglanti().Close();

            #endregion
        }



        private void comboBoxDoktor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Randevu where RandevuBrans = '" + comboBoxBrans.Text + "'" + " and RandevuDoktor ='" + comboBoxDoktor.Text + "' and RandevuDurum =0", bgl.baglanti());
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void linkLabelBilgileriniDuzenle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmBilgiDuzenle frmBilgiDuzenle = new FrmBilgiDuzenle();
            frmBilgiDuzenle.TcNo = labelTC.Text;
            frmBilgiDuzenle.Show();

        }

        private void buttonRandevuAl_Click(object sender, EventArgs e)
        {

            SqlCommand komutGuncelle = new SqlCommand("update Randevu set RandevuDurum=1,HastaTC=@d1,Sikayet=@d2 where RandevuId=@d3", bgl.baglanti());
            komutGuncelle.Parameters.AddWithValue("@d1", labelTC.Text);
            komutGuncelle.Parameters.AddWithValue("@d2", richTextBoxSikayet.Text);
            komutGuncelle.Parameters.AddWithValue("@d3", textBoxRandevuID.Text);

            komutGuncelle.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Randevu Alındı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView2.SelectedCells[0].RowIndex;
            textBoxRandevuID.Text= dataGridView2.Rows[secilen].Cells[0].Value.ToString();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
