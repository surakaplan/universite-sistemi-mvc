using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mvcvize.Models;

namespace mvcvize.Controllers
{
    public class akademisyenlerController : Controller
    {
        private Database1Entities db = new Database1Entities();

        // GET: akademisyenler
        public ActionResult Index()
        {
            // Tüm akademisyen verilerini al
            var akademisyenler = db.akademisyenler.ToList();

            // Debug için bu satıra bir breakpoint ekleyin ve verilerin değerlerini kontrol edin

            // Bu verileri view'a aktar
            return View("Index", akademisyenler);
        }

        // GET: akademisyenler/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            akademisyenler akademisyenler = db.akademisyenler.Find(id);
            if (akademisyenler == null)
            {
                return HttpNotFound();
            }
            return View(akademisyenler);
        }

        // GET: akademisyenler/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: akademisyenler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,akademisyenad,akademisyensoyad,akademisyenbolum,akademisyenbaslangic")] akademisyenler akademisyenler)
        {
            if (ModelState.IsValid)
            {
                db.akademisyenler.Add(akademisyenler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(akademisyenler);
        }

        // GET: akademisyenler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            akademisyenler akademisyenler = db.akademisyenler.Find(id);
            if (akademisyenler == null)
            {
                return HttpNotFound();
            }
            return View(akademisyenler);
        }

        // POST: akademisyenler/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,akademisyenad,akademisyensoyad,akademisyenbolum,akademisyenbaslangic")] akademisyenler akademisyenler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(akademisyenler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(akademisyenler);
        }

        // GET: akademisyenler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            akademisyenler akademisyenler = db.akademisyenler.Find(id);
            if (akademisyenler == null)
            {
                return HttpNotFound();
            }
            return View(akademisyenler);
        }

        // POST: akademisyenler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            akademisyenler akademisyenler = db.akademisyenler.Find(id);
            db.akademisyenler.Remove(akademisyenler);
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
