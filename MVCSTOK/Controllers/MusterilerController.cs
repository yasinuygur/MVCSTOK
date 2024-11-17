using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCSTOK.Models.Entity;

namespace MVCSTOK.Controllers
{
    public class MusterilerController : Controller
    {
        // GET: Musteriler
        DBMVCSTOKEntities1 db=new DBMVCSTOKEntities1();
        public ActionResult Index()
        {
            var degerler = db.TBLMUSTERILERs.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMusteri(TBLMUSTERILER p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            db.TBLMUSTERILERs.Add(p1);
            db.SaveChanges();
            return View();
        }

        public ActionResult SIL(int id)
        {
            var musteri = db.TBLMUSTERILERs.Find(id);
            db.TBLMUSTERILERs.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriGetir(int id)
        {
            var musteri = db.TBLMUSTERILERs.Find(id);
            return View("MusteriGetir",musteri);
        }
        public ActionResult Guncelle(TBLMUSTERILER p1)
        {
            var musteri = db.TBLMUSTERILERs.Find(p1.MUSTERIID);
            musteri.MUSTERIAD=p1.MUSTERIAD;
            musteri.MUSTERISOYAD=p1.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}