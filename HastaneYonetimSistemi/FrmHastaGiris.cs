using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HastaneYonetimSistemi
{
    public partial class FrmHastaGiris : Form
    {
        public FrmHastaGiris()
        {
            InitializeComponent();
        }

        sqlBaglantisi bgl = new sqlBaglantisi();

        private void linkLabelUyeOl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Yeni hasta kayıt formunu açar
            FrmHastaKayit frmHastaKayit = new FrmHastaKayit();
            frmHastaKayit.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from Hasta where HastaTC=@h1 and HastaSifre=@h2", bgl.baglanti());

            // Kullanıcının girdiği verileri parametre olarak ekliyoruz
            komut.Parameters.AddWithValue("@h1", maskedTextBoxTCNo.Text);
            komut.Parameters.AddWithValue("@h2", textBoxSifre.Text);

            // Komutu çalıştırıp sonucu okuyacak bir SqlDataReader oluşturuyoruz
            SqlDataReader dr = komut.ExecuteReader();

            // Eğer eşleşen kayıt bulunursa giriş başarılı
            if (dr.Read())
            {
                FrmHastaDetay frmHastaDetay = new FrmHastaDetay();
                frmHastaDetay.tc = maskedTextBoxTCNo.Text;
                frmHastaDetay.Show();
                this.Hide(); // Şu anki formu gizle
            }
            else
            {
                // Hatalı giriş mesajı verilir
                MessageBox.Show("Hatalı Giriş. Lütfen Bilgilerinizi Kontrol Ediniz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Bağlantıyı kapatıyoruz (önceki bağlantı açıldığı için onu kapatmalıyız)
            bgl.baglanti().Close();
        }


    }
}
