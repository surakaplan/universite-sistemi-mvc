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
    public class raporlarController : Controller
    {
        private Database1Entities db = new Database1Entities();

        // GET: raporlar
        public ActionResult Index()
        {
            return View(db.raporlar.ToList());
        }

        // GET: raporlar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            raporlar raporlar = db.raporlar.Find(id);
            if (raporlar == null)
            {
                return HttpNotFound();
            }
            return View(raporlar);
        }

        // GET: raporlar/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: raporlar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,raporkonu,raporicerik")] raporlar raporlar)
        {
            if (ModelState.IsValid)
            {
                db.raporlar.Add(raporlar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(raporlar);
        }

        // GET: raporlar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            raporlar raporlar = db.raporlar.Find(id);
            if (raporlar == null)
            {
                return HttpNotFound();
            }
            return View(raporlar);
        }

        // POST: raporlar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,raporkonu,raporicerik")] raporlar raporlar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(raporlar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(raporlar);
        }

        // GET: raporlar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            raporlar raporlar = db.raporlar.Find(id);
            if (raporlar == null)
            {
                return HttpNotFound();
            }
            return View(raporlar);
        }

        // POST: raporlar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            raporlar raporlar = db.raporlar.Find(id);
            db.raporlar.Remove(raporlar);
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
