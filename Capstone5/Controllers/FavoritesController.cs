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
    public class FavoritesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Favorites
        public ActionResult Index()
        {
            return View(db.FavoriteBars.ToList());
        }

        // GET: Favorites/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FavoriteBars favoriteBars = db.FavoriteBars.Find(id);
            if (favoriteBars == null)
            {
                return HttpNotFound();
            }
            return View(favoriteBars);
        }

        // GET: Favorites/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Favorites/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BarsID,BarName,Specials,DaytimeBusyness,EveningBusyness,NightTimeBusyness,AdditionalFeatures")] FavoriteBars favoriteBars)
        {
            if (ModelState.IsValid)
            {
                db.FavoriteBars.Add(favoriteBars);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(favoriteBars);
        }

        // GET: Favorites/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FavoriteBars favoriteBars = db.FavoriteBars.Find(id);
            if (favoriteBars == null)
            {
                return HttpNotFound();
            }
            return View(favoriteBars);
        }

        // POST: Favorites/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BarsID,BarName,Specials,DaytimeBusyness,EveningBusyness,NightTimeBusyness,AdditionalFeatures")] FavoriteBars favoriteBars)
        {
            if (ModelState.IsValid)
            {
                db.Entry(favoriteBars).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(favoriteBars);
        }

        // GET: Favorites/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FavoriteBars favoriteBars = db.FavoriteBars.Find(id);
            if (favoriteBars == null)
            {
                return HttpNotFound();
            }
            return View(favoriteBars);
        }

        // POST: Favorites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FavoriteBars favoriteBars = db.FavoriteBars.Find(id);
            db.FavoriteBars.Remove(favoriteBars);
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
