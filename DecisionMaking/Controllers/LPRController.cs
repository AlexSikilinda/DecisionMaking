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
    public class LPRController : Controller
    {
        private DecisionContext db = new DecisionContext();

        // GET: LPR
        public ActionResult Index()
        {
            return View(db.LPRs.ToList());
        }

        // GET: LPR/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LPR lPR = db.LPRs.Find(id);
            if (lPR == null)
            {
                return HttpNotFound();
            }
            return View(lPR);
        }

        // GET: LPR/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LPR/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LNum,LName,LRange")] LPR lPR)
        {
            if (ModelState.IsValid)
            {
                db.LPRs.Add(lPR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lPR);
        }

        // GET: LPR/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LPR lPR = db.LPRs.Find(id);
            if (lPR == null)
            {
                return HttpNotFound();
            }
            return View(lPR);
        }

        // POST: LPR/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LNum,LName,LRange")] LPR lPR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lPR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lPR);
        }

        // GET: LPR/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LPR lPR = db.LPRs.Find(id);
            if (lPR == null)
            {
                return HttpNotFound();
            }
            return View(lPR);
        }

        // POST: LPR/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LPR lPR = db.LPRs.Find(id);
            db.LPRs.Remove(lPR);
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
