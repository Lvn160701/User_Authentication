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
    public class UserCourseController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UserCourse
        public ActionResult Index()
        {
            var userCourse = db.UserCourse.Include(u => u.Course);
            return View(userCourse.ToList());
        }

        // GET: UserCourse/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserCourse userCourse = db.UserCourse.Find(id);
            if (userCourse == null)
            {
                return HttpNotFound();
            }
            return View(userCourse);
        }

        // GET: UserCourse/Create
        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.Course, "ID", "Name");
            ViewBag.Users = db.Users;
            return View();
        }

        // POST: UserCourse/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int CourseID, string[] userIds)
        {
            foreach (string userId in userIds)
            {
                UserCourse userCourese = new UserCourse();
                userCourese.CourseID = CourseID;
                userCourese.UserID = userId;
                db.UserCourse.Add(userCourese);
                db.SaveChanges();

            }
            return RedirectToAction("Index", "Home");
        }

        // GET: UserCourse/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserCourse userCourse = db.UserCourse.Find(id);
            if (userCourse == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(db.Course, "ID", "Name", userCourse.CourseID);
            return View(userCourse);
        }

        // POST: UserCourse/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,CourseID")] UserCourse userCourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userCourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.Course, "ID", "Name", userCourse.CourseID);
            return View(userCourse);
        }

        // GET: UserCourse/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserCourse userCourse = db.UserCourse.Find(id);
            if (userCourse == null)
            {
                return HttpNotFound();
            }
            return View(userCourse);
        }

        // POST: UserCourse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            UserCourse userCourse = db.UserCourse.Find(id);
            db.UserCourse.Remove(userCourse);
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
