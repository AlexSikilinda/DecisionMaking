using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DecisionMaking.DAL;
using DecisionMaking.Models;

namespace DecisionMaking.Controllers
{
    public class AlternativeController : Controller
    {
        private DecisionContext db = new DecisionContext();

        // GET: Alternative
        public ActionResult Index()
        {
            return View(db.Alternatives.ToList());
        }

        // GET: Alternative/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alternative alternative = db.Alternatives.Find(id);
            if (alternative == null)
            {
                return HttpNotFound();
            }
            return View(alternative);
        }

        // GET: Alternative/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Alternative/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ANum,AName")] Alternative alternative)
        {
            if (ModelState.IsValid)
            {
                db.Alternatives.Add(alternative);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(alternative);
        }

        // GET: Alternative/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alternative alternative = db.Alternatives.Find(id);
            if (alternative == null)
            {
                return HttpNotFound();
            }
            return View(alternative);
        }

        // POST: Alternative/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ANum,AName")] Alternative alternative)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alternative).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(alternative);
        }

        // GET: Alternative/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alternative alternative = db.Alternatives.Find(id);
            if (alternative == null)
            {
                return HttpNotFound();
            }
            return View(alternative);
        }

        // POST: Alternative/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Alternative alternative = db.Alternatives.Find(id);
            db.Alternatives.Remove(alternative);
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
