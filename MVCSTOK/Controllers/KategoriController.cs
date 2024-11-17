using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCSTOK.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MVCSTOK.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        DBMVCSTOKEntities1 db= new DBMVCSTOKEntities1();
        public ActionResult Index(int sayfa=1)
        {

            //var degerler = db.TBLKATEGORIs.ToList();
            var degerler = db.TBLKATEGORIs.ToList().ToPagedList(sayfa,4);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKategori(TBLKATEGORI p1) 
        {
            if (!ModelState.IsValid)
            {
                return View("YeniKategori");
            }
            db.TBLKATEGORIs.Add(p1);
            db.SaveChanges();
            return View();
        }

        public ActionResult SIL(int id)
        {
            var kategori = db.TBLKATEGORIs.Find(id);
            db.TBLKATEGORIs.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var kategori = db.TBLKATEGORIs.Find(id);
            return View("KategoriGetir",kategori);

        }

        public ActionResult Guncelle(TBLKATEGORI p1)
        {
            var kategori = db.TBLKATEGORIs.Find(p1.KATEGORIID);
            kategori.KATEGORIAD = p1.KATEGORIAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}