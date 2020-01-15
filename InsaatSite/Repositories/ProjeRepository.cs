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
    public class ProjeRepository
    {
        public List<proje> Listele()
        {
            List<proje> projeList = new List<proje>();
            SqlConnection baglan = new SqlConnection("Server=DESKTOP-6GBHM2T\\SQLEXPRESS;Database=Insaat;Integrated Security=true;");
            baglan.Open();
           
            SqlCommand komut = new SqlCommand("select *from proje", baglan);
            SqlDataReader projedengelenveri = komut.ExecuteReader();
         
            while (projedengelenveri.Read())
            {
                proje projecik = new proje();
                projecik.id = Convert.ToInt32(projedengelenveri["id"]);
                projecik.ad = projedengelenveri["ad"].ToString();
                projecik.aciklama = projedengelenveri["aciklama"].ToString();
                projecik.resim = projedengelenveri["resim"].ToString();
                projecik.kategori = Convert.ToInt32(projedengelenveri["kategori"]);
                projeList.Add(projecik);
            }

            return projeList;
        }
        public void ProjeEkleDb(proje gelen,HttpPostedFileBase projeResim,string yol)
        {
            string resimIsmi = "";
            if (projeResim != null && projeResim.ContentLength > 0)
            {
                resimIsmi = DateTime.Now.ToString("dd/MM/yyyy hh/mm/ss") + projeResim.FileName;
                var path = Path.Combine(yol, resimIsmi);
                projeResim.SaveAs(path);
            }

            SqlConnection baglan = new SqlConnection("Server=DESKTOP-6GBHM2T\\SQLEXPRESS;Database=Insaat;Integrated Security=true;");
            baglan.Open();

            SqlCommand komut = new SqlCommand("insert into proje(ad,aciklama,resim,kategori)values(@ad,@acıklama,@resimi,@kategorisi)", baglan);
            komut.Parameters.Add("@ad", SqlDbType.Text).Value = gelen.ad;
            komut.Parameters.Add("@acıklama", SqlDbType.Text).Value = gelen.aciklama;
            komut.Parameters.Add("@resimi", SqlDbType.Text).Value = resimIsmi;
            komut.Parameters.Add("@kategorisi", SqlDbType.Int).Value = gelen.kategori;
            komut.ExecuteNonQuery();

        }
        public void ProjeSil(int silincekId)
        {
            SqlConnection baglan = new SqlConnection("Server=DESKTOP-6GBHM2T\\SQLEXPRESS;Database=Insaat;Integrated Security=true;");
            baglan.Open();
            SqlCommand komut1 = new SqlCommand("Delete from proje where id=" + silincekId, baglan);
            komut1.ExecuteNonQuery();

        }

        public proje idyegorecek(int duzenlencekId)
        {
            SqlConnection baglan = new SqlConnection("Server=DESKTOP-6GBHM2T\\SQLEXPRESS;Database=Insaat;Integrated Security=true;");
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select * From proje where id=" + duzenlencekId, baglan);
            SqlDataReader projedengelenveri = komut.ExecuteReader();
            proje projecik = new proje();
            while (projedengelenveri.Read())
            {
             
                projecik.id = Convert.ToInt32(projedengelenveri["id"]);
                projecik.ad = projedengelenveri["ad"].ToString();
                projecik.aciklama = projedengelenveri["aciklama"].ToString();
                projecik.resim = projedengelenveri["resim"].ToString();
                projecik.kategori = Convert.ToInt32(projedengelenveri["kategori"]);
            }
            return projecik;
        }
        public void ProjeGuncelleDb(proje gelen, HttpPostedFileBase projeResim, string yol)
        {
            string resimIsmi = "";
            if (projeResim != null && projeResim.ContentLength > 0)
            {
                resimIsmi = DateTime.Now.ToString("dd/MM/yyyy hh/mm/ss") + projeResim.FileName;
                var path = Path.Combine(yol, resimIsmi);
                projeResim.SaveAs(path);

                SqlConnection baglan = new SqlConnection("Server=DESKTOP-6GBHM2T\\SQLEXPRESS;Database=Insaat;Integrated Security=true;");
                baglan.Open();
                SqlCommand komut = new SqlCommand("update proje set ad=@ad,aciklama=@acıklama,resim=@resimi,kategori=@kategorisi where id=" + gelen.id, baglan);
                komut.Parameters.Add("@ad", SqlDbType.NVarChar, 50).Value = gelen.ad;
                komut.Parameters.Add("@acıklama", SqlDbType.Text).Value = gelen.aciklama;
                komut.Parameters.Add("@resimi", SqlDbType.Text).Value = resimIsmi;
                komut.Parameters.Add("@kategorisi", SqlDbType.Int).Value = gelen.kategori;
                komut.ExecuteNonQuery();

            }

            else  
            {
             SqlConnection baglan = new SqlConnection("Server=DESKTOP-6GBHM2T\\SQLEXPRESS;Database=Insaat;Integrated Security=true;");
             baglan.Open();
             SqlCommand komut = new SqlCommand("update proje set ad=@ad,aciklama=@acıklama,kategori=@kategorisi where id=" + gelen.id, baglan);
             komut.Parameters.Add("@ad", SqlDbType.NVarChar,50).Value = gelen.ad;
              komut.Parameters.Add("@acıklama", SqlDbType.Text).Value = gelen.aciklama;
             komut.Parameters.Add("@kategorisi", SqlDbType.Int).Value = gelen.kategori;
             komut.ExecuteNonQuery();
             }
        }

    }
}