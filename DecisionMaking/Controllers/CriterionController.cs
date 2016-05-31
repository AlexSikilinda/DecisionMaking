using DecisionMaking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DecisionMaking.Controllers
{
    public class CriterionController : Controller
    {
        // GET: Criterion
        public ActionResult Index()
        {
            var result = new List<Criterion>
            {
                new Criterion
                {
                    CNum = 1,
                    CName = "Test Criterion 1",
                    CRange = 1,
                    CWeight = 1,
                    CType = "CType :)",
                    OptimType = "OptimType :)",
                    EdIzmer = "EdIzmer :)",
                    ScaleType = "ScaleType :)",
                    Marks = new List<Mark>()
                },
                new Criterion
                {
                    CNum = 2,
                    CName = "Test Criterion 2",
                    CRange = 2,
                    CWeight = 2,
                    CType = "CType :)",
                    OptimType = "OptimType :)",
                    EdIzmer = "EdIzmer :)",
                    ScaleType = "ScaleType :)",
                    Marks = new List<Mark>()
                }
            };
            return View(result);
        }

        // GET: Criterion/Details/5
        public ActionResult Details(int id)
        {
            var fakeModel = new Criterion
            {
                CNum = 1,
                CName = "Test Criterion 1",
                CRange = 1,
                CWeight = 1,
                CType = "CType :)",
                OptimType = "OptimType :)",
                EdIzmer = "EdIzmer :)",
                ScaleType = "ScaleType :)",
                Marks = new List<Mark>()
            };
            return View(fakeModel);
        }

        // GET: Criterion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Criterion/Create
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

        // GET: Criterion/Edit/5
        public ActionResult Edit(int id)
        {
            var fakeModel = new Criterion
            {
                CNum = 1,
                CName = "Test Criterion 1",
                CRange = 1,
                CWeight = 1,
                CType = "CType :)",
                OptimType = "OptimType :)",
                EdIzmer = "EdIzmer :)",
                ScaleType = "ScaleType :)",
                Marks = new List<Mark>()
            };
            return View(fakeModel);
        }

        // POST: Criterion/Edit/5
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

        // GET: Criterion/Delete/5
        public ActionResult Delete(int id)
        {
            return RedirectToAction("Index");
        }
    }
}
