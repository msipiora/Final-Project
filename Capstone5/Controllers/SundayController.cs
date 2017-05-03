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
    public class SundayController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Sunday
        public ActionResult Index()
        {
            return View(db.SundayBars.ToList());
        }

        // GET: Sunday/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SundayBars sundayBars = db.SundayBars.Find(id);
            if (sundayBars == null)
            {
                return HttpNotFound();
            }
            return View(sundayBars);
        }

        // GET: Sunday/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sunday/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BarsID,BarName,Specials,DaytimeBusyness,EveningBusyness,NightTimeBusyness,AdditionalFeatures")] SundayBars sundayBars)
        {
            if (ModelState.IsValid)
            {
                db.SundayBars.Add(sundayBars);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sundayBars);
        }

        // GET: Sunday/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SundayBars sundayBars = db.SundayBars.Find(id);
            if (sundayBars == null)
            {
                return HttpNotFound();
            }
            return View(sundayBars);
        }

        // POST: Sunday/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BarsID,BarName,Specials,DaytimeBusyness,EveningBusyness,NightTimeBusyness,AdditionalFeatures")] SundayBars sundayBars)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sundayBars).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sundayBars);
        }

        // GET: Sunday/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SundayBars sundayBars = db.SundayBars.Find(id);
            if (sundayBars == null)
            {
                return HttpNotFound();
            }
            return View(sundayBars);
        }

        // POST: Sunday/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SundayBars sundayBars = db.SundayBars.Find(id);
            db.SundayBars.Remove(sundayBars);
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
