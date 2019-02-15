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
    public class NucleiFamiliariController : Controller
    {
        private CentroAscoltoContext db = new CentroAscoltoContext();

        // GET: CentroAscolto/NucleiFamiliari
        public ActionResult Index()
        {
            return View(db.NucleiFamiliari.ToList());
        }

        // GET: CentroAscolto/NucleiFamiliari/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NucleoFamiliare nucleoFamiliare = db.NucleiFamiliari.Find(id);
            if (nucleoFamiliare == null)
            {
                return HttpNotFound();
            }
            return View(nucleoFamiliare);
        }

        // GET: CentroAscolto/NucleiFamiliari/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CentroAscolto/NucleiFamiliari/Create
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,Residenza,Annotazioni")] NucleoFamiliare nucleoFamiliare)
        {
            if (ModelState.IsValid)
            {
                nucleoFamiliare.ID = Guid.NewGuid();
                nucleoFamiliare.CreataDa = "operatore";
                nucleoFamiliare.CreataIl = DateTime.Now;
                nucleoFamiliare.AggiornataDa = "operatore";
                nucleoFamiliare.AggiornataIl = DateTime.Now;
                nucleoFamiliare.DichiarazioneIsee = new DichiarazioneIsee { DataScadenza=new DateTime(2000,1,1), ValoreIndicatore=0}
                    ;

                db.NucleiFamiliari.Add(nucleoFamiliare);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nucleoFamiliare);
        }

        // GET: CentroAscolto/NucleiFamiliari/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NucleoFamiliare nucleoFamiliare = db.NucleiFamiliari.Find(id);
            if (nucleoFamiliare == null)
            {
                return HttpNotFound();
            }
            return View(nucleoFamiliare);
        }

        // POST: CentroAscolto/NucleiFamiliari/Edit/5
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Residenza,Annotazioni,CodiceIdentificativo,DichiarazioneIsee,CreataIl,CreataDa,AggiornataIl,AggiornataDa")] NucleoFamiliare nucleoFamiliare)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nucleoFamiliare).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nucleoFamiliare);
        }

        // GET: CentroAscolto/NucleiFamiliari/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NucleoFamiliare nucleoFamiliare = db.NucleiFamiliari.Find(id);
            if (nucleoFamiliare == null)
            {
                return HttpNotFound();
            }
            return View(nucleoFamiliare);
        }

        // POST: CentroAscolto/NucleiFamiliari/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            NucleoFamiliare nucleoFamiliare = db.NucleiFamiliari.Find(id);
            db.NucleiFamiliari.Remove(nucleoFamiliare);
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
