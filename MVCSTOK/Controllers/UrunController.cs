using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCSTOK.Models.Entity;

namespace MVCSTOK.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        DBMVCSTOKEntities1 db = new DBMVCSTOKEntities1();
        public ActionResult Index()
        {
            var degerler = db.TBLURUNLERs.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult UrunEkle() 
        {
            List<SelectListItem> degerler = (from i in db.TBLKATEGORIs.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult UrunEkle(TBLURUNLER p1)
        {
            var ktg=db.TBLKATEGORIs.Where(m=>m.KATEGORIID==p1.TBLKATEGORI.KATEGORIID).FirstOrDefault();
            p1.TBLKATEGORI = ktg;
            db.TBLURUNLERs.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SIL(int id)
        {
            var urun = db.TBLURUNLERs.Find(id);
            db.TBLURUNLERs.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> degerler = (from i in db.TBLKATEGORIs.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            var urun = db.TBLURUNLERs.Find(id);
            return View("UrunGetir",urun);
        }
        public ActionResult Guncelle(TBLURUNLER p)
        {
            var urun = db.TBLURUNLERs.Find(p.URUNID);
            urun.URUNAD = p.URUNAD;
            //urun.URUNKATEGORI = p.URUNKATEGORI;
            var ktg = db.TBLKATEGORIs.Where(m => m.KATEGORIID == p.TBLKATEGORI.KATEGORIID).FirstOrDefault();
            urun.URUNKATEGORI = ktg.KATEGORIID;
            urun.FIYAT=p.FIYAT;
            urun.STOK=p.STOK;
            urun.MARKA=p.MARKA;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}