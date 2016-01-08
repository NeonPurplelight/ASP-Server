using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using aspserver_sfb.Models;

namespace aspserver_sfb.Controllers
{
    public class InseratController : Controller
    {
        private InseratDBContext db = new InseratDBContext();

        // GET: Inserat
        public ActionResult Index()
        {
            return View(db.Inserat.ToList());
        }

        // GET: Inserat/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inserat inserat = db.Inserat.Find(id);
            if (inserat == null)
            {
                return HttpNotFound();
            }
            return View(inserat);
        }

        // GET: Inserat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inserat/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Beschreibung")] Inserat inserat)
        {
            if (ModelState.IsValid)
            {
                db.Inserat.Add(inserat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(inserat);
        }

        // GET: Inserat/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inserat inserat = db.Inserat.Find(id);
            if (inserat == null)
            {
                return HttpNotFound();
            }
            return View(inserat);
        }

        // POST: Inserat/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Beschreibung")] Inserat inserat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inserat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inserat);
        }

        // GET: Inserat/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inserat inserat = db.Inserat.Find(id);
            if (inserat == null)
            {
                return HttpNotFound();
            }
            return View(inserat);
        }

        // POST: Inserat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inserat inserat = db.Inserat.Find(id);
            db.Inserat.Remove(inserat);
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
