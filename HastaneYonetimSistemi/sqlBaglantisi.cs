using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace HastaneYonetimSistemi
{
    class sqlBaglantisi
    {

        // Veritabanı bağlantısı açar ve geri döner
        public SqlConnection baglanti() 
        {

            SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-IMEIVGC\\SQLEXPRESS;Initial Catalog=HastaneYonetimSistemi;Integrated Security=True");

            baglan.Open();

            return baglan;

        }

        // Bağlantıyı kapatma fonksiyonu
        public void BaglantiKapat(SqlConnection baglan)
        {
            if (baglan.State == ConnectionState.Open)
            {
                baglan.Close();
            }
        }
    }
}
