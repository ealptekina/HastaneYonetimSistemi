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
    public partial class FrmDoktorGiris : Form
    {
        public FrmDoktorGiris()
        {
            InitializeComponent();
        }

        sqlBaglantisi bgl = new sqlBaglantisi();

        // Doktor Login işlemi
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from Doktor where DoktorTC=@h1 and DoktorSifre=@h2", bgl.baglanti());

            // Kullanıcının girdiği verileri parametre olarak ekliyoruz
            komut.Parameters.AddWithValue("@h1", maskedTextBoxTC.Text);
            komut.Parameters.AddWithValue("@h2", textBoxSifre.Text);

            // Komutu çalıştırıp sonucu okuyacak bir SqlDataReader oluşturuyoruz
            SqlDataReader dr = komut.ExecuteReader();

            // Eğer eşleşen kayıt bulunursa giriş başarılı
            if (dr.Read())
            {
                FrmDoktorDetay frmDoktorDetay = new FrmDoktorDetay();
                frmDoktorDetay.TC = maskedTextBoxTC.Text;
                frmDoktorDetay.Show();
                this.Hide(); // Şu anki formu gizle
            }
            else
            {
                //Hatalı giriş mesajı verilir
                MessageBox.Show("Hatalı Giriş. Lütfen Bilgilerinizi Kontrol Ediniz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Bağlantıyı kapatıyoruz (önceki bağlantı açıldığı için onu kapatmalıyız)
            bgl.baglanti().Close();
        }

        private void FrmDoktorGiris_Load(object sender, EventArgs e)
        {

        }
    }
}
