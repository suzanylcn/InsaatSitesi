using InsaatSite.Models;
using InsaatSite.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsaatSite.Controllers
{
  
    public class PanelController : Controller
    {
        CalısanRepository calısanRepository = new CalısanRepository();
        HizmetRepository hizmetRepository = new HizmetRepository();
        ProjeRepository projeRepository = new ProjeRepository();
        KategoriRepository kategoriRepository = new KategoriRepository();
        HaberRepository haberRepository = new HaberRepository();
        SiteRepository siteRepository = new SiteRepository();
        SliderRepository sliderRepository = new SliderRepository();
        MesajRepository mesajRepository = new MesajRepository();


       
        public ActionResult Index()
        {
            return View();
        }

       
        public PartialViewResult CalisanListelePartial()
        {
            List<calısan> calisanList = calısanRepository.Listele();

            return PartialView(calisanList);
        }
        public ActionResult CalisanListele()
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Giris","Login");
            }
            return View();
        }
        public ActionResult CalısanEkle()
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Giris", "Login");
            }
            return View();
        }

        public ActionResult CalısanEkleDb(calısan gelen, HttpPostedFileBase calısanResim)
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Giris", "Login");
            }
            string yol = Server.MapPath("~/resimler/calisan/");

            calısanRepository.CalısanEkle(gelen, calısanResim, yol);

            return RedirectToAction("CalisanListele");

        }

        public ActionResult CalısanSil(int id)
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Giris", "Login");
            }

            calısanRepository.CalısanSil(id);
            return RedirectToAction("CalisanListele");
        }
        public ActionResult CalısanGuncelle(int id)
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Giris", "Login");
            }
            calısan calis = calısanRepository.idyegorecek(id);
            return View(calis);
        }
        public ActionResult CalısanGuncelleDb(calısan gelen, HttpPostedFileBase calısanResim)
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Giris", "Login");
            }
            string yol = Server.MapPath("~/resimler/calisan/");
            calısanRepository.CalısanGuncelleDb(gelen, calısanResim, yol);
            return RedirectToAction("CalisanListele");
        }

        public ActionResult HizmetListele()
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Giris", "Login");
            }
            List<hizmet> hizmetlist = hizmetRepository.Listele();
            return View(hizmetlist);
        }

        public ActionResult HizmetEkle()
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Giris", "Login");
            }
            return View();
        }
        public ActionResult HizmetEkleDb(hizmet gelen, HttpPostedFileBase hizmetResim)
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Giris", "Login");
            }
            string yol = Server.MapPath("~/resimler/hizmet/");
            hizmetRepository.HizmetEkleDb(gelen, hizmetResim, yol);

            return RedirectToAction("HizmetListele");
        }

        public ActionResult HizmetSil(int id)
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Giris", "Login");
            }
            hizmetRepository.HizmetSil(id);
            return RedirectToAction("HizmetListele");
        }


        public ActionResult HizmetGuncelle(int id)
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Giris", "Login");
            }
            hizmet hzmt = hizmetRepository.idyegorecek(id);
            return View(hzmt);
        }

        public ActionResult HizmetGuncelleDb(hizmet gelen, HttpPostedFileBase hizmetResim)
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Giris", "Login");
            }
            string yol = Server.MapPath("~/resimler/hizmet/");
            hizmetRepository.HizmetGuncelleDb(gelen, hizmetResim, yol);
            return RedirectToAction("HizmetListele");
        }
        public ActionResult ProjeListele()
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Giris", "Login");
            }
            List<proje> projelist = projeRepository.Listele();
            return View(projelist);
        }
        public PartialViewResult KategoriDropdown()
        {
            
            List<kategori> kategoriList = kategoriRepository.Listele();

            ViewBag.KategoriListem = kategoriList;
            return PartialView();
        }
        public ActionResult ProjeEkle()
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Giris", "Login");
            }
            return View();
        }
        public ActionResult ProjeEkleDb(proje gelen, HttpPostedFileBase projeResim)
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Giris", "Login");
            }
            string yol = Server.MapPath("~/resimler/proje/");
            projeRepository.ProjeEkleDb(gelen, projeResim, yol);
            return RedirectToAction("ProjeListele");
        }
        public ActionResult ProjeSil(int id)
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Giris", "Login");
            }
            projeRepository.ProjeSil(id);

            return RedirectToAction("ProjeListele");
        }

        public ActionResult ProjeGuncelle(int? id)
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Giris", "Login");
            }
            proje projecik = new proje();
            if (id.HasValue)
            {
                projecik = projeRepository.idyegorecek(id.Value);
            }
            return View(projecik);
        }
        public ActionResult ProjeGuncelleDb(proje gelen, HttpPostedFileBase projeResim)
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Giris", "Login");
            }
            string yol = Server.MapPath("~/resimler/proje/");
            projeRepository.ProjeGuncelleDb(gelen, projeResim, yol);
            return RedirectToAction("ProjeListele");
        }

        public ActionResult KategoriListele()
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Giris", "Login");
            }
            List<kategori> kategoriList = kategoriRepository.Listele();
            return View(kategoriList);
        }

        public ActionResult KategoriEkle()
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Giris", "Login");
            }
            return View();
        }

        public ActionResult KategoriEkleDb(kategori gelenkategori)
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Giris", "Login");
            }
            kategoriRepository.Ekle(gelenkategori);
            return RedirectToAction("KategoriListele");
        }

        public ActionResult KategoriSil(int id)
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Giris", "Login");
            }
            kategoriRepository.Sil(id);
            return RedirectToAction("KategoriListele");
        }


        public ActionResult KategoriGuncelle(int id)
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Giris", "Login");
            }
            kategori kategoricik = kategoriRepository.IdyeGoreCek(id);

            return View(kategoricik);
        }
        public ActionResult KategoriGuncelleDb(kategori kategoricik)
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Giris", "Login");
            }
            kategoriRepository.Guncelle(kategoricik);

            return RedirectToAction("KategoriListele");
        }

        public ActionResult HaberListele()
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Giris", "Login");
            }
            List<haber> haberList = haberRepository.Listele();


            return View(haberList);
        }

        public ActionResult HaberEkle()
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Giris", "Login");
            }
            return View();
        }


        public ActionResult HaberEkleDb(haber gelen, HttpPostedFileBase haberResim)
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Giris", "Login");
            }
            string yol = Server.MapPath("~/resimler/haber/");
            haberRepository.HaberEkleDb(gelen, haberResim, yol);

            return RedirectToAction("HaberListele");
        }


        public ActionResult HaberSil(int id)
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Giris", "Login");
            }
            haberRepository.HaberSil(id);

            return RedirectToAction("HaberListele");
        }

        public ActionResult HaberGuncelle(int id)
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Giris", "Login");
            }
            haber habercik = haberRepository.idyegorecek(id);
            return View( habercik);
        }
          
        public ActionResult HaberGuncelleDb(haber gelen, HttpPostedFileBase haberResim)
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Giris", "Login");
            }
            string yol = Server.MapPath("~/resimler/haber/");
            haberRepository.HaberGuncelleDb(gelen, haberResim, yol);

            return RedirectToAction("HaberListele");


        }

        public ActionResult SiteListele()
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Giris", "Login");
            }
            List<ayar> ayarlist = siteRepository.Listele();
            return View(ayarlist);
        }

        public ActionResult SiteGuncelle(int id)
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Giris", "Login");
            }
            ayar ayarcık = siteRepository.idyegorecek(id);
            return View(ayarcık);
        }


        public ActionResult SiteGuncelleDb(ayar gelen)
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Giris", "Login");
            }
            siteRepository.SiteGuncelleDb(gelen);
            return RedirectToAction("SiteListele");

        }

        public ActionResult SliderListele()
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Giris", "Login");
            }
            List<slider>sliderList=  sliderRepository.Listele();
            return View(sliderList);

        }

        public ActionResult SliderEkle()
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Giris", "Login");
            }
            return View();
        }

        public ActionResult SliderEkleDb(slider gelen, HttpPostedFileBase sliderResim)
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Giris", "Login");
            }
            string yol = Server.MapPath("~/resimler/slider/");
            sliderRepository.SliderEkleDb(gelen,sliderResim,yol);
            return RedirectToAction("SliderListele");
        }


        public ActionResult SliderSil(int id)
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Giris", "Login");
            }
            sliderRepository.SliderSil(id);
            return RedirectToAction("SliderListele");
        }

        public ActionResult SliderGuncelle(int id)
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Giris", "Login");
            }
            slider slidercik = sliderRepository.idyegorecek(id);
            return View(slidercik);

        }


        public ActionResult SliderGuncelleDb(slider gelen,HttpPostedFileBase sliderResim)
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Giris", "Login");
            }
            string yol = Server.MapPath("~/resimler/slider/");
            sliderRepository.SliderGuncelleDb(gelen,sliderResim,yol);

            return RedirectToAction("SliderListele");

        }
        public ActionResult mesaj()
        {
            if (Session["kullaniciAdi"] == null)
            {
                return RedirectToAction("Giris", "Login");
            }
            List<mesaj> mesajlist = mesajRepository.Listele();
            return View(mesajlist);
        }
    }
}