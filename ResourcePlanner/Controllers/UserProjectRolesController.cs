using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ResourcePlanner.Models;

namespace ResourcePlanner.Controllers
{
    public class UserProjectRolesController : Controller
    {
        private UsersContext db = new UsersContext();

        // GET: UserProjectRoles
        public ActionResult Index()
        {
            var userProjectRoles = db.UserProjectRoles.Include(u => u.Person).Include(u => u.Project);
            return View(userProjectRoles.ToList());
        }

        // GET: UserProjectRoles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProjectRole userProjectRole = db.UserProjectRoles.Find(id);
            if (userProjectRole == null)
            {
                return HttpNotFound();
            }
            return View(userProjectRole);
        }

        // GET: UserProjectRoles/Create
        public ActionResult Create()
        {
            ViewBag.PersonID = new SelectList(db.Persons, "PersonId", "Name");
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectId", "Name");
            return View();
        }

        // POST: UserProjectRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserProjectRoleId,PersonID,ProjectID")] UserProjectRole userProjectRole)
        {
            if (ModelState.IsValid)
            {
                db.UserProjectRoles.Add(userProjectRole);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersonID = new SelectList(db.Persons, "PersonId", "Name", userProjectRole.PersonID);
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectId", "Name", userProjectRole.ProjectID);
            return View(userProjectRole);
        }

        // GET: UserProjectRoles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProjectRole userProjectRole = db.UserProjectRoles.Find(id);
            if (userProjectRole == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonID = new SelectList(db.Persons, "PersonId", "Name", userProjectRole.PersonID);
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectId", "Name", userProjectRole.ProjectID);
            return View(userProjectRole);
        }

        // POST: UserProjectRoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserProjectRoleId,PersonID,ProjectID")] UserProjectRole userProjectRole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userProjectRole).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PersonID = new SelectList(db.Persons, "PersonId", "Name", userProjectRole.PersonID);
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectId", "Name", userProjectRole.ProjectID);
            return View(userProjectRole);
        }

        // GET: UserProjectRoles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProjectRole userProjectRole = db.UserProjectRoles.Find(id);
            if (userProjectRole == null)
            {
                return HttpNotFound();
            }
            return View(userProjectRole);
        }

        // POST: UserProjectRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserProjectRole userProjectRole = db.UserProjectRoles.Find(id);
            db.UserProjectRoles.Remove(userProjectRole);
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
