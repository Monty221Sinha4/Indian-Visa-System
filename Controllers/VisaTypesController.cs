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
    public class VisaTypesController : Controller
    {
        private Indian_Visa_SystemEntities db = new Indian_Visa_SystemEntities();

        // GET: VisaTypes
        public ActionResult Index()
        {
            return View(db.VisaTypes.ToList());
        }

        // GET: VisaTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VisaType visaType = db.VisaTypes.Find(id);
            if (visaType == null)
            {
                return HttpNotFound();
            }
            return View(visaType);
        }

        // GET: VisaTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VisaTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VisaID,VisaTypes")] VisaType visaType)
        {
            if (ModelState.IsValid)
            {
                db.VisaTypes.Add(visaType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(visaType);
        }

        // GET: VisaTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VisaType visaType = db.VisaTypes.Find(id);
            if (visaType == null)
            {
                return HttpNotFound();
            }
            return View(visaType);
        }

        // POST: VisaTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VisaID,VisaTypes")] VisaType visaType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(visaType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(visaType);
        }

        // GET: VisaTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VisaType visaType = db.VisaTypes.Find(id);
            if (visaType == null)
            {
                return HttpNotFound();
            }
            return View(visaType);
        }

        // POST: VisaTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VisaType visaType = db.VisaTypes.Find(id);
            db.VisaTypes.Remove(visaType);
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
