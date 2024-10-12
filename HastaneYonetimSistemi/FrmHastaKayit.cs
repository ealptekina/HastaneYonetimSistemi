using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HastaneYonetimSistemi
{
    public partial class FrmHastaKayit : Form
    {
        public FrmHastaKayit()
        {
            InitializeComponent();
        }

        // sqlBaglantisi nesnesi oluşturuluyor
        sqlBaglantisi bgl = new sqlBaglantisi();

        private void buttonKayitYap_Click(object sender, EventArgs e)
        {
            try
            {
                // Bağlantıyı bir değişkende tutarak, işlem sonunda kapatma işlemi yapacağız
                SqlConnection connection = bgl.baglanti();

                // SQL komutunu hazırlıyoruz, parametrelerle birlikte
                SqlCommand komut = new SqlCommand("insert into Hasta (HastaTC, HastaAd, HastaSoyad, HastaCinsiyet, HastaTelefon, HastaSifre) values (@h1, @h2, @h3, @h4, @h5, @h6)", connection);
                komut.Parameters.AddWithValue("@h1", textBoxTC.Text);
                komut.Parameters.AddWithValue("@h2", textBoxAd.Text);
                komut.Parameters.AddWithValue("@h3", textBoxSoyad.Text);
                komut.Parameters.AddWithValue("@h4", comboBoxCinsiyet.Text);
                komut.Parameters.AddWithValue("@h5", maskedTextBoxTelefon.Text);
                komut.Parameters.AddWithValue("@h6", textBoxSifre.Text);

                // Komutu çalıştırıyoruz ve etkilenen satır sayısını kontrol ediyoruz
                int etkilenenSatir = komut.ExecuteNonQuery();

                // Eğer en az bir satır etkilenmişse, başarılı mesajı göster
                if (etkilenenSatir > 0)
                {
                    MessageBox.Show("Hasta Kayıt İşlemi Başarılı!" + " " + textBoxSifre.Text, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Kayıt yapılamadı, lütfen bilgilerinizi kontrol edin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Bağlantıyı kapatıyoruz
                connection.Close();
            }
            catch (Exception ex)
            {
                // Hata mesajını göster
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
