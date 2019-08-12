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
    public class VisaStatusController : Controller
    {
        private Indian_Visa_SystemEntities db = new Indian_Visa_SystemEntities();

        // GET: VisaStatus
        public ActionResult Index()
        {
            return View(db.VisaStatus.ToList());
        }

        // GET: VisaStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VisaStatu visaStatu = db.VisaStatus.Find(id);
            if (visaStatu == null)
            {
                return HttpNotFound();
            }
            return View(visaStatu);
        }

        // GET: VisaStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VisaStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StatusID,Status")] VisaStatu visaStatu)
        {
            if (ModelState.IsValid)
            {
                db.VisaStatus.Add(visaStatu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(visaStatu);
        }

        // GET: VisaStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VisaStatu visaStatu = db.VisaStatus.Find(id);
            if (visaStatu == null)
            {
                return HttpNotFound();
            }
            return View(visaStatu);
        }

        // POST: VisaStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StatusID,Status")] VisaStatu visaStatu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(visaStatu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(visaStatu);
        }

        // GET: VisaStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VisaStatu visaStatu = db.VisaStatus.Find(id);
            if (visaStatu == null)
            {
                return HttpNotFound();
            }
            return View(visaStatu);
        }

        // POST: VisaStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VisaStatu visaStatu = db.VisaStatus.Find(id);
            db.VisaStatus.Remove(visaStatu);
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
