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
    public class VectorController : Controller
    {
        private DecisionContext db = new DecisionContext();

        // GET: Vector
        public ActionResult Index()
        {
            var vectors = db.Vectors.Include(v => v.Alternative).Include(v => v.Mark);
            return View(vectors.ToList());
        }

        // GET: Vector/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vector vector = db.Vectors.Find(id);
            if (vector == null)
            {
                return HttpNotFound();
            }
            return View(vector);
        }

        // GET: Vector/Create
        public ActionResult Create()
        {
            ViewBag.ANum = new SelectList(db.Alternatives, "ANum", "AName");
            ViewBag.MNum = new SelectList(db.Marks, "MNum", "MName");
            return View();
        }

        // POST: Vector/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VNum,ANum,MNum")] Vector vector)
        {
            if (ModelState.IsValid)
            {
                db.Vectors.Add(vector);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ANum = new SelectList(db.Alternatives, "ANum", "AName", vector.ANum);
            ViewBag.MNum = new SelectList(db.Marks, "MNum", "MName", vector.MNum);
            return View(vector);
        }

        // GET: Vector/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vector vector = db.Vectors.Find(id);
            if (vector == null)
            {
                return HttpNotFound();
            }
            ViewBag.ANum = new SelectList(db.Alternatives, "ANum", "AName", vector.ANum);
            ViewBag.MNum = new SelectList(db.Marks, "MNum", "MName", vector.MNum);
            return View(vector);
        }

        // POST: Vector/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VNum,ANum,MNum")] Vector vector)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vector).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ANum = new SelectList(db.Alternatives, "ANum", "AName", vector.ANum);
            ViewBag.MNum = new SelectList(db.Marks, "MNum", "MName", vector.MNum);
            return View(vector);
        }

        // GET: Vector/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vector vector = db.Vectors.Find(id);
            if (vector == null)
            {
                return HttpNotFound();
            }
            return View(vector);
        }

        // POST: Vector/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vector vector = db.Vectors.Find(id);
            db.Vectors.Remove(vector);
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
