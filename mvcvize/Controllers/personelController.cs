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
    public class personelController : Controller
    {
        private Database1Entities db = new Database1Entities();

        // GET: personel
       
        public ActionResult Index()
        {
            return View(db.personel.ToList());
        }

        // GET: personel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            personel personel = db.personel.Find(id);
            if (personel == null)
            {
                return HttpNotFound();
            }
            return View(personel);
        }

        // GET: personel/Create
        public ActionResult Create()
        {
            ViewBag.Birimler = new SelectList(GetBirimler(), "BirimID", "BirimAd");
            return View();
        }

        // POST: personel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "personelad,personelsoyad,birimid")] personel personel)
        {
            if (ModelState.IsValid)
            {
                
                personel.birim = Convert.ToString(Request.Form["birimid"]);

                db.personel.Add(personel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            //tekrar Create sayfasını göster
            ViewBag.Birimler = new SelectList(GetBirimler(), "BirimID", "BirimAd");
            return View(personel);
        }



        // GET: personel/Edit/5
        public ActionResult Edit(int? id)
        {
            var personel = db.personel.Find(id);
            if (personel == null)
            {
                return HttpNotFound();
            }
            ViewBag.birimler = new SelectList(db.birimler, "BirimID", "BirimAd", personel.birim);
            return View(personel);
        }

        // POST: personel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "personelad,personelsoyad,personelid")] personel personel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personel);
        }

        // GET: personel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            personel personel = db.personel.Find(id);
            if (personel == null)
            {
                return HttpNotFound();
            }
            return View(personel);
        }

        // POST: personel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            personel personel = db.personel.Find(id);
            db.personel.Remove(personel);
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
        private List<birimler> GetBirimler()
        {
            return db.birimler.ToList();
        }



    }
}
