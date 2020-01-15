using InsaatSite.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InsaatSite.Repositories
{
    public class SiteRepository
    {

        public List<ayar> Listele()
        {
            List<ayar> ayarList = new List<ayar>();
            SqlConnection baglan = new SqlConnection("Server=DESKTOP-6GBHM2T\\SQLEXPRESS;Database=Insaat;Integrated Security=true;");
            baglan.Open();
            SqlCommand komut = new SqlCommand("select*from ayarlar", baglan);
            SqlDataReader ayardangelen = komut.ExecuteReader();
            while (ayardangelen.Read())
            {
                ayar ayarcık = new ayar();
                ayarcık.id = Convert.ToInt32(ayardangelen["id"]);
                ayarcık.firmaAdi = ayardangelen["firmaAdi"].ToString();
                ayarcık.logo = ayardangelen["logo"].ToString();
                ayarcık.mail = ayardangelen["mail"].ToString();
                ayarcık.tel = Convert.ToInt32(ayardangelen["tel"]);
                ayarcık.facebook = ayardangelen["facebook"].ToString();
                ayarcık.twitter = ayardangelen["twitter"].ToString();
                ayarcık.instagram = ayardangelen["instagram"].ToString();
                ayarcık.adres = ayardangelen["adres"].ToString();
                ayarcık.harita = ayardangelen["harita"].ToString();
                ayarList.Add(ayarcık);
            }
            return ayarList;

        }
        public ayar idyegorecek(int id)
        {
            SqlConnection baglan = new SqlConnection("Server=DESKTOP-6GBHM2T\\SQLEXPRESS;Database=Insaat;Integrated Security=true;");
            baglan.Open();

            SqlCommand Komut = new SqlCommand("Select * From ayarlar where id=" + id, baglan);
            SqlDataReader ayardangelen = Komut.ExecuteReader();
            ayar ayarcık = new ayar();
            while (ayardangelen.Read())
            {
                ayarcık.id = Convert.ToInt32(ayardangelen["id"]);
                ayarcık.firmaAdi = ayardangelen["firmaAdi"].ToString();
                ayarcık.logo = ayardangelen["logo"].ToString();
                ayarcık.mail = ayardangelen["mail"].ToString();
                ayarcık.tel = Convert.ToInt32(ayardangelen["tel"]);
                ayarcık.facebook = ayardangelen["facebook"].ToString();
                ayarcık.twitter = ayardangelen["twitter"].ToString();
                ayarcık.instagram = ayardangelen["instagram"].ToString();
                ayarcık.adres = ayardangelen["adres"].ToString();
                ayarcık.harita = ayardangelen["harita"].ToString();
            }
            return ayarcık;

        }
        public void SiteGuncelleDb(ayar gelen)
        {
            SqlConnection baglan = new SqlConnection("Server=DESKTOP-6GBHM2T\\SQLEXPRESS;Database=Insaat;Integrated Security=true;");
            baglan.Open();

            SqlCommand Komut = new SqlCommand("update ayarlar set logo=@logo,firmaAdi=@firmaAdi,mail=@mail,tel=@tel,facebook=@facebook,instagram=instagram,twitter=@twitter, adres=@adres, harita=@harita where id="+gelen.id, baglan);
            Komut.Parameters.Add("@logo", SqlDbType.NVarChar,50).Value = gelen.logo;
            Komut.Parameters.Add("@firmaAdi", SqlDbType.NVarChar,255).Value = gelen.firmaAdi;
            Komut.Parameters.Add("@mail", SqlDbType.NVarChar,50).Value = gelen.mail;
            Komut.Parameters.Add("@tel", SqlDbType.Int).Value = gelen.tel;
            Komut.Parameters.Add("@facebook", SqlDbType.NVarChar,50).Value = gelen.facebook;
            Komut.Parameters.Add("@instagram", SqlDbType.NVarChar,50).Value = gelen.instagram;
            Komut.Parameters.Add("@twitter", SqlDbType.NVarChar,50).Value = gelen.twitter;
            Komut.Parameters.Add("@adres", SqlDbType.NVarChar,50).Value = gelen.adres;
            Komut.Parameters.Add("@harita", SqlDbType.Text).Value = gelen.harita;

            Komut.ExecuteNonQuery();

        }


    }
}