using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ZP50.Core.CentroAscolto;
using ZP50.Core.DataLayer;

namespace ZP50.Web.Areas.CentroAscolto.Controllers
{
    public class SchedeIncontriController : Controller
    {
        private CentroAscoltoContext db = new CentroAscoltoContext();

        // GET: CentroAscolto/SchedeIncontri
        public ActionResult Index()
        {
            return View(db.SchedaIncontroes.ToList());
        }

        // GET: CentroAscolto/SchedeIncontri/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SchedaIncontro schedaIncontro = db.SchedaIncontroes.Find(id);
            if (schedaIncontro == null)
            {
                return HttpNotFound();
            }
            return View(schedaIncontro);
        }

        // GET: CentroAscolto/SchedeIncontri/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CentroAscolto/SchedeIncontri/Create
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NucleoFamiliareID,Sintesi,CreataIl,CreataDa")] SchedaIncontro schedaIncontro)
        {
            if (ModelState.IsValid)
            {
                schedaIncontro.ID = Guid.NewGuid();
                db.SchedaIncontroes.Add(schedaIncontro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(schedaIncontro);
        }

        // GET: CentroAscolto/SchedeIncontri/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SchedaIncontro schedaIncontro = db.SchedaIncontroes.Find(id);
            if (schedaIncontro == null)
            {
                return HttpNotFound();
            }
            return View(schedaIncontro);
        }

        // POST: CentroAscolto/SchedeIncontri/Edit/5
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NucleoFamiliareID,Sintesi,CreataIl,CreataDa")] SchedaIncontro schedaIncontro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(schedaIncontro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(schedaIncontro);
        }

        // GET: CentroAscolto/SchedeIncontri/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SchedaIncontro schedaIncontro = db.SchedaIncontroes.Find(id);
            if (schedaIncontro == null)
            {
                return HttpNotFound();
            }
            return View(schedaIncontro);
        }

        // POST: CentroAscolto/SchedeIncontri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            SchedaIncontro schedaIncontro = db.SchedaIncontroes.Find(id);
            db.SchedaIncontroes.Remove(schedaIncontro);
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
