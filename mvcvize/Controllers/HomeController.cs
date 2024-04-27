using mvcvize.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace mvcvize.Controllers
{
    public class HomeController : Controller
    {
        private Database1Entities db = new Database1Entities();
        // GET: Home
        public ActionResult Index() 
        {
            return View(); 
        }
        public ActionResult Akademisyenler()
        {
            return View("~/Views/akademisyenler/Index.cshtml", db.akademisyenler.ToList());
        }

        public ActionResult Personeller()
        {
            return View("~/Views/personel/Index.cshtml", db.personel.ToList());
        }

        public ActionResult Ogrenciler()
        {
            return View("~/Views/ogrenciler/Index.cshtml", db.ogrenciler.ToList());
        }

        public ActionResult Raporlar()
        {
            return View("~/Views/raporlar/Index.cshtml", db.raporlar.ToList());
        }

        public ActionResult Mezunlar()
        {
            return View("~/Views/mezunlar/Index.cshtml", db.mezunlar.ToList());
        }

    }
}