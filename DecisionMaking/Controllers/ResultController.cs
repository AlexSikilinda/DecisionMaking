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
    public class ResultController : Controller
    {
        private DecisionContext db = new DecisionContext();

        // GET: Result
        public ActionResult Index()
        {
            var results = db.Results.Include(r => r.Alternative).Include(r => r.LPR);
            return View(results.ToList());
        }

        // GET: Result/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Result result = db.Results.Find(id);
            if (result == null)
            {
                return HttpNotFound();
            }
            return View(result);
        }

        // GET: Result/Create
        public ActionResult Create()
        {
            ViewBag.ANum = new SelectList(db.Alternatives, "ANum", "AName");
            ViewBag.LNum = new SelectList(db.LPRs, "LNum", "LName");
            return View();
        }

        // POST: Result/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RNum,LNum,ANum,Range,AWeight")] Result result)
        {
            if (ModelState.IsValid)
            {
                db.Results.Add(result);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ANum = new SelectList(db.Alternatives, "ANum", "AName", result.ANum);
            ViewBag.LNum = new SelectList(db.LPRs, "LNum", "LName", result.LNum);
            return View(result);
        }

        // GET: Result/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Result result = db.Results.Find(id);
            if (result == null)
            {
                return HttpNotFound();
            }
            ViewBag.ANum = new SelectList(db.Alternatives, "ANum", "AName", result.ANum);
            ViewBag.LNum = new SelectList(db.LPRs, "LNum", "LName", result.LNum);
            return View(result);
        }

        // POST: Result/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RNum,LNum,ANum,Range,AWeight")] Result result)
        {
            if (ModelState.IsValid)
            {
                db.Entry(result).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ANum = new SelectList(db.Alternatives, "ANum", "AName", result.ANum);
            ViewBag.LNum = new SelectList(db.LPRs, "LNum", "LName", result.LNum);
            return View(result);
        }

        // GET: Result/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Result result = db.Results.Find(id);
            if (result == null)
            {
                return HttpNotFound();
            }
            return View(result);
        }

        // POST: Result/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Result result = db.Results.Find(id);
            db.Results.Remove(result);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult WithDropped()
        {
            int peopleCount = 7;//db.LPRs.Count();
            int alternativeCount = 5; //db.Alternatives.Count();

            string[,] result = new string[alternativeCount, peopleCount]; // peopleCount - X, alternativeCount - Y

            ViewBag.Aliternatives = db.Alternatives.ToList();
            return View(result);
        }

        [HttpPost]
        public ActionResult WithDropped(string[,] result)
        {
            
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // GET: Result/MinMaxDecision
        public ActionResult MinMaxDecision()
        {
            MinMaxViewModel model = new MinMaxViewModel();
            var criterions = db.Criterions.Include(c => c.Marks).ToList();
            var alternatives = db.Alternatives.Include("Vectors.Mark").ToList();
            int criteriaNumber = criterions.Count();
            int alternativeNumber = alternatives.Count();
            double[,] initialMatrix = new double[alternativeNumber, criteriaNumber];
            for (int i = 0; i < alternativeNumber; i++)
            {
                for (int j = 0; j < criteriaNumber; j++)
                {
                    double criteriaValue = alternatives[i].Vectors.ToList()[j].Mark.NumMark;
                    initialMatrix[i, j] = criteriaValue;
                }
            }
            model.InitialArray = initialMatrix;
            return View();
        }
    }
}
