using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IAO.Models;

namespace IAO.Controllers
{
    public class UserApplicantsController : Controller
    {
        private IAODbContext db = new IAODbContext();

        // GET: UserApplicants
        public ActionResult Index()
        {
            var userApplicants = db.UserApplicants.Include(u => u.SchoolBackground);
            return View(userApplicants.ToList());
        }

        // GET: UserApplicants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserApplicant userApplicant = db.UserApplicants.Find(id);
            if (userApplicant == null)
            {
                return HttpNotFound();
            }
            return View(userApplicant);
        }

        // GET: UserApplicants/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.SchoolBackgrounds, "UserId", "SchoolName");
            return View();
        }

        // POST: UserApplicants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,Email,Password,ConfirmPassword")] UserApplicant userApplicant)
        {
            if (ModelState.IsValid)
            {
                db.UserApplicants.Add(userApplicant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.SchoolBackgrounds, "UserId", "SchoolName", userApplicant.UserId);
            return View(userApplicant);
        }

        // GET: UserApplicants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserApplicant userApplicant = db.UserApplicants.Find(id);
            if (userApplicant == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.SchoolBackgrounds, "UserId", "SchoolName", userApplicant.UserId);
            return View(userApplicant);
        }

        // POST: UserApplicants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,Email,Password,ConfirmPassword")] UserApplicant userApplicant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userApplicant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.SchoolBackgrounds, "UserId", "SchoolName", userApplicant.UserId);
            return View(userApplicant);
        }

        // GET: UserApplicants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserApplicant userApplicant = db.UserApplicants.Find(id);
            if (userApplicant == null)
            {
                return HttpNotFound();
            }
            return View(userApplicant);
        }

        // POST: UserApplicants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserApplicant userApplicant = db.UserApplicants.Find(id);
            db.UserApplicants.Remove(userApplicant);
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
