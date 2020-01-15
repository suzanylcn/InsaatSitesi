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
    public class HaberRepository
    {
        public List<haber> Listele()
        {
            List<haber> haberlist = new List<haber>();
            SqlConnection baglan = new SqlConnection("Server=DESKTOP-6GBHM2T\\SQLEXPRESS;Database=Insaat;Integrated Security=true;");
            baglan.Open();
            SqlCommand komut = new SqlCommand("select*from haber", baglan);
            SqlDataReader haberdenGelen = komut.ExecuteReader();
            while (haberdenGelen.Read())
            {
                haber habercik = new haber();
                habercik.id = Convert.ToInt32(haberdenGelen["id"]);
                habercik.baslik = haberdenGelen["baslik"].ToString();
                habercik.spot = haberdenGelen["spot"].ToString();
                habercik.detay = haberdenGelen["detay"].ToString();
                habercik.resim = haberdenGelen["resim"].ToString();
                haberlist.Add(habercik);
            }
            return haberlist;
        }
        public void HaberEkleDb(haber gelen, HttpPostedFileBase haberResim, string yol)
        {
            string resimIsmi = "";
            if (haberResim != null && haberResim.ContentLength > 0)
            {
                resimIsmi = DateTime.Now.ToString("dd/MM/yyyy hh/mm/ss") + haberResim.FileName;
                var path = Path.Combine(yol, resimIsmi);
                haberResim.SaveAs(path);
            }

            SqlConnection baglan = new SqlConnection("Server=DESKTOP-6GBHM2T\\SQLEXPRESS;Database=Insaat;Integrated Security=true;");
            baglan.Open();

            SqlCommand komut = new SqlCommand("insert into haber(baslik,spot,detay,resim)values(@baslık,@spot,@detay,@resim)", baglan);
            komut.Parameters.Add("@baslık", SqlDbType.Text).Value = gelen.baslik;
            komut.Parameters.Add("@spot", SqlDbType.Text).Value = gelen.spot;
            komut.Parameters.Add("@detay", SqlDbType.Text).Value = gelen.detay;
            komut.Parameters.Add("@resim", SqlDbType.Text).Value = resimIsmi;
            komut.ExecuteNonQuery();


        }
        public void HaberSil(int silinecekid)
        {
            SqlConnection baglan = new SqlConnection("Server=DESKTOP-6GBHM2T\\SQLEXPRESS;Database=Insaat;Integrated Security=true;");
            baglan.Open();

            SqlCommand komut1 = new SqlCommand("Delete from haber where id=" + silinecekid, baglan);
            komut1.ExecuteNonQuery();

        }
        public haber idyegorecek(int id)
        {
            SqlConnection baglan = new SqlConnection("Server=DESKTOP-6GBHM2T\\SQLEXPRESS;Database=Insaat;Integrated Security=true;");
            baglan.Open();
            SqlCommand komut = new SqlCommand("select*from haber where id="+id, baglan);

            SqlDataReader haberdenGelen = komut.ExecuteReader();
            haber habercik = new haber();

            while (haberdenGelen.Read())
            {
                habercik.id = Convert.ToInt32(haberdenGelen["id"]);
                habercik.baslik = haberdenGelen["baslik"].ToString();
                habercik.spot = haberdenGelen["spot"].ToString();
                habercik.detay = haberdenGelen["detay"].ToString();
                habercik.resim = haberdenGelen["resim"].ToString();
            }
            return habercik;
        }
        public void HaberGuncelleDb(haber gelen, HttpPostedFileBase haberResim, string yol)
        {
            string resimIsmi = "";
            if (haberResim != null && haberResim.ContentLength > 0)
            {
                resimIsmi = DateTime.Now.ToString("dd/MM/yyyy hh/mm/ss") + haberResim.FileName;
                var path = Path.Combine(yol, resimIsmi);
                haberResim.SaveAs(path);


                SqlConnection baglan = new SqlConnection("Server=DESKTOP-6GBHM2T\\SQLEXPRESS;Database=Insaat;Integrated Security=true;");
                baglan.Open();
                SqlCommand komut = new SqlCommand("Update haber set baslik=@baslık,spot=@spot,detay=@detay,resim=@resim where id=" + gelen.id, baglan);
                komut.Parameters.Add("@baslık", SqlDbType.Text).Value = gelen.baslik;
                komut.Parameters.Add("@spot", SqlDbType.Text).Value = gelen.spot;
                komut.Parameters.Add("@detay", SqlDbType.Text).Value = gelen.detay;
                komut.Parameters.Add("@resim", SqlDbType.Text).Value = resimIsmi;
                komut.ExecuteNonQuery();
            }
            else
            {
                SqlConnection baglan = new SqlConnection("Server=DESKTOP-6GBHM2T\\SQLEXPRESS;Database=Insaat;Integrated Security=true;");
                baglan.Open();
                SqlCommand komut = new SqlCommand("Update haber set baslik=@baslık,spot=@spot,detay=@detay where id=" + gelen.id, baglan);
                komut.Parameters.Add("@baslık", SqlDbType.Text).Value = gelen.baslik;
                komut.Parameters.Add("@spot", SqlDbType.Text).Value = gelen.spot;
                komut.Parameters.Add("@detay", SqlDbType.Text).Value = gelen.detay;
                komut.ExecuteNonQuery();
            }


        }
        

    }
}