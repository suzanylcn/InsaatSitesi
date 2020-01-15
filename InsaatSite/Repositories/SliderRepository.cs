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
    public class SliderRepository
    {
        public List<slider> Listele()
        {
            List<slider> sliderList = new List<slider>();
            SqlConnection baglan = new SqlConnection("Server=DESKTOP-6GBHM2T\\SQLEXPRESS;Database=Insaat;Integrated Security=true;");
            baglan.Open();
            SqlCommand komut = new SqlCommand("select*from slider", baglan);
            SqlDataReader sliderdangelen = komut.ExecuteReader();
            while (sliderdangelen.Read())
            {
                slider slidercik = new slider();
                slidercik.id = Convert.ToInt32(sliderdangelen["id"]);
                slidercik.baslik = sliderdangelen["baslik"].ToString();
                slidercik.aciklama = sliderdangelen["aciklama"].ToString();
                slidercik.resim = sliderdangelen["resim"].ToString();
                sliderList.Add(slidercik);
            }
            return sliderList;
        }

        public void SliderEkleDb(slider gelen, HttpPostedFileBase sliderResim, string yol)
        {
            string resimIsmi = "";
            if (sliderResim != null && sliderResim.ContentLength > 0)
            {
                resimIsmi = DateTime.Now.ToString("dd/MM/yyyy hh/mm/ss") + sliderResim.FileName;
                var path = Path.Combine(yol, resimIsmi);
                sliderResim.SaveAs(path);

                SqlConnection baglan = new SqlConnection("Server=DESKTOP-6GBHM2T\\SQLEXPRESS;Database=Insaat;Integrated Security=true;");
                baglan.Open();
                SqlCommand komut = new SqlCommand("insert into slider(baslik,aciklama,resim)values(@baslik,@aciklama,@resim)", baglan);
                komut.Parameters.Add("@baslik", SqlDbType.Text).Value = gelen.baslik;
                komut.Parameters.Add("@aciklama", SqlDbType.Text).Value = gelen.aciklama;
                komut.Parameters.Add("@resim", SqlDbType.Text).Value = resimIsmi;

                komut.ExecuteNonQuery();
            }
        }

        public void SliderSil(int id)
        {
            SqlConnection baglan = new SqlConnection("Server=DESKTOP-6GBHM2T\\SQLEXPRESS;Database=Insaat;Integrated Security=true;");
            baglan.Open();
            SqlCommand komut = new SqlCommand("Delete from slider where id="+id, baglan);
            komut.ExecuteNonQuery();
        }
        public slider idyegorecek(int id)
        {
            SqlConnection baglan = new SqlConnection("Server=DESKTOP-6GBHM2T\\SQLEXPRESS;Database=Insaat;Integrated Security=true;");
            baglan.Open();
            SqlCommand komut = new SqlCommand("select*from slider where id=" + id, baglan);
            SqlDataReader sliderdangelen = komut.ExecuteReader();
            slider slidercik = new slider();
            while (sliderdangelen.Read())
            {
                
                slidercik.id = Convert.ToInt32(sliderdangelen["id"]);
                slidercik.baslik = sliderdangelen["baslik"].ToString();
                slidercik.aciklama = sliderdangelen["aciklama"].ToString();
                slidercik.resim = sliderdangelen["resim"].ToString();
            }
            return slidercik;

        }

        public void SliderGuncelleDb(slider gelen,HttpPostedFileBase sliderResim,string yol)
        {
            string resimIsmi = "";
            if (sliderResim != null && sliderResim.ContentLength > 0)
            {
                resimIsmi = DateTime.Now.ToString("dd/MM/yyyy hh/mm/ss") + sliderResim.FileName;
                var path = Path.Combine(yol, resimIsmi);
                sliderResim.SaveAs(path);



                SqlConnection baglan = new SqlConnection("Server=DESKTOP-6GBHM2T\\SQLEXPRESS;Database=Insaat;Integrated Security=true;");
                baglan.Open();
                SqlCommand komut = new SqlCommand("update slider set baslik=@baslik,aciklama=@aciklama,resim=@resim where id=" + gelen.id, baglan);
                komut.Parameters.Add("@baslik", SqlDbType.Text).Value = gelen.baslik;
                komut.Parameters.Add("@aciklama", SqlDbType.Text).Value = gelen.aciklama;
                komut.Parameters.Add("@resim", SqlDbType.Text).Value = resimIsmi;
                komut.ExecuteNonQuery();
            }
            else
            {
                SqlConnection baglan = new SqlConnection("Server=DESKTOP-6GBHM2T\\SQLEXPRESS;Database=Insaat;Integrated Security=true;");
                baglan.Open();
                SqlCommand komut = new SqlCommand("update slider set baslik=@baslik,aciklama=@aciklama where id=" + gelen.id, baglan);
                komut.Parameters.Add("@baslik", SqlDbType.Text).Value = gelen.baslik;
                komut.Parameters.Add("@aciklama", SqlDbType.Text).Value = gelen.aciklama;
                komut.Parameters.Add("@resim", SqlDbType.Text).Value = resimIsmi;
                komut.ExecuteNonQuery();


            }


        }
        
    }
}