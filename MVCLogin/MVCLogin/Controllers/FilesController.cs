using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCLogin.Models;

namespace MVCLogin.Controllers
{
    public class FilesController : Controller
    {
        private OurDbContext db = new OurDbContext();

        // GET: Files
        public ActionResult Index(string searchBy, string search)
        {
            if (searchBy == "Reference")
            {
                return View(db.File.Where(x => x.Reference.StartsWith(search) || search == null).ToList());
            }
            else if (searchBy == "Attorney")
            {
                return View(db.File.Where(x => x.Attorney.StartsWith(search) || search == null).ToList());
            }
            else if (searchBy == "ClaimentName")
            {
                return View(db.File.Where(x => x.ClaimentName.StartsWith(search) || search == null).ToList());
            }
            else if (searchBy == "ClaimentSurname")
            {
                return View(db.File.Where(x => x.ClaimentSurname.StartsWith(search) || search == null).ToList());
            }
            else
            {
                return View(db.File.Where(x => x.ClaimentID.StartsWith(search) || search == null).ToList());
            }


        }

        // GET: Files/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Files files = db.File.Find(id);
            if (files == null)
            {
                return HttpNotFound();
            }
            return View(files);
        }

        // GET: Files/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Files/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "No,Reference,Attorney,ClaimentName,ClaimentSurname,ClaimentID")] Files files)
        {
            if (ModelState.IsValid)
            {
                db.File.Add(files);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(files);
        }

        // GET: Files/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Files files = db.File.Find(id);
            if (files == null)
            {
                return HttpNotFound();
            }
            return View(files);
        }

        // POST: Files/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "No,Reference,Attorney,ClaimentName,ClaimentSurname,ClaimentID")] Files files)
        {
            if (ModelState.IsValid)
            {
                db.Entry(files).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(files);
        }

        // GET: Files/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Files files = db.File.Find(id);
            if (files == null)
            {
                return HttpNotFound();
            }
            return View(files);
        }

        // POST: Files/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Files files = db.File.Find(id);
            db.File.Remove(files);
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
