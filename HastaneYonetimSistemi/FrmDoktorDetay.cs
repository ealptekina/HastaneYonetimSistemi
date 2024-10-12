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
    public partial class FrmDoktorDetay : Form
    {
        public FrmDoktorDetay()
        {
            InitializeComponent();
        }

        sqlBaglantisi bgl = new sqlBaglantisi();
        public string TC;

        private void FrmDoktorDetay_Load_1(object sender, EventArgs e)
        {
            labelDoktorTC.Text = TC;

            //Doktor Ad Soyad

            SqlCommand cmd = new SqlCommand("select DoktorAd,DoktorSoyad from Doktor where DoktorTC=@p1",bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1", labelDoktorTC.Text); 
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                labelDoktorAdSoyad.Text = reader[0] + " " + reader[1];
            }

            bgl.baglanti().Close();

            //Randevular

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from randevu where RandevuDoktor='" + labelDoktorAdSoyad.Text + "'", bgl.baglanti());
            da.Fill(dt);
            dataGridViewRandevuList.DataSource = dt;
            
        }

        private void buttonBilgiDuzenle_Click(object sender, EventArgs e)
        {
            FrmDoktorBilgiDuzenle frmDoktorBilgiDuzenle = new FrmDoktorBilgiDuzenle();
            frmDoktorBilgiDuzenle.TCNO = labelDoktorTC.Text;
            frmDoktorBilgiDuzenle.Show();
        }

        private void buttonDuyurular_Click(object sender, EventArgs e)
        {
            FrmDuyurular frmDuyurular = new FrmDuyurular();
            frmDuyurular.Show();
        }

        // Çıkış Butonu
        private void buttonCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridViewRandevuList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridViewRandevuList.SelectedCells[0].RowIndex;
            richTextBoxSikayet.Text = dataGridViewRandevuList.Rows[secilen].Cells[7].Value.ToString();
        }
    }
}
