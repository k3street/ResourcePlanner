using ResourcePlanner.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResourcePlanner.Controllers
{
    public class MSUSController : Controller
    {
        private UsersContext db = new UsersContext();
        // GET: MSUS
        public ActionResult Index(string searchString)
        {
            return View(db.Persons.OrderBy(p => p.Name).ToList());
        }

        // GET: MSUS/Autocomplete
        public ActionResult Autocomplete(string term)
        {
            string[] people = db.Persons.Select(p => p.Name.ToUpper()).ToArray();
            return this.Json(people.Where(p => p.StartsWith(term.ToUpper())), JsonRequestBehavior.AllowGet);
        }

        // GET: MSUS/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MSUS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MSUS/Create
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

        // GET: MSUS/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MSUS/Edit/5
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

        // GET: MSUS/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MSUS/Delete/5
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
