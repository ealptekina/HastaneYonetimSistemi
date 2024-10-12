using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HastaneYonetimSistemi
{
    public partial class FrmSekreterDetay : Form
    {
        public FrmSekreterDetay()
        {
            InitializeComponent();
        }


        // Sekreterin TC kimlik numarası
        public string tc;

        // Veritabanı bağlantısı
        sqlBaglantisi bgl = new sqlBaglantisi();

        private void FrmSekreterDetay_Load(object sender, EventArgs e)
        {
            #region Kullanıcının TC kimlik numarasını ekranda gösteriyoruz

            labelSekreterTC.Text = tc;

            // Sekreter tablosundan SekreterAdSoyad bilgilerini çekmek için SQL komutu
            SqlCommand komut = new SqlCommand("select SekreterAdSoyad from Sekreter where SekreterTC=@h1", bgl.baglanti());
            komut.Parameters.AddWithValue("@h1", labelSekreterTC.Text);

            // Komutu çalıştırıp sonucu okuyacak bir SqlDataReader oluşturuyoruz
            SqlDataReader dr = komut.ExecuteReader();

            // Veritabanından gelen bilgileri okuyup etiketlere yazıyoruz
            while (dr.Read())
            {
                labelSekreterAdSoyad.Text = dr["SekreterAdSoyad"].ToString();
            }

            bgl.baglanti().Close();

            #endregion

            #region Branşlar

            // DataTable oluşturuluyor
            DataTable dt = new DataTable();

            // Veritabanı bağlantısı için SQL komutu parametre kullanılarak oluşturuluyor
            SqlDataAdapter da = new SqlDataAdapter("select BransID, BransAd from Brans", bgl.baglanti());

            // DataTable dolduruluyor
            da.Fill(dt);

            // DataGridView'e DataTable atanıyor
            dataGridViewBranslar.DataSource = dt;
            // Sütun genişlikleri hücre içeriklerine göre otomatik ayarlanır
            dataGridViewBranslar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;


            #endregion


            #region Doktorlar

            // DataTable oluşturuluyor
            DataTable dt2 = new DataTable();

            // Veritabanı bağlantısı için SQL komutu parametre kullanılarak oluşturuluyor
            SqlDataAdapter da2 = new SqlDataAdapter("select DoktorAd,DoktorSoyad,DoktorBrans from Doktor", bgl.baglanti());

            // DataTable dolduruluyor
            da2.Fill(dt2);

            // DataGridView'e DataTable atanıyor
            dataGridViewDoktorlar.DataSource = dt2;
            //// Sütun genişlikleri hücre içeriklerine göre otomatik ayarlanır
            //dataGridViewDoktorlar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;


            #endregion


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

        private void buttonRandevuKaydet_Click(object sender, EventArgs e)
        {

            SqlCommand komutRandevuKaydet = new SqlCommand("insert into Randevu (RandevuBrans,RandevuDoktor,RandevuTarih,RandevuSaat,Sikayet) values (@r1,@r2,@r3,@r4,@r5)", bgl.baglanti());

            komutRandevuKaydet.Parameters.AddWithValue("r1", comboBoxBrans.Text);
            komutRandevuKaydet.Parameters.AddWithValue("r2", comboBoxDoktor.Text);
            komutRandevuKaydet.Parameters.AddWithValue("r3", maskedTextBoxTarih.Text);
            komutRandevuKaydet.Parameters.AddWithValue("r4", maskedTextBoxSaat.Text);
            komutRandevuKaydet.Parameters.AddWithValue("r5", richTextBox1.Text);

            komutRandevuKaydet.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Randevu başarıyla kaydedildi.");
            ClearForm();
        }

        private void ClearForm()
        {
            maskedTextBoxHastaTC.Clear(); // Hasta TC'yi temizle
            comboBoxBrans.SelectedIndex = -1; // Branş seçimini sıfırla
            comboBoxDoktor.SelectedIndex = -1; // Doktor listesini temizle
            maskedTextBoxTarih.Clear(); // Tarih alanını temizle
            maskedTextBoxSaat.Clear(); // Saat alanını temizle
            checkBoxDurum.Checked = false; // Durum checkbox'ını sıfırla
            richTextBox1.Clear(); // Şikayet alanını temizle
        }


        // Duyuru oluşturma butonuna tıklandığında çalışan metod
        private void buttonDuyuruOlustur_Click(object sender, EventArgs e)
        {

            // SQL komutu oluşturuyoruz (Duyuru veritabanına ekleniyor)
            SqlCommand komut = new SqlCommand("insert into Duyuru (DuyuruAciklama) values (@p1)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", richTextBoxDuyuru.Text);

            // Komutu çalıştırıyoruz
            komut.ExecuteNonQuery();

            bgl.baglanti().Close();

            // İşlem başarılı olduğunda kullanıcıya bilgi ver
            MessageBox.Show("Duyuru başarıyla kaydedildi!");

            richTextBoxDuyuru.Clear();
        }

        private void comboBoxBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxDoktor.Items.Clear(); // Doktorları temizliyoruz

            // Seçilen branşa göre doktorları getiriyoruz
            SqlCommand komutDoktor = new SqlCommand("SELECT DoktorAd, DoktorSoyad FROM Doktor WHERE DoktorBrans=@p1", bgl.baglanti());
            komutDoktor.Parameters.AddWithValue("@p1", comboBoxBrans.Text);
            SqlDataReader drDoktor = komutDoktor.ExecuteReader();
            while (drDoktor.Read())
            {
                comboBoxDoktor.Items.Add(drDoktor[0] + " " + drDoktor[1]);
            }
            bgl.baglanti().Close();
        }

        private void buttonBransPaneli_Click(object sender, EventArgs e)
        {
            // Brans Kayıt Formunu Açar
            FrmBrans frmBrans = new FrmBrans();
            frmBrans.Show();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void buttonDoktorPaneli_Click(object sender, EventArgs e)
        {
            FrmDoktorPaneli drp = new FrmDoktorPaneli();
            drp.Show();
        }

        private void buttonRandevuListesi_Click(object sender, EventArgs e)
        {
            FrmRandevuListesi frmRandevuListesi = new FrmRandevuListesi();
            frmRandevuListesi.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmDuyurular frmDuyurular = new FrmDuyurular();
            frmDuyurular.Show();
        }
    }
}
