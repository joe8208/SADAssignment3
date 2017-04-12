﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SADAssignment3.DAL;
using SADAssignment3.Models;
using System.IO;

namespace SADAssignment3.Controllers
{
    public class LineInputsController : Controller
    {
        private SADAssignment3Context db = new SADAssignment3Context();

        // GET: LineInputs
        public ActionResult Index()
        {
            return View(db.LineInputs.ToList());
        }

        // GET: LineInputs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LineInput lineInput = db.LineInputs.Find(id);
            if (lineInput == null)
            {
                return HttpNotFound();
            }
            return View(lineInput);
        }

        // GET: LineInputs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LineInputs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descriptor,Url")] LineInput lineInput)
        {
            if (ModelState.IsValid)
            {
                db.LineInputs.Add(lineInput);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lineInput);
        }

        // GET: LineInputs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LineInput lineInput = db.LineInputs.Find(id);
            if (lineInput == null)
            {
                return HttpNotFound();
            }
            return View(lineInput);
        }

        // POST: LineInputs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descriptor,Url")] LineInput lineInput)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lineInput).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lineInput);
        }

        // GET: LineInputs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LineInput lineInput = db.LineInputs.Find(id);
            if (lineInput == null)
            {
                return HttpNotFound();
            }
            return View(lineInput);
        }

        // POST: LineInputs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LineInput lineInput = db.LineInputs.Find(id);
            db.LineInputs.Remove(lineInput);
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

        // GET: LineInputs/TextInput
        public ActionResult TextInput()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TextInput(DataInput model)
        {
            if (ModelState.IsValid)
            {
                // get data from modle
                string dataInput = model.DataText;

                // loop through string and break it apart based on line breaks
                //var result = dataInput.Split()

                using (StringReader sr = new StringReader(dataInput))
                {
                    string line;
                    while((line = sr.ReadLine()) != null)
                    {
                        LineInput lineInput = new LineInput();

                        var splitString = line.Split(new[] { "http" }, StringSplitOptions.None);
                        lineInput.Descriptor = splitString[0].Trim();
                        lineInput.Url = "http" + splitString[1].Trim();

                        db.LineInputs.Add(lineInput);
                        db.SaveChanges();
                    }
                }
            }
            return RedirectToAction("Index");
        }
    }
}
