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
    public class MondayController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MondayBars
        public ActionResult Index()
        {
            return View(db.MondayBars.ToList());
        }

        // GET: MondayBars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MondayBars mondayBars = db.MondayBars.Find(id);
            if (mondayBars == null)
            {
                return HttpNotFound();
            }
            return View(mondayBars);
        }

        // GET: MondayBars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MondayBars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BarsID,BarName,Specials,DaytimeBusyness,EveningBusyness,NightTimeBusyness,AdditionalFeatures")] MondayBars mondayBars)
        {
            if (ModelState.IsValid)
            {
                db.MondayBars.Add(mondayBars);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mondayBars);
        }

        // GET: MondayBars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MondayBars mondayBars = db.MondayBars.Find(id);
            if (mondayBars == null)
            {
                return HttpNotFound();
            }
            return View(mondayBars);
        }

        // POST: MondayBars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BarsID,BarName,Specials,DaytimeBusyness,EveningBusyness,NightTimeBusyness,AdditionalFeatures")] MondayBars mondayBars)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mondayBars).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mondayBars);
        }

        // GET: MondayBars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MondayBars mondayBars = db.MondayBars.Find(id);
            if (mondayBars == null)
            {
                return HttpNotFound();
            }
            return View(mondayBars);
        }

        // POST: MondayBars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MondayBars mondayBars = db.MondayBars.Find(id);
            db.MondayBars.Remove(mondayBars);
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
