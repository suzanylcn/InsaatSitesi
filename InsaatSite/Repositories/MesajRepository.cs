using InsaatSite.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InsaatSite.Repositories
{
    public class MesajRepository
    {

        public List<mesaj> Listele()
        {
            List<mesaj> mesajList = new List<mesaj>();
            SqlConnection baglan = new SqlConnection("Server=DESKTOP-6GBHM2T\\SQLEXPRESS;Database=Insaat;Integrated Security=true;");
            baglan.Open();

            SqlCommand komut = new SqlCommand("Select*from mesaj", baglan);
            SqlDataReader mesajdangelen = komut.ExecuteReader();

            while (mesajdangelen.Read())
            {
                mesaj mesajcik = new mesaj();
                mesajcik.id = Convert.ToInt32(mesajdangelen["id"]);
                mesajcik.konu = mesajdangelen["konu"].ToString();
                mesajcik.message = mesajdangelen["mesaj"].ToString();
                mesajList.Add(mesajcik);
            }
            return mesajList;

        }

        public void mesajKaydet(mesaj gelen)
        {
            SqlConnection baglan = new SqlConnection("Server=DESKTOP-6GBHM2T\\SQLEXPRESS;Database=Insaat;Integrated Security=true;");
            baglan.Open();

            SqlCommand komut = new SqlCommand("insert into mesaj(konu,mesaj) values(@konu,@mesaj)", baglan);

            komut.Parameters.Add("@konu", SqlDbType.Text).Value = gelen.konu;

            komut.Parameters.Add("@mesaj", SqlDbType.Text).Value = gelen.message;

            komut.ExecuteNonQuery();
            

        }
    }
}