using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProject.Models.Siniflar;

namespace TravelTripProject.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Blogs.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniBlog()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniBlog(Blog p)
        {
            c.Blogs.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BlogSil(int id)
        {
            var b = c.Blogs.Find(id);
            c.Blogs.Remove(b);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BlogGetir(int id)
        {
            var b1 = c.Blogs.Find(id);
            return View("BlogGetir", b1);
        }
        public ActionResult BlogGuncelle(Blog b)
        {
            var blg = c.Blogs.Find(b.ID);
            blg.Aciklama = b.Aciklama;
            blg.Baslik = b.Baslik;
            blg.BlogImage = b.BlogImage;
            blg.Tarih = b.Tarih;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YorumListesi()
        {
            var yorumlar = c.Yorumlars.ToList();
            return View(yorumlar);
        }
        public ActionResult YorumSil(int id)
        {
            var b = c.Yorumlars.Find(id);
            c.Yorumlars.Remove(b);
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
        public ActionResult YorumGetir(int id)
        {
            var b1 = c.Yorumlars.Find(id);
            return View("YorumGetir", b1);
        }
        public ActionResult YorumGuncelle(Yorumlar b)
        {
            var yorum = c.Yorumlars.Find(b.ID);
            yorum.KullaniciAdi = b.KullaniciAdi;
            yorum.Mail = b.Mail;
            yorum.Yorum = b.Yorum;
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
        public ActionResult Hakkimizda()
        {
            var hakkimizda = c.Hakkimizdas.ToList();
            return View(hakkimizda);
        }
        public ActionResult HakkimizdaGetir(int id)
        {
            var b1 = c.Hakkimizdas.Find(id);
            return View("HakkimizdaGetir", b1);
        }
        public ActionResult HakkimizdaGuncelle(Hakkimizda b)
        {
            var hakk = c.Hakkimizdas.Find(b.ID);
            hakk.Aciklama = b.Aciklama;
            hakk.FotoUrl = b.FotoUrl;
            c.SaveChanges();
            return RedirectToAction("Hakkimizda");
        }
    }
}