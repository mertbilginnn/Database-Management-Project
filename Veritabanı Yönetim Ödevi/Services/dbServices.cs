using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veritabanı_Yönetim_Ödevi.Services
{
    class dbServices
    {
        readonly string connString = "Data Source = DESKTOP-4PAEP6V;Initial Catalog = Mertemi;Integrated Security=true";


        //İcerisine girilen parameterele uyan kullanıcı adı ve parolayı veri tabanına sorgu atarak kontrol eder. Eğer dönen verinin 1 elemanı bile varsa o kullanıcı giriş yapabilir.
        public bool isUserExist(String kullaniciAdi,String parola)
        {
            SqlConnection conn = new SqlConnection(this.connString);
            conn.Open();
            string query = "Select* from Admin Where KullaniciAdi = '"+kullaniciAdi+"' AND Sifre = '"+parola+"';";
            SqlCommand cmd = new SqlCommand(query,conn);
            SqlDataReader reader = cmd.ExecuteReader();
            bool isUserExists = reader.HasRows;
            return isUserExists;
        }

        // İçerisine girilen stringi olduğu gibi sql'e query olarak iletir. Sonucundaki SqlReader objesini döndürür.

        public SqlDataReader customQuery(String _query)
        {
            try
            {
                SqlConnection conn = new SqlConnection(this.connString);
                conn.Open();
                string query = _query;
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                return reader;
            }
            catch (Exception)
            {
                return null;
            }
            
        }

        //Hazır sorgu fonksiyonudur. Matematik kursu alan öğrencilerin sorgusunu yapar.

        public SqlDataReader mathCourseBuyers()
        {
            try
            {
                SqlConnection conn = new SqlConnection(this.connString);
                conn.Open();
                string query = "Select Ogrenci.Isim,Ogrenci.Soyisim From Ogrenci,Envanter Where Envanter.KursId = 0 And Ogrenci.OgrenciId = Envanter.OgrenciId";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                return reader;
            }
            catch (Exception)
            {
                return null;
            }
        }
        //Hazır sorgu fonksiyonudur. ogrencilerin en cok aldıgı kursun sorgusunu yapar.
        public SqlDataReader favCourseInfo()
        {
            try
            {
                SqlConnection conn = new SqlConnection(this.connString);
                conn.Open();
                string query = "SELECT Top 1 K.KursId, K.KursIsmi,K.KursFiyat, COUNT(E.KursId) AS 'Satış Miktarı' FROM Kurs K LEFT JOIN Envanter E ON K.KursId = E.KursId GROUP BY K.KursId, K.KursIsmi,K.KursFiyat ORDER BY [Satış Miktarı] DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                return reader;
            }
            catch (Exception)
            {
                return null;
            }
        }
        //Hazır sorgu fonksiyonudur. En cok kursu olan ogrencinin sorgusunu yapar.
        public SqlDataReader richestCourserer()
        {
            try
            {
                SqlConnection conn = new SqlConnection(this.connString);
                conn.Open();
                string query = "SELECT TOP 1 O.Isim, COUNT(E.OgrenciId) AS KursSayisi FROM Envanter E INNER JOIN Ogrenci O ON E.OgrenciId = O.OgrenciId GROUP BY E.OgrenciId, O.Isim ORDER BY KursSayisi DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                return reader;
            }
            catch (Exception)
            {
                return null;
            }
        }

       
    }
}
