﻿using System;
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
    public class SaturdayController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Saturday
        public ActionResult Index()
        {
            return View(db.SaturdayBars.ToList());
        }

        // GET: Saturday/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaturdayBars saturdayBars = db.SaturdayBars.Find(id);
            if (saturdayBars == null)
            {
                return HttpNotFound();
            }
            return View(saturdayBars);
        }

        // GET: Saturday/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Saturday/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BarsID,BarName,Specials,DaytimeBusyness,EveningBusyness,NightTimeBusyness,AdditionalFeatures")] SaturdayBars saturdayBars)
        {
            if (ModelState.IsValid)
            {
                db.SaturdayBars.Add(saturdayBars);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(saturdayBars);
        }

        // GET: Saturday/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaturdayBars saturdayBars = db.SaturdayBars.Find(id);
            if (saturdayBars == null)
            {
                return HttpNotFound();
            }
            return View(saturdayBars);
        }

        // POST: Saturday/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BarsID,BarName,Specials,DaytimeBusyness,EveningBusyness,NightTimeBusyness,AdditionalFeatures")] SaturdayBars saturdayBars)
        {
            if (ModelState.IsValid)
            {
                db.Entry(saturdayBars).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(saturdayBars);
        }

        // GET: Saturday/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaturdayBars saturdayBars = db.SaturdayBars.Find(id);
            if (saturdayBars == null)
            {
                return HttpNotFound();
            }
            return View(saturdayBars);
        }

        // POST: Saturday/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SaturdayBars saturdayBars = db.SaturdayBars.Find(id);
            db.SaturdayBars.Remove(saturdayBars);
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
