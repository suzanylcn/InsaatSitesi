using InsaatSite.Models;
using InsaatSite.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsaatSite.Controllers
{
    public class HomeController : Controller
    {

        CalısanRepository calısanRepository = new CalısanRepository();
        HizmetRepository hizmetRepository = new HizmetRepository();
        ProjeRepository projeRepository = new ProjeRepository();
        HaberRepository haberRepository = new HaberRepository();
        SiteRepository siteRepository = new SiteRepository();
        SliderRepository sliderRepository = new SliderRepository();
        MesajRepository mesajRepository = new MesajRepository();
      
        
        public HomeController()
        {

            List<ayar> ayarList = new List<ayar>();
            ayarList = siteRepository.Listele();
            ViewBag.siteListem = ayarList.FirstOrDefault();


            List<hizmet> hizmetList = new List<hizmet>();
            hizmetList = hizmetRepository.Listele();
            ViewBag.hizmetListem = hizmetList;
        }


        public ActionResult Index()
        {
            List<calısan> calisanList = new List<calısan>();
            List<proje> projeList = new List<proje>();
            List<haber> haberList = new List<haber>();
            List<slider> sliderList = new List<slider>();
            List<mesaj> mesajList = new List<mesaj>();


            calisanList = calısanRepository.Listele();
            ViewBag.calisanListem = calisanList;

            projeList = projeRepository.Listele();
            ViewBag.projeListem = projeList;

            haberList = haberRepository.Listele();
            ViewBag.haberListem = haberList;

            sliderList = sliderRepository.Listele();
            ViewBag.sliderListem = sliderList;
            
            return View();
        }
        public ActionResult Haberdetay(int id)
        {

            haber habercik = haberRepository.idyegorecek(id);
            return View(habercik);
        }
       public ActionResult ProjeDetay(int id)
        {

            proje projecik = projeRepository.idyegorecek(id);


            return View(projecik);
        }
      
        public ActionResult iletisim()
        {
            return View();
        }
        public ActionResult mesajkaydet(mesaj gelenmesaj)
        {
            mesajRepository.mesajKaydet(gelenmesaj);

            return RedirectToAction("iletisim");
        }

    }
}