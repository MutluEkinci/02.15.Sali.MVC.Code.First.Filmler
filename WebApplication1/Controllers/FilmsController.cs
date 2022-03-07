using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DAL;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class FilmsController : Controller
    {
        private FilmContext db = new FilmContext();

        // GET: Films
        public ActionResult Index()
        {
            var filmler = db.Filmler.Include(f => f.Tur).Include(f => f.Yapimci);
            return View(filmler.ToList());
        }

        // GET: Films/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Film film = db.Filmler.Find(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }

        // GET: Films/Create
        public ActionResult Create()
        {
            ViewBag.TurID = new SelectList(db.Turler, "TurID", "TurAdi");
            ViewBag.YapimciID = new SelectList(db.Yapimcilar, "YapimciID", "YapimciAdi");
            return View();
        }

        // POST: Films/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FilmID,FilmAdi,TurID,YapimciID,Süre")] Film film)
        {
            if (ModelState.IsValid)
            {
                db.Filmler.Add(film);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TurID = new SelectList(db.Turler, "TurID", "TurAdi", film.TurID);
            ViewBag.YapimciID = new SelectList(db.Yapimcilar, "YapimciID", "YapimciAdi", film.YapimciID);
            return View(film);
        }

        // GET: Films/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Film film = db.Filmler.Find(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            ViewBag.TurID = new SelectList(db.Turler, "TurID", "TurAdi", film.TurID);
            ViewBag.YapimciID = new SelectList(db.Yapimcilar, "YapimciID", "YapimciAdi", film.YapimciID);
            return View(film);
        }

        // POST: Films/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FilmID,FilmAdi,TurID,YapimciID,Süre")] Film film)
        {
            if (ModelState.IsValid)
            {
                db.Entry(film).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TurID = new SelectList(db.Turler, "TurID", "TurAdi", film.TurID);
            ViewBag.YapimciID = new SelectList(db.Yapimcilar, "YapimciID", "YapimciAdi", film.YapimciID);
            return View(film);
        }

        // GET: Films/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Film film = db.Filmler.Find(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }

        // POST: Films/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Film film = db.Filmler.Find(id);
            db.Filmler.Remove(film);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
