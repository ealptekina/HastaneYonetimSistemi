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
using System.Data.SqlClient;

namespace HastaneYonetimSistemi
{
    public partial class FrmSekreterGiris : Form
    {
        public FrmSekreterGiris()
        {
            InitializeComponent();
        }

        sqlBaglantisi bgl = new sqlBaglantisi();
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from Sekreter where SekreterTC=@h1 and SekreterSifre=@h2", bgl.baglanti());

            // Kullanıcının girdiği verileri parametre olarak ekliyoruz
            komut.Parameters.AddWithValue("@h1", maskedTextBoxTCno.Text);
            komut.Parameters.AddWithValue("@h2", textBoxSifre.Text);

            // Komutu çalıştırıp sonucu okuyacak bir SqlDataReader oluşturuyoruz
            SqlDataReader dr = komut.ExecuteReader();

            // Eğer eşleşen kayıt bulunursa giriş başarılı
            if (dr.Read())
            {
                FrmSekreterDetay frmSekreterDetay = new FrmSekreterDetay();
                frmSekreterDetay.tc = maskedTextBoxTCno.Text;
                frmSekreterDetay.Show();
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
