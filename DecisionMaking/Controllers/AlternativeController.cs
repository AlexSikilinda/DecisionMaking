using DecisionMaking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DecisionMaking.Controllers
{
    public class AlternativeController : Controller
    {
        // GET: Alternative
        public ActionResult Index()
        {
            var result = new List<Alternative>
            {
                new Alternative()
                {
                    ANum = 1,
                    AName = "Test Alternative 1",
                    Results = new List<Result>()
                },
                new Alternative()
                {
                    ANum = 2,
                    AName = "Test Alternative 2",
                    Results = new List<Result>()
                }
            };
            return View(result);
        }

        // GET: Alternative/Details/5
        public ActionResult Details(int id)
        {
            var fakeModel = new Alternative()
            {
                ANum = 1,
                AName = "Test Alternative1",
                Results = new List<Result>()
            };
            return View(fakeModel);
        }

        // GET: Alternative/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Alternative/Create
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

        // GET: Alternative/Edit/5
        public ActionResult Edit(int id)
        {
            var fakeModel = new Alternative()
            {
                ANum = 1,
                AName = "Test Alternative1",
                Results = new List<Result>()
            };
            return View(fakeModel);
        }

        // POST: Alternative/Edit/5
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

        // GET: Alternative/Delete/5
        public ActionResult Delete(int id)
        {
            return RedirectToAction("Index");
        }
    }
}
