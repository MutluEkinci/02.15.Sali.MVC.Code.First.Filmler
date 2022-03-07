using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DAL;
using WebApplication1.Models;
using WebApplication1.Models.ViewModel;

namespace WebApplication1.Controllers
{
    public class FilmController : Controller
    {
        FilmContext db = new FilmContext();
        // GET: Film
        public ActionResult Index(string ara)
        {
            if (ara == null)
            {
                return View(db.Filmler.Include("Yapimci").Include("Tur").ToList());
            }
            else
            {
                return View(db.Filmler.Where(x => x.FilmAdi.Contains(ara)).ToList());
            }
            
            //2. yöntem, Include ekleyince lazy loading problemini çözüyoruz, yoksa tur deki tur idlere karşılık gelen isimleri göremicez
            //virtual ve iclude ile bunu çözüyoruz

            //virtualda her yerde lazy loading olarak çalışıcak ram i şişirir,
            //include da ihtiyacımız olunca çağırırız.
        }

        public ActionResult Ekle()
        {
            //ViewBag Kullanımı:
            ViewBag.Turler = new SelectList(db.Turler.ToList(), "TurID", "TurAdi");
            ViewBag.Yapimcilar = new SelectList(db.Yapimcilar.ToList(), "YapimciID", "YapimciAdi");

            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Film film)
        {
            db.Filmler.Add(film);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult EkleVM()
        {
            Film_VM filmVM = new Film_VM();
            filmVM.Turler = new SelectList(db.Turler.ToList(), "TurID", "TurAdi");
            filmVM.Yapimcilar = new SelectList(db.Yapimcilar.ToList(), "YapimciID", "YapimciAdi");

            filmVM.Oyuncular = new SelectList(db.Oyuncular.ToList(), "OyuncuID", "OyuncuAdi");

            return View(filmVM);
        }

        [HttpPost]
        public ActionResult EkleVM(Film_VM filmVM)
        {
            var Film = db.Filmler.Find(filmVM.Film.FilmID);
            if (Film == null)
            {
                Film flm = db.Filmler.Add(filmVM.Film);
                db.SaveChanges();

                db.FilmOyuncu.Add(new FilmOyuncu { FilmID = flm.FilmID, OyuncuID = filmVM.OyuncuID });
                db.SaveChanges();
            }
            else
            {
                // db.FilmOyuncu.Add(new FilmOyuncu { FilmID = filmVM.Film.FilmID, OyuncuID = filmVM.OyuncuID });
            }

            return RedirectToAction("Index");
        }

        public ActionResult OyuncuEkle(int id)
        {
            Film film = db.Filmler.Find(id);
            FilmOyuncuVM filmOyunculari = new FilmOyuncuVM();
            filmOyunculari.Oyuncular = new SelectList(db.Oyuncular.ToList(), "OyuncuID", "OyuncuADi");
            filmOyunculari.FilmOyuncuları = db.FilmOyuncu.Where(o => o.FilmID == id).ToList();
            filmOyunculari.FilmID = id;
            return View(filmOyunculari);
        }

        [HttpPost]
        public ActionResult OyuncuEkle(FilmOyuncuVM flmOyn)
        {
            db.FilmOyuncu.Add(new FilmOyuncu { FilmID = flmOyn.FilmID, OyuncuID = flmOyn.OyuncuId });
            db.SaveChanges();
            return RedirectToAction("OyuncuEkle", flmOyn.FilmID);
        }
        public ActionResult Guncelle(int id)
        {
            var film = db.Filmler.Where(f => f.FilmID == id).FirstOrDefault();
            ViewBag.Turler = new SelectList(db.Turler.ToList(), "TurID", "TurAdi");
            ViewBag.Yapimcilar = new SelectList(db.Yapimcilar.ToList(), "YapimciID", "YapimciAdi");
            return View(film);
        }

        [HttpPost]
        public ActionResult Guncelle(Film film)
        {
            var id = db.Filmler.Find(film.FilmID);
            id.FilmAdi = film.FilmAdi;
            id.TurID = film.TurID;
            id.YapimciID = film.YapimciID;
            id.Süre = film.Süre;

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FilmOyuncuGuncelle(int OyuncuID,int FID,int EOID)
        {
            var obj = db.FilmOyuncu.Where(f => f.FilmID == FID && f.OyuncuID == EOID).FirstOrDefault();

            obj.OyuncuID = OyuncuID;

            db.Entry<FilmOyuncu>(obj).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}