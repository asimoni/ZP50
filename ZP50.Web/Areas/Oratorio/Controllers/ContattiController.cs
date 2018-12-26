using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ZP50.Core.DataLayer;
using ZP50.Core.Oratorio;

namespace ZP50.Web.Areas.Oratorio.Controllers
{
    public class ContattiController : Controller
    {
        private OratorioContext db = new OratorioContext();

        // GET: Oratorio/Contatti
        public ActionResult Index()
        {
            return View(db.Contatti.ToList());
        }

        // GET: Oratorio/Contatti/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contatto contatto = db.Contatti.Find(id);
            if (contatto == null)
            {
                return HttpNotFound();
            }
            return View(contatto);
        }

        // GET: Oratorio/Contatti/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Oratorio/Contatti/Create
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,Cognome,Telefono,Email")] Contatto contatto)
        {
            if (ModelState.IsValid)
            {
                db.Contatti.Add(contatto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contatto);
        }

        // GET: Oratorio/Contatti/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contatto contatto = db.Contatti.Find(id);
            if (contatto == null)
            {
                return HttpNotFound();
            }
            return View(contatto);
        }

        // POST: Oratorio/Contatti/Edit/5
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Cognome,Telefono,Email")] Contatto contatto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contatto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contatto);
        }

        // GET: Oratorio/Contatti/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contatto contatto = db.Contatti.Find(id);
            if (contatto == null)
            {
                return HttpNotFound();
            }
            return View(contatto);
        }

        // POST: Oratorio/Contatti/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contatto contatto = db.Contatti.Find(id);
            db.Contatti.Remove(contatto);
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
