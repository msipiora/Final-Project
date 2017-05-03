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
    public class FridayController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Friday
        public ActionResult Index()
        {
            return View(db.FridayBars.ToList());
        }

        // GET: Friday/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FridayBars fridayBars = db.FridayBars.Find(id);
            if (fridayBars == null)
            {
                return HttpNotFound();
            }
            return View(fridayBars);
        }

        // GET: Friday/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Friday/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BarsID,BarName,Specials,DaytimeBusyness,EveningBusyness,NightTimeBusyness,AdditionalFeatures")] FridayBars fridayBars)
        {
            if (ModelState.IsValid)
            {
                db.FridayBars.Add(fridayBars);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fridayBars);
        }

        // GET: Friday/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FridayBars fridayBars = db.FridayBars.Find(id);
            if (fridayBars == null)
            {
                return HttpNotFound();
            }
            return View(fridayBars);
        }

        // POST: Friday/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BarsID,BarName,Specials,DaytimeBusyness,EveningBusyness,NightTimeBusyness,AdditionalFeatures")] FridayBars fridayBars)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fridayBars).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fridayBars);
        }

        // GET: Friday/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FridayBars fridayBars = db.FridayBars.Find(id);
            if (fridayBars == null)
            {
                return HttpNotFound();
            }
            return View(fridayBars);
        }

        // POST: Friday/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FridayBars fridayBars = db.FridayBars.Find(id);
            db.FridayBars.Remove(fridayBars);
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
