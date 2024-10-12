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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HastaneYonetimSistemi
{
    public partial class FrmBrans : Form
    {
        public FrmBrans()
        {
            InitializeComponent();
        }

        sqlBaglantisi bgl = new sqlBaglantisi();

        private void buttonEkle_Click(object sender, EventArgs e)
        {
            SqlCommand komutEkle = new SqlCommand("INSERT INTO Brans (BransAd) VALUES (@p1)", bgl.baglanti());
            komutEkle.Parameters.AddWithValue("@p1", textBoxAd.Text);

            komutEkle.ExecuteNonQuery();

            bgl.baglanti().Close();
            MessageBox.Show("Branş Eklendi");

        }

        private void buttonDuzenlemeKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komutGuncelle = new SqlCommand("UPDATE Brans SET BransAd = @p1 WHERE BransID = @p2", bgl.baglanti());

            // TextBox'lara girilen bilgileri parametre olarak ekliyoruz
            komutGuncelle.Parameters.AddWithValue("@p1", textBoxAd.Text);
            komutGuncelle.Parameters.AddWithValue("@p2", textBoxBransID.Text);  // BransID'yi güncellenmeyecek şekilde buradan alıyoruz

            komutGuncelle.ExecuteNonQuery();
            bgl.baglanti().Close();

            MessageBox.Show("Branş Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Güncellemeden sonra grid'i tekrar güncelliyoruz
            BransListele();

        }

        private void BransListele()
        {
            SqlCommand komut = new SqlCommand("SELECT BransID, BransAd FROM Brans", bgl.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            bgl.baglanti().Close();
        }

        private void FrmBrans_Load(object sender, EventArgs e)
        {
            // DataTable oluşturuluyor
            DataTable dt = new DataTable();

            // Veritabanı bağlantısı için SQL komutu parametre kullanılarak oluşturuluyor
            SqlDataAdapter da = new SqlDataAdapter("select BransID, BransAd from Brans", bgl.baglanti());

            // DataTable dolduruluyor
            da.Fill(dt);

            // DataGridView'e DataTable atanıyor
            dataGridView1.DataSource = dt;
            // Sütun genişlikleri hücre içeriklerine göre otomatik ayarlanır
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        //private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    // Seçili satırdaki BransID ve BransAd'ı textBox'lara atıyoruz
        //    if (e.RowIndex >= 0) // Geçerli bir satır seçilmişse
        //    {
        //        DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
        //        textBoxBransID.Text = row.Cells["BransID"].Value.ToString();
        //        textBoxAd.Text = row.Cells["BransAd"].Value.ToString();
        //    }
        //}

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBoxBransID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            textBoxAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
        }

        private void buttonSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutSil = new SqlCommand("delete from Brans where BransID=@p1", bgl.baglanti());
            komutSil.Parameters.AddWithValue("@p1", textBoxBransID.Text);
            komutSil.ExecuteNonQuery();

            bgl.baglanti().Close();
            MessageBox.Show("Branş Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
