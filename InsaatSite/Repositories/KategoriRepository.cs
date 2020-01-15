using InsaatSite.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InsaatSite.Repositories
{
    public class KategoriRepository
    {

        public List<kategori> Listele()
        {
            List<kategori> kategoriList = new List<kategori>();

            SqlConnection baglan = new SqlConnection("Server=DESKTOP-6GBHM2T\\SQLEXPRESS;Database=Insaat;Integrated Security=true;");
            baglan.Open();

            SqlCommand komut = new SqlCommand("Select*from kategoriler", baglan);
            SqlDataReader kategoridengelen = komut.ExecuteReader();

            while (kategoridengelen.Read())
            {
                kategori kategoricik = new kategori();
                kategoricik.id = Convert.ToInt32(kategoridengelen["id"]);
                kategoricik.Kategori = kategoridengelen["kategoriAdi"].ToString();
                kategoriList.Add(kategoricik);
            }
            return kategoriList;
        }

        public void Ekle(kategori gelenkategori)
        {
            SqlConnection baglan = new SqlConnection("Server=DESKTOP-6GBHM2T\\SQLEXPRESS;Database=Insaat;Integrated Security=true;");
            baglan.Open();

            SqlCommand komut = new SqlCommand("insert into kategoriler(kategoriAdi) values(@adi)", baglan);
            komut.Parameters.Add("@adi", SqlDbType.Text).Value = gelenkategori.Kategori;
            komut.ExecuteNonQuery();
        }


        public void Guncelle(kategori gelen)
        {
            SqlConnection baglan = new SqlConnection("Server=DESKTOP-6GBHM2T\\SQLEXPRESS;Database=Insaat;Integrated Security=true;");
            baglan.Open();
            SqlCommand komut = new SqlCommand("Update kategoriler set kategoriAdi=@adi where id=" + gelen.id, baglan);
            komut.Parameters.Add("@adi", SqlDbType.Text).Value = gelen.Kategori;
            komut.ExecuteNonQuery();
        }



        public kategori IdyeGoreCek(int id)
        {
            SqlConnection baglan = new SqlConnection("Server=DESKTOP-6GBHM2T\\SQLEXPRESS;Database=Insaat;Integrated Security=true;");
            baglan.Open();
            SqlCommand Komut = new SqlCommand("Select * From kategoriler where id=" +id, baglan);
            SqlDataReader kategoridengelenveri = Komut.ExecuteReader();

            kategori kategoricik = new kategori();
            while (kategoridengelenveri.Read())
            {
                kategoricik.id = Convert.ToInt32(kategoridengelenveri["id"]);
                kategoricik.Kategori = kategoridengelenveri["kategoriAdi"].ToString();
            }
            return kategoricik;

        }

        public void Sil(int silinecekId) 
        {
            SqlConnection baglan = new SqlConnection("Server=DESKTOP-6GBHM2T\\SQLEXPRESS;Database=Insaat;Integrated Security=true;");
            baglan.Open();
            SqlCommand komut1 = new SqlCommand("Delete from kategoriler where id=" + silinecekId, baglan);

            komut1.ExecuteNonQuery();
        }




    }
}