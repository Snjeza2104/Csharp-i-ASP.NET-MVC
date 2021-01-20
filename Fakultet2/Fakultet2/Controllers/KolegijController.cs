using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Fakultet2.Models;

namespace Fakultet2.Controllers
{
    [Authorize]
    public class KolegijController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //GET: Kolegiji
        public ActionResult Index()
        {
            return View(db.Kolegiji.ToList());
        }

        //GET: Kolegiji/Details/5
        public ActionResult Details (int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kolegij kolegij = db.Kolegiji.Find(id);
            if (kolegij == null)
            {
                return HttpNotFound();
            }
            return View(kolegij);
        }

        //GET: Kolegiji/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: Kolegiji/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include ="Id, Naziv, Opis, Ucionica, DatumPocetka")] Kolegij kolegij)
        {
            if (ModelState.IsValid)
            {
                db.Kolegiji.Add(kolegij);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kolegij);
        }

        //GET: Kolegiji/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kolegij kolegij = db.Kolegiji.Find(id);
            if (kolegij == null)
            {
                return HttpNotFound();
            }
            return View(kolegij);
        }

        //POST: Kolegiji/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include ="Id, Naziv, Opis, Ucionica, DatumPocetka")] Kolegij kolegij)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kolegij).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kolegij);
        }

        //GET: Kolegiji/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kolegij kolegij = db.Kolegiji.Find(id);
            if (kolegij == null)
            {
                return HttpNotFound();
            }
            return View(kolegij);
        }

        //POST: Kolegiji/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kolegij kolegij = db.Kolegiji.Find(id);
            db.Kolegiji.Remove(kolegij);
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