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
    public class HizmetRepository
    {
        public List<hizmet> Listele()
        {
            List<hizmet> hizmetlist = new List<hizmet>();
            SqlConnection baglan = new SqlConnection("Server=DESKTOP-6GBHM2T\\SQLEXPRESS;Database=Insaat;Integrated Security=true;");
            baglan.Open();
            SqlCommand komut = new SqlCommand("select*from hizmet", baglan);
            SqlDataReader hizmetlerdengelenveri = komut.ExecuteReader();



            while (hizmetlerdengelenveri.Read())
            {
                hizmet hzmt = new hizmet();
                hzmt.id = Convert.ToInt32(hizmetlerdengelenveri["id"]);
                hzmt.baslik = hizmetlerdengelenveri["baslik"].ToString();
                hzmt.acıklama = hizmetlerdengelenveri["aciklama"].ToString();
                hzmt.resim = hizmetlerdengelenveri["resim"].ToString();

                hizmetlist.Add(hzmt);


            }
            return hizmetlist;

        }
        public void HizmetEkleDb(hizmet gelen, HttpPostedFileBase hizmetResim, string yol)
        {
            string resimIsmi = "";
            if (hizmetResim != null && hizmetResim.ContentLength > 0)
            {
                resimIsmi = DateTime.Now.ToString("dd/MM/yyyy hh/mm/ss") + hizmetResim.FileName;
                var path = Path.Combine(yol, resimIsmi);
                hizmetResim.SaveAs(path);
            }

            SqlConnection baglan = new SqlConnection("Server=DESKTOP-6GBHM2T\\SQLEXPRESS;Database=Insaat;Integrated Security=true;");
            baglan.Open();
            SqlCommand komut = new SqlCommand("insert into hizmet(baslik,aciklama,resim)values(@baslık,@acıklama,@resimi)", baglan);
            komut.Parameters.Add("@baslık", SqlDbType.Text).Value = gelen.baslik;
            komut.Parameters.Add("@acıklama", SqlDbType.Text).Value = gelen.acıklama;
            komut.Parameters.Add("@resimi", SqlDbType.Text).Value = resimIsmi;
            komut.ExecuteNonQuery();


        }


        public void HizmetSil(int silincekId)
        {
            SqlConnection baglan = new SqlConnection("Server=DESKTOP-6GBHM2T\\SQLEXPRESS;Database=Insaat;Integrated Security=true;");
            baglan.Open();

            SqlCommand komut1 = new SqlCommand("Delete from hizmet where id=" + silincekId, baglan);
            komut1.ExecuteNonQuery();

        }

        public hizmet idyegorecek(int id)
        {
            SqlConnection baglan = new SqlConnection("Server=DESKTOP-6GBHM2T\\SQLEXPRESS;Database=Insaat;Integrated Security=true;");
            baglan.Open();

            SqlCommand Komut = new SqlCommand("Select * From hizmet where id=" + id, baglan);
            SqlDataReader hizmetlerdengelenveri = Komut.ExecuteReader();
            hizmet hzmt = new hizmet();
            while (hizmetlerdengelenveri.Read())
            {
                hzmt.id = Convert.ToInt32(hizmetlerdengelenveri["id"]);
                hzmt.baslik = hizmetlerdengelenveri["baslik"].ToString();
                hzmt.acıklama = hizmetlerdengelenveri["aciklama"].ToString();
                hzmt.resim = hizmetlerdengelenveri["resim"].ToString();

            }
            return hzmt;

        }
        public void HizmetGuncelleDb(hizmet gelen, HttpPostedFileBase hizmetResim, string yol)
        {
            string resimIsmi = "";
            if (hizmetResim != null && hizmetResim.ContentLength > 0)
            {
                resimIsmi = DateTime.Now.ToString("dd/MM/yyyy hh/mm/ss") + hizmetResim.FileName;
                var path = Path.Combine(yol, resimIsmi);
                hizmetResim.SaveAs(path);

                SqlConnection baglan = new SqlConnection("Server=DESKTOP-6GBHM2T\\SQLEXPRESS;Database=Insaat;Integrated Security=true;");
                baglan.Open();
                SqlCommand komut = new SqlCommand("Update hizmet set baslik=@baslık,aciklama=@acıklama,resim=@resimi where id=" + gelen.id, baglan);
                komut.Parameters.Add("@baslık", SqlDbType.Text).Value = gelen.baslik;
                komut.Parameters.Add("@acıklama", SqlDbType.Text).Value = gelen.acıklama;
                komut.Parameters.Add("@resimi", SqlDbType.Text).Value = resimIsmi;
                komut.ExecuteNonQuery();
            }
            else
            {
                SqlConnection baglan = new SqlConnection("Server=DESKTOP-6GBHM2T\\SQLEXPRESS;Database=Insaat;Integrated Security=true;");
                baglan.Open();
                SqlCommand komut = new SqlCommand("Update hizmet set baslik=@baslık,aciklama=@acıklama where id=" + gelen.id, baglan);
                komut.Parameters.Add("@baslık", SqlDbType.Text).Value = gelen.baslik;
                komut.Parameters.Add("@acıklama", SqlDbType.Text).Value = gelen.acıklama;
                komut.ExecuteNonQuery();
            }



        }

    }
}