using InsaatSite.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace InsaatSite.Repositories
{
    public class CalısanRepository
    {
        public List<calısan> Listele()
        { 
            List<calısan> calisanlist = new List<calısan>();
            SqlConnection baglan = new SqlConnection("Server=DESKTOP-6GBHM2T\\SQLEXPRESS;Database=Insaat;Integrated Security=true;");
            baglan.Open();


            SqlCommand komut = new SqlCommand("select*from calısanlar", baglan);

            SqlDataReader calisanlardangelenveri = komut.ExecuteReader();

            while (calisanlardangelenveri.Read())
            {
                calısan calis = new calısan();
                calis.id = Convert.ToInt32(calisanlardangelenveri["id"]);
                calis.ad = calisanlardangelenveri["ad"].ToString();
                calis.soyad = calisanlardangelenveri["soyad"].ToString();
                calis.unvan = calisanlardangelenveri["unvan"].ToString();
                calis.resim = calisanlardangelenveri["resim"].ToString();
                calis.facebookLink = calisanlardangelenveri["facebook"].ToString();
                calis.twitterLink = calisanlardangelenveri["twitter"].ToString();
                calis.instagramLink = calisanlardangelenveri["instagram"].ToString();
                calisanlist.Add(calis);
            }
            return calisanlist;
        }


        public void CalısanEkle(calısan gelen, HttpPostedFileBase calısanResim, string yol)
        {
            string resimIsmi = "";
            if (calısanResim != null && calısanResim.ContentLength > 0)
            {
                resimIsmi = DateTime.Now.ToString("dd/MM/yyyy hh/mm/ss") + calısanResim.FileName;
                var path = Path.Combine(yol, resimIsmi);
                calısanResim.SaveAs(path);
            }

            SqlConnection baglan = new SqlConnection("Server=DESKTOP-6GBHM2T\\SQLEXPRESS;Database=Insaat;Integrated Security=true;");
            baglan.Open();

            SqlCommand komut = new SqlCommand("insert into calısanlar(ad,soyad,unvan,resim,facebook,twitter,instagram)values(@adi,@soyadi,@unvani,@resimi,@facebookLinki,@twitterLinki,@instagramLinki)", baglan);
            komut.Parameters.Add("@adi", SqlDbType.Text).Value = gelen.ad;
            komut.Parameters.Add("@soyadi", SqlDbType.Text).Value = gelen.soyad;
            komut.Parameters.Add("@unvani", SqlDbType.Text).Value = gelen.unvan;
            komut.Parameters.Add("@resimi", SqlDbType.Text).Value = resimIsmi;
            komut.Parameters.Add("@facebookLinki", SqlDbType.Text).Value = gelen.facebookLink;
            komut.Parameters.Add("@twitterLinki", SqlDbType.Text).Value = gelen.twitterLink;
            komut.Parameters.Add("@instagramLinki", SqlDbType.Text).Value = gelen.instagramLink;
            komut.ExecuteNonQuery();



        }
        public void CalısanSil(int id)
        {
            SqlConnection baglan = new SqlConnection("Server=DESKTOP-6GBHM2T\\SQLEXPRESS;Database=Insaat;Integrated Security=true;");
            baglan.Open();
            SqlCommand komut1 = new SqlCommand("Delete from calısanlar where id=" + id, baglan);
            komut1.ExecuteNonQuery();
        }

        public calısan idyegorecek(int id)
        {
            SqlConnection baglan = new SqlConnection("Server=DESKTOP-6GBHM2T\\SQLEXPRESS;Database=Insaat;Integrated Security=true;");
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select*from calısanlar where id =" + id, baglan);
            SqlDataReader calisanlardangelenveri = komut.ExecuteReader();

            calısan calis = new calısan();
            while (calisanlardangelenveri.Read())
            {

                calis.id = Convert.ToInt32(calisanlardangelenveri["id"]);
                calis.ad = calisanlardangelenveri["ad"].ToString();
                calis.soyad = calisanlardangelenveri["soyad"].ToString();
                calis.unvan = calisanlardangelenveri["unvan"].ToString();
                calis.resim = calisanlardangelenveri["resim"].ToString();
                calis.facebookLink = calisanlardangelenveri["facebook"].ToString();
                calis.twitterLink = calisanlardangelenveri["twitter"].ToString();
                calis.instagramLink = calisanlardangelenveri["instagram"].ToString();

            }
            return calis;
        }
        public void CalısanGuncelleDb(calısan gelen, HttpPostedFileBase calısanResim, string yol)
        {
            string resimIsmi = "";
            if (calısanResim != null && calısanResim.ContentLength > 0)
            {
                resimIsmi = DateTime.Now.ToString("dd/MM/yyyy hh/mm/ss") + calısanResim.FileName;
                var path = Path.Combine(yol, resimIsmi);
                calısanResim.SaveAs(path);
            
             SqlConnection baglan = new SqlConnection("Server=DESKTOP-6GBHM2T\\SQLEXPRESS;Database=Insaat;Integrated Security=true;");
             baglan.Open();
             SqlCommand komut = new SqlCommand("update calısanlar Set ad=@adi,soyad=@soyadi,unvan=@unvani,resim=@resimi,instagram=@instagramLinki,facebook=@facebookLinki,twitter=@twitterLinki where id=" + gelen.id, baglan);
             komut.Parameters.Add("@adi", SqlDbType.Text).Value = gelen.ad;
             komut.Parameters.Add("@soyadi", SqlDbType.Text).Value = gelen.soyad;
             komut.Parameters.Add("@unvani", SqlDbType.Text).Value = gelen.unvan;
                komut.Parameters.Add("@resimi", SqlDbType.Text).Value = resimIsmi;
             komut.Parameters.Add("@facebookLinki", SqlDbType.Text).Value = gelen.facebookLink;
             komut.Parameters.Add("@twitterLinki", SqlDbType.Text).Value = gelen.twitterLink;
             komut.Parameters.Add("@instagramLinki", SqlDbType.Text).Value = gelen.instagramLink;
             komut.ExecuteNonQuery();
            }
            else
            {

                SqlConnection baglan = new SqlConnection("Server=DESKTOP-6GBHM2T\\SQLEXPRESS;Database=Insaat;Integrated Security=true;");
                baglan.Open();
                SqlCommand komut = new SqlCommand("update calısanlar Set ad=@adi,soyad=@soyadi,unvan=@unvani,instagram=@instagramLinki,facebook=@facebookLinki,twitter=@twitterLinki where id=" + gelen.id, baglan);
                komut.Parameters.Add("@adi", SqlDbType.Text).Value = gelen.ad;
                komut.Parameters.Add("@soyadi", SqlDbType.Text).Value = gelen.soyad;
                komut.Parameters.Add("@unvani", SqlDbType.Text).Value = gelen.unvan;
                komut.Parameters.Add("@facebookLinki", SqlDbType.Text).Value = gelen.facebookLink;
                komut.Parameters.Add("@twitterLinki", SqlDbType.Text).Value = gelen.twitterLink;
                komut.Parameters.Add("@instagramLinki", SqlDbType.Text).Value = gelen.instagramLink;
                komut.ExecuteNonQuery();



            }


        }
    }
}