﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UserAuthentication.Models;

namespace UserAuthentication.Controllers
{
    public class CourseCategoryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CourseCategory
        public ActionResult Index()
        {
            return View(db.CourseCategories.ToList());
        }

        // GET: CourseCategory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseCategory courseCategory = db.CourseCategories.Find(id);
            if (courseCategory == null)
            {
                return HttpNotFound();
            }
            return View(courseCategory);
        }

        // GET: CourseCategory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourseCategory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] CourseCategory courseCategory)
        {
            if (ModelState.IsValid)
            {
                db.CourseCategories.Add(courseCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(courseCategory);
        }

        // GET: CourseCategory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseCategory courseCategory = db.CourseCategories.Find(id);
            if (courseCategory == null)
            {
                return HttpNotFound();
            }
            return View(courseCategory);
        }

        // POST: CourseCategory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] CourseCategory courseCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courseCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(courseCategory);
        }

        // GET: CourseCategory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseCategory courseCategory = db.CourseCategories.Find(id);
            if (courseCategory == null)
            {
                return HttpNotFound();
            }
            return View(courseCategory);
        }

        // POST: CourseCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CourseCategory courseCategory = db.CourseCategories.Find(id);
            db.CourseCategories.Remove(courseCategory);
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
