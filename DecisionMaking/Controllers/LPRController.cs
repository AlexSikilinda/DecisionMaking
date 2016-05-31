using DecisionMaking.Models;
using System.Web.Mvc;

namespace DecisionMaking.Controllers
{
    public class LPRController : Controller
    {
        // GET: LPR
        public ActionResult Index()
        {
            return View();
        }

        // GET: LPR/Details/5
        public ActionResult Details(int id)
        {
            var fakeModel = new LPR()
            {
                LNum = 1,
                LName = "Test LPR 1",
                LRange = 1
            };
            return View(fakeModel);
        }

        // GET: LPR/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LPR/Create
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

        // GET: LPR/Edit/5
        public ActionResult Edit(int id)
        {
            var fakeModel = new LPR()
            {
                LNum = 1,
                LName = "Test LPR 1",
                LRange = 1
            };
            return View(fakeModel);
        }

        // POST: LPR/Edit/5
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

        // GET: LPR/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LPR/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
