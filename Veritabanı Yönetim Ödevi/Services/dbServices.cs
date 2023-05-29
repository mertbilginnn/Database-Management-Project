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
        string connString = "Data Source = DESKTOP-4PAEP6V;Initial Catalog = Mertemi;Integrated Security=true";
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
       
    }
}
