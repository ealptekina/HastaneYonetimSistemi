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

namespace HastaneYonetimSistemi
{
    public partial class FrmBilgiDuzenle : Form
    {
        public FrmBilgiDuzenle()
        {
            InitializeComponent();
        }

        public string TcNo;

        sqlBaglantisi bgl = new sqlBaglantisi();
        private void FrmBilgiDuzenle_Load(object sender, EventArgs e)
        {
            maskedTextBoxTcNo.Text = TcNo;

            SqlCommand cmd = new SqlCommand("select * from Hasta where HastaTC=@p1", bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1", maskedTextBoxTcNo.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textBoxAd.Text = dr["HastaAd"].ToString();
                textBoxSoyad.Text = dr["HastaSoyad"].ToString();
                comboBoxCinsiyet.Text = dr["HastaCinsiyet"].ToString();
                maskedTextBoxTelefon.Text = dr["HastaTelefon"].ToString();
                textBoxSifre.Text = dr["HastaSifre"].ToString();

            }
            bgl.baglanti().Close();
        }

        private void buttonDuzenlemeKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komutguncelle = new SqlCommand("update Hasta set HastaAd=@p1, HastaSoyad=@p2,HastaCinsiyet=@p3,HastaTelefon=@p4,HastaSifre=@p5 where HastaTC=@p6", bgl.baglanti());
            komutguncelle.Parameters.AddWithValue("@p1",textBoxAd.Text);
            komutguncelle.Parameters.AddWithValue("@p2", textBoxSoyad.Text);
            komutguncelle.Parameters.AddWithValue("@p3", comboBoxCinsiyet.Text);
            komutguncelle.Parameters.AddWithValue("@p4", maskedTextBoxTelefon.Text);
            komutguncelle.Parameters.AddWithValue("@p5", textBoxSifre.Text);
            komutguncelle.Parameters.AddWithValue("@p6", maskedTextBoxTcNo.Text);

            komutguncelle.ExecuteNonQuery();
            bgl.baglanti().Close();

            MessageBox.Show("Bilgileriniz Güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();

        }
    }
}
