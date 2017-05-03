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
    public class ThursdayController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Thursday
        public ActionResult Index()
        {
            return View(db.ThursdayBars.ToList());
        }

        // GET: Thursday/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThursdayBars thursdayBars = db.ThursdayBars.Find(id);
            if (thursdayBars == null)
            {
                return HttpNotFound();
            }
            return View(thursdayBars);
        }

        // GET: Thursday/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Thursday/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BarsID,BarName,Specials,DaytimeBusyness,EveningBusyness,NightTimeBusyness,AdditionalFeatures")] ThursdayBars thursdayBars)
        {
            if (ModelState.IsValid)
            {
                db.ThursdayBars.Add(thursdayBars);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(thursdayBars);
        }

        // GET: Thursday/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThursdayBars thursdayBars = db.ThursdayBars.Find(id);
            if (thursdayBars == null)
            {
                return HttpNotFound();
            }
            return View(thursdayBars);
        }

        // POST: Thursday/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BarsID,BarName,Specials,DaytimeBusyness,EveningBusyness,NightTimeBusyness,AdditionalFeatures")] ThursdayBars thursdayBars)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thursdayBars).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(thursdayBars);
        }

        // GET: Thursday/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThursdayBars thursdayBars = db.ThursdayBars.Find(id);
            if (thursdayBars == null)
            {
                return HttpNotFound();
            }
            return View(thursdayBars);
        }

        // POST: Thursday/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ThursdayBars thursdayBars = db.ThursdayBars.Find(id);
            db.ThursdayBars.Remove(thursdayBars);
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
