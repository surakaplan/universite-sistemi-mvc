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
    public class mezunlarController : Controller
    {
        private Database1Entities db = new Database1Entities();

        // GET: mezunlar
        public ActionResult Index()
        {
            return View(db.mezunlar.ToList());
        }

        // GET: mezunlar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mezunlar mezunlar = db.mezunlar.Find(id);
            if (mezunlar == null)
            {
                return HttpNotFound();
            }
            return View(mezunlar);
        }

        // GET: mezunlar/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: mezunlar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,mezunad,mezunbolum,mezunpuan")] mezunlar mezunlar)
        {
            if (ModelState.IsValid)
            {
                db.mezunlar.Add(mezunlar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mezunlar);
        }

        // GET: mezunlar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mezunlar mezunlar = db.mezunlar.Find(id);
            if (mezunlar == null)
            {
                return HttpNotFound();
            }
            return View(mezunlar);
        }

        // POST: mezunlar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,mezunad,mezunbolum,mezunpuan")] mezunlar mezunlar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mezunlar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mezunlar);
        }

        // GET: mezunlar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mezunlar mezunlar = db.mezunlar.Find(id);
            if (mezunlar == null)
            {
                return HttpNotFound();
            }
            return View(mezunlar);
        }

        // POST: mezunlar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            mezunlar mezunlar = db.mezunlar.Find(id);
            db.mezunlar.Remove(mezunlar);
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
