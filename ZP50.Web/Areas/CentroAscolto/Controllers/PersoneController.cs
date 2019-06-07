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
    public class PersoneController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        // GET: CentroAscolto/Personas
        public ActionResult Index(Guid nucleoFamiliareId)
        {
            var items = db.Persone.Where(x => x.NucleoFamiliareID == nucleoFamiliareId).ToList();
            ViewBag.NucleoFamiliareID = nucleoFamiliareId;
            return PartialView(items);
        }

        // GET: CentroAscolto/Personas/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Persone.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // GET: CentroAscolto/Personas/Create
        public ActionResult Create(Guid nucleoFamiliareId)
        {
            return View(new Persona {
                   NucleoFamiliareID=nucleoFamiliareId
            });
        }

        // POST: CentroAscolto/Personas/Create
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NucleoFamiliareID,Nome,Cognome,Telefono,Documento,Occupazione")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                persona.ID = Guid.NewGuid();
                db.Persone.Add(persona);
                db.SaveChanges();
                return RedirectToAction("Edit", new { id=persona.ID});
            }

            return View(persona);
        }

        // GET: CentroAscolto/Personas/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Persone.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // POST: CentroAscolto/Personas/Edit/5
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NucleoFamiliareID,Nome,Cognome,Sesso,DataNascita,Telefono,Documento,Occupazione")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                db.Entry(persona).State = EntityState.Modified;
                db.SaveChanges();
            }
            return View(persona);
        }

        // GET: CentroAscolto/Personas/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Persone.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // POST: CentroAscolto/Personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Persona persona = db.Persone.Find(id);
            db.Persone.Remove(persona);
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
