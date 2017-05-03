using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Capstone5.Models;
using Microsoft.AspNet.Identity;

namespace Capstone5.Controllers
{
    public class WednesdayController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Wednesday
        public ActionResult Index()
        {
            return View(db.WednesdayBars.ToList());
        }

        // GET: Wednesday/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WednesdayBars wednesdayBars = db.WednesdayBars.Find(id);
            if (wednesdayBars == null)
            {
                return HttpNotFound();
            }
            return View(wednesdayBars);
        }

        // GET: Wednesday/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Wednesday/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BarsID,BarName,Specials,DaytimeBusyness,EveningBusyness,NightTimeBusyness,AdditionalFeatures")] WednesdayBars wednesdayBars)
        {
            if (ModelState.IsValid)
            {
                db.WednesdayBars.Add(wednesdayBars);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(wednesdayBars);
        }

        // GET: Wednesday/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WednesdayBars wednesdayBars = db.WednesdayBars.Find(id);
            if (wednesdayBars == null)
            {
                return HttpNotFound();
            }
            return View(wednesdayBars);
        }

        // POST: Wednesday/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BarsID,BarName,Specials,DaytimeBusyness,EveningBusyness,NightTimeBusyness,AdditionalFeatures")] WednesdayBars wednesdayBars)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wednesdayBars).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wednesdayBars);
        }

        // GET: Wednesday/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WednesdayBars wednesdayBars = db.WednesdayBars.Find(id);
            if (wednesdayBars == null)
            {
                return HttpNotFound();
            }
            return View(wednesdayBars);
        }

        // POST: Wednesday/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WednesdayBars wednesdayBars = db.WednesdayBars.Find(id);
            db.WednesdayBars.Remove(wednesdayBars);
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

