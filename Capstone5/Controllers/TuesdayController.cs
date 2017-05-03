using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Capstone5.Models;

namespace Capstone5.Controllers
{
    public class TuesdayController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tuesday
        public ActionResult Index()
        {
            return View(db.TuesdayBars.ToList());
        }

        // GET: Tuesday/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TuesdayBars tuesdayBars = db.TuesdayBars.Find(id);
            if (tuesdayBars == null)
            {
                return HttpNotFound();
            }
            return View(tuesdayBars);
        }

        // GET: Tuesday/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tuesday/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BarsID,BarName,Specials,DaytimeBusyness,EveningBusyness,NightTimeBusyness,AdditionalFeatures")] TuesdayBars tuesdayBars)
        {
            if (ModelState.IsValid)
            {
                db.TuesdayBars.Add(tuesdayBars);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tuesdayBars);
        }

        // GET: Tuesday/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TuesdayBars tuesdayBars = db.TuesdayBars.Find(id);
            if (tuesdayBars == null)
            {
                return HttpNotFound();
            }
            return View(tuesdayBars);
        }

        // POST: Tuesday/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BarsID,BarName,Specials,DaytimeBusyness,EveningBusyness,NightTimeBusyness,AdditionalFeatures")] TuesdayBars tuesdayBars)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tuesdayBars).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tuesdayBars);
        }

        // GET: Tuesday/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TuesdayBars tuesdayBars = db.TuesdayBars.Find(id);
            if (tuesdayBars == null)
            {
                return HttpNotFound();
            }
            return View(tuesdayBars);
        }

        // POST: Tuesday/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TuesdayBars tuesdayBars = db.TuesdayBars.Find(id);
            db.TuesdayBars.Remove(tuesdayBars);
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
