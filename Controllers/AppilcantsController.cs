using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Indian_Visa_System;

namespace Indian_Visa_System.Controllers
{
    public class AppilcantsController : Controller
    {
        private Indian_Visa_SystemEntities db = new Indian_Visa_SystemEntities();

        // GET: Appilcants
        public ActionResult Index()
        {
            var appilcants = db.Appilcants.Include(a => a.City).Include(a => a.Country).Include(a => a.VisaStatu).Include(a => a.VisaType);
            return View(appilcants.ToList());
        }

        // GET: Appilcants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appilcant appilcant = db.Appilcants.Find(id);
            if (appilcant == null)
            {
                return HttpNotFound();
            }
            return View(appilcant);
        }

        // GET: Appilcants/Create
        public ActionResult Create()
        {
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "Cities");
            ViewBag.CountryID = new SelectList(db.Countries, "CountryID", "Countires");
            ViewBag.StatusID = new SelectList(db.VisaStatus, "StatusID", "Status");
            ViewBag.VisaID = new SelectList(db.VisaTypes, "VisaID", "VisaTypes");
            return View();
        }

        // POST: Appilcants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AppID,Firstname,Surname,DateOfbirth,CityID,CountryID,VisaID,StatusID")] Appilcant appilcant)
        {
            if (ModelState.IsValid)
            {
                db.Appilcants.Add(appilcant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityID = new SelectList(db.Cities, "CityID", "Cities", appilcant.CityID);
            ViewBag.CountryID = new SelectList(db.Countries, "CountryID", "Countires", appilcant.CountryID);
            ViewBag.StatusID = new SelectList(db.VisaStatus, "StatusID", "Status", appilcant.StatusID);
            ViewBag.VisaID = new SelectList(db.VisaTypes, "VisaID", "VisaTypes", appilcant.VisaID);
            return View(appilcant);
        }

        // GET: Appilcants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appilcant appilcant = db.Appilcants.Find(id);
            if (appilcant == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "Cities", appilcant.CityID);
            ViewBag.CountryID = new SelectList(db.Countries, "CountryID", "Countires", appilcant.CountryID);
            ViewBag.StatusID = new SelectList(db.VisaStatus, "StatusID", "Status", appilcant.StatusID);
            ViewBag.VisaID = new SelectList(db.VisaTypes, "VisaID", "VisaTypes", appilcant.VisaID);
            return View(appilcant);
        }

        // POST: Appilcants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AppID,Firstname,Surname,DateOfbirth,CityID,CountryID,VisaID,StatusID")] Appilcant appilcant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appilcant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "Cities", appilcant.CityID);
            ViewBag.CountryID = new SelectList(db.Countries, "CountryID", "Countires", appilcant.CountryID);
            ViewBag.StatusID = new SelectList(db.VisaStatus, "StatusID", "Status", appilcant.StatusID);
            ViewBag.VisaID = new SelectList(db.VisaTypes, "VisaID", "VisaTypes", appilcant.VisaID);
            return View(appilcant);
        }

        // GET: Appilcants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appilcant appilcant = db.Appilcants.Find(id);
            if (appilcant == null)
            {
                return HttpNotFound();
            }
            return View(appilcant);
        }

        // POST: Appilcants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Appilcant appilcant = db.Appilcants.Find(id);
            db.Appilcants.Remove(appilcant);
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
