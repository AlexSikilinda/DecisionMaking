using DecisionMaking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DecisionMaking.Controllers
{
    public class MarkController : Controller
    {
        // GET: Mark
        public ActionResult Index()
        {
            var result = new List<Mark>
            {
                new Mark
                {
                    MNum = 1,
                    CNum = 1,
                    MName = "Test Mark 1",
                    MRange = 1,
                    NumMark = 1,
                    NormMark = 1,
                    Criterion = new Criterion(),
                    Vectors = new List<Vector>(),
                },
                new Mark
                {
                    MNum = 2,
                    CNum = 2,
                    MName = "Test Mark 2",
                    MRange = 2,
                    NumMark = 2,
                    NormMark = 2,
                    Criterion = new Criterion(),
                    Vectors = new List<Vector>(),
                }
            };
            return View(result);
        }

        // GET: Mark/Details/5
        public ActionResult Details(int id)
        {
            var fakeModel = new Mark
            {
                MNum = 1,
                CNum = 1,
                MName = "Test Mark 1",
                MRange = 1,
                NumMark = 1,
                NormMark = 1,
                Criterion = new Criterion(),
                Vectors = new List<Vector>(),
            };
            return View(fakeModel);
        }

        // GET: Mark/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mark/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Mark/Edit/5
        public ActionResult Edit(int id)
        {
            var fakeModel = new Mark
            {
                MNum = 1,
                CNum = 1,
                MName = "Test Mark 1",
                MRange = 1,
                NumMark = 1,
                NormMark = 1,
                Criterion = new Criterion(),
                Vectors = new List<Vector>(),
            };
            return View(fakeModel);
        }

        // POST: Mark/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Mark/Delete/5
        public ActionResult Delete(int id)
        {
            return RedirectToAction("Index");
        }
    }
}
