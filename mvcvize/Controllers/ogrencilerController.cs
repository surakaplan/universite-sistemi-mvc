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
    public class ogrencilerController : Controller
    {
        private Database1Entities db = new Database1Entities();

        // GET: ogrenciler
        public ActionResult Index()
        {
            return View(db.ogrenciler.ToList());
        }

        // GET: ogrenciler/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ogrenciler ogrenciler = db.ogrenciler.Find(id);
            if (ogrenciler == null)
            {
                return HttpNotFound();
            }
            return View(ogrenciler);
        }

        // GET: ogrenciler/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ogrenciler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ogrenciad,ogrencino,ogrencibolum,ogrencipuan")] ogrenciler ogrenciler)
        {
            if (ModelState.IsValid)
            {
                db.ogrenciler.Add(ogrenciler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ogrenciler);
        }

        // GET: ogrenciler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ogrenciler ogrenciler = db.ogrenciler.Find(id);
            if (ogrenciler == null)
            {
                return HttpNotFound();
            }
            return View(ogrenciler);
        }

        // POST: ogrenciler/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ogrenciad,ogrencino,ogrencibolum,ogrencipuan")] ogrenciler ogrenciler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ogrenciler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ogrenciler);
        }

        // GET: ogrenciler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ogrenciler ogrenciler = db.ogrenciler.Find(id);
            if (ogrenciler == null)
            {
                return HttpNotFound();
            }
            return View(ogrenciler);
        }

        // POST: ogrenciler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ogrenciler ogrenciler = db.ogrenciler.Find(id);
            db.ogrenciler.Remove(ogrenciler);
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
        [HttpPost]
        public ActionResult MezunEt(int id)
        {
            // Öğrenciyi veritabanından bul
            var ogrenci = db.ogrenciler.FirstOrDefault(o => o.Id == id);

            // Öğrenci bulunamadıysa veya zaten mezun edilmişse
            if (ogrenci == null || ogrenci.MezunMu == true)
            {
                return HttpNotFound(); // veya uygun bir hata sayfasına yönlendirme yapılabilir
            }

            // Öğrenciyi mezun et ve değişiklikleri kaydet
            ogrenci.MezunMu = true; // Mezun olma durumunu true yapabilirsiniz

            // Mezunlar tablosuna ekleme
            var mezun = new mezunlar
            {
                mezunad = ogrenci.ogrenciad,
                mezunno = ogrenci.ogrencino,
                mezunbolum = ogrenci.ogrencibolum,
                mezunpuan = ogrenci.ogrencipuan
            };
            db.mezunlar.Add(mezun);

            // Öğrenciyi öğrenciler tablosundan sil
            db.ogrenciler.Remove(ogrenci);

            // Değişiklikleri kaydet
            db.SaveChanges();

            return RedirectToAction("Index"); // Öğrenci listesi sayfasına yönlendir
        }

    }

}
