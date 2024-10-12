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
    public partial class FrmDoktorBilgiDuzenle : Form
    {
        public FrmDoktorBilgiDuzenle()
        {
            InitializeComponent();
        }

        sqlBaglantisi bgl = new sqlBaglantisi();

        public string TCNO;
        private void FrmDoktorBilgiDuzenle_Load(object sender, EventArgs e)
        {
            maskedTextBoxTCNO.Text = TCNO;

            SqlCommand cmd = new SqlCommand("select * from Doktor where DoktorTC=@p1", bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1", maskedTextBoxTCNO.Text);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textBoxAd.Text = dr[2].ToString();
                textBoxSoyad.Text = dr[3].ToString();
                comboBoxBrans.Text = dr[4].ToString();
                textBoxSifre.Text = dr[5].ToString();

            }
            bgl.baglanti().Close();
        }

        private void buttonDuzenlemeKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komutGuncelle = new SqlCommand("update Doktor set DoktorAd=@d1,DoktorSoyad=@d2,DoktorBrans=@d3,doktorSifre=@d4 where DoktorTC=@d5", bgl.baglanti());
            komutGuncelle.Parameters.AddWithValue("@d1", textBoxAd.Text);
            komutGuncelle.Parameters.AddWithValue("@d2", textBoxSoyad.Text);
            komutGuncelle.Parameters.AddWithValue("@d3", comboBoxBrans.Text);
            komutGuncelle.Parameters.AddWithValue("@d4", textBoxSifre.Text);
            komutGuncelle.Parameters.AddWithValue("@d5", maskedTextBoxTCNO.Text);


            komutGuncelle.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Doktor Bilgisi Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
