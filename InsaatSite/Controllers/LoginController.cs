using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InsaatSite.Models;

namespace InsaatSite.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Giris()
        {
            return View();
        }
        public ActionResult Verify(giris gelen)
        {
            SqlConnection baglan = new SqlConnection("Server=DESKTOP-6GBHM2T\\SQLEXPRESS;Database=Insaat;Integrated Security=true;");
            baglan.Open();
            SqlCommand komut = new SqlCommand("select*from giris where kullaniciAdi='" + gelen.kullaniciAdi + "' and sifre= '" + gelen.sifre + "'", baglan);
            SqlDataReader giristengelen = komut.ExecuteReader();
            if (giristengelen.Read())
            {
                Session["kullaniciAdi"] = giristengelen["kullaniciAdi"];
                return RedirectToAction("Index","Panel");
            }
            else
            {
                return RedirectToAction("Giris");
            }



        }

    }






}
