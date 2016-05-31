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
    public class CriterionController : Controller
    {
        private DecisionContext db = new DecisionContext();

        // GET: Criterion
        public ActionResult Index()
        {
            return View(db.Criterions.ToList());
        }

        // GET: Criterion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Criterion criterion = db.Criterions.Find(id);
            if (criterion == null)
            {
                return HttpNotFound();
            }
            return View(criterion);
        }

        // GET: Criterion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Criterion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CNum,CName,CRange,CWeight,CType,OptimType,EdIzmer,ScaleType")] Criterion criterion)
        {
            if (ModelState.IsValid)
            {
                db.Criterions.Add(criterion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(criterion);
        }

        // GET: Criterion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Criterion criterion = db.Criterions.Find(id);
            if (criterion == null)
            {
                return HttpNotFound();
            }
            return View(criterion);
        }

        // POST: Criterion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CNum,CName,CRange,CWeight,CType,OptimType,EdIzmer,ScaleType")] Criterion criterion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(criterion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(criterion);
        }

        // GET: Criterion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Criterion criterion = db.Criterions.Find(id);
            if (criterion == null)
            {
                return HttpNotFound();
            }
            return View(criterion);
        }

        // POST: Criterion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Criterion criterion = db.Criterions.Find(id);
            db.Criterions.Remove(criterion);
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
