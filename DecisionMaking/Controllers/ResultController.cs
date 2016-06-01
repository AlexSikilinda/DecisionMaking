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
using Newtonsoft.Json;

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
            int peopleCount = 5;//db.LPRs.Count();
            int alternativeCount = 3; //db.Alternatives.Count();

            string[,] result = new string[alternativeCount, peopleCount]; // peopleCount - X, alternativeCount - Y

            ViewBag.Aliternatives = db.Alternatives.ToList();
            return View(result);
        }

        [HttpPost]
        public string WithDropped(string result)
        {
            string[,] test = JsonConvert.DeserializeObject<string[,]>(result);
            int peopleCount = test.GetLength(1);


            var t = Enumerable.Range(0, peopleCount).Select(x => test[0, x]).GroupBy(x => x).OrderByDescending(x => x.Count()).ToList();



            int firstCount = t[0].Count();
            string maxFirst = t[0].Key;
            peopleCount = (peopleCount % 2) == 0 ? peopleCount : ++peopleCount;


            if (firstCount > (peopleCount / 2))
            {
                return maxFirst;
            }

            int secondCount = t[1].Count();
            string maxSecond = t[1].Key;


            int compare = 0;
            for (int i = 0; i < test.GetLength(1); i++)
            {
                string[] row = GetRow(test, i);

                int firstIndex = Array.IndexOf(row, maxFirst);
                int secondIndex = Array.IndexOf(row, maxSecond);

                compare += firstIndex < secondIndex ? 1 : -1;
            }


            return compare > 0 ? maxFirst : maxSecond;
        }

        private string[] GetRow(string[,] array, int index)
        {
            var t2 = Enumerable.Range(0, array.GetLength(0)).Select(x => array[x, index]).ToArray();
            return t2;
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
            model.Alternatives = db.Alternatives;
            double[,] initialMatrix = GetInitialMatrix();
            model.ResultMatrix = GetResultMatrix(initialMatrix);
            return View(model);
        }

        private double[,] GetResultMatrix(double[,] initialMatrix)
        {
            int alterCount = db.Alternatives.Count();
            int criteriaCount = db.Criterions.Count();
            double[,] resultMatrix = new double[alterCount, criteriaCount];
            for (int i = 0; i < alterCount; i++)
            {
                for (int j = 0; j < criteriaCount; j++)
                {
                    resultMatrix[i, j] = GetNormMnozhitel(initialMatrix, j) * initialMatrix[i, j];
                }
            }
            return resultMatrix;
        }

        private double GetNormMnozhitel(double[,] initialMatrix, int j)
        {
            double sum = 0;
            for (int i = 0; i < initialMatrix.GetLength(0); i++)
            {
                sum += initialMatrix[i, j];
            }
            return 1 / sum;
        }

        private double[,] GetInitialMatrix()
        {
            var criterions = db.Criterions.Include(c => c.Marks).ToList();
            var alternatives = db.Alternatives.Include("Vectors.Mark").ToList();
            int criteriaNumber = criterions.Count();
            int alternativeNumber = alternatives.Count();
            double[,] initialMatrix = new double[alternativeNumber, criteriaNumber];
            for (int i = 0; i < alternativeNumber; i++)
            {
                for (int j = 0; j < criteriaNumber; j++)
                {
                    double criteriaValue = alternatives[i].Vectors.OrderBy(v => v.Mark.Criterion.CName).ToList()[j].Mark.NumMark;
                    initialMatrix[i, j] = criteriaValue;
                }
            }
            return initialMatrix;
        }

        [HttpPost]
        public ActionResult Submit(int anum, int lnum)
        {
            db.Results.Add(new Result
            {
                ANum = anum,
                AWeight = 0,
                LNum = lnum,
                Range = 1
            });
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
