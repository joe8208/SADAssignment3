using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SADAssignment3.DAL;
using SADAssignment3.Models;

namespace SADAssignment3.Controllers
{
    public class NoiseWordsController : Controller
    {
        private SADAssignment3Context db = new SADAssignment3Context();

        // GET: NoiseWords
        public ActionResult Index()
        {
            return View(db.NoiseWords.ToList());
        }

        // GET: NoiseWords/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NoiseWord noiseWord = db.NoiseWords.Find(id);
            if (noiseWord == null)
            {
                return HttpNotFound();
            }
            return View(noiseWord);
        }

        // GET: NoiseWords/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NoiseWords/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Word")] NoiseWord noiseWord)
        {
            if (ModelState.IsValid)
            {
                db.NoiseWords.Add(noiseWord);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(noiseWord);
        }

        // GET: NoiseWords/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NoiseWord noiseWord = db.NoiseWords.Find(id);
            if (noiseWord == null)
            {
                return HttpNotFound();
            }
            return View(noiseWord);
        }

        // POST: NoiseWords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Word")] NoiseWord noiseWord)
        {
            if (ModelState.IsValid)
            {
                db.Entry(noiseWord).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(noiseWord);
        }

        // GET: NoiseWords/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NoiseWord noiseWord = db.NoiseWords.Find(id);
            if (noiseWord == null)
            {
                return HttpNotFound();
            }
            return View(noiseWord);
        }

        // POST: NoiseWords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NoiseWord noiseWord = db.NoiseWords.Find(id);
            db.NoiseWords.Remove(noiseWord);
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
