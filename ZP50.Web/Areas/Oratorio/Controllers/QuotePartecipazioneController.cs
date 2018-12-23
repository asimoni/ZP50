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
    public class QuotePartecipazioneController : Controller
    {
        private OratorioContext db = new OratorioContext();

        // GET: Oratorio/QuotePartecipazione
        public ActionResult Index()
        {
            return View(db.QuotePartecipazione.ToList());
        }

        // GET: Oratorio/QuotePartecipazione/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuotaPartecipazione quotaPartecipazione = db.QuotePartecipazione.Find(id);
            if (quotaPartecipazione == null)
            {
                return HttpNotFound();
            }
            return View(quotaPartecipazione);
        }

        // GET: Oratorio/QuotePartecipazione/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Oratorio/QuotePartecipazione/Create
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Descrizione,Costo")] QuotaPartecipazione quotaPartecipazione)
        {
            if (ModelState.IsValid)
            {
                db.QuotePartecipazione.Add(quotaPartecipazione);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(quotaPartecipazione);
        }

        // GET: Oratorio/QuotePartecipazione/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuotaPartecipazione quotaPartecipazione = db.QuotePartecipazione.Find(id);
            if (quotaPartecipazione == null)
            {
                return HttpNotFound();
            }
            return View(quotaPartecipazione);
        }

        // POST: Oratorio/QuotePartecipazione/Edit/5
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Descrizione,Costo")] QuotaPartecipazione quotaPartecipazione)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quotaPartecipazione).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(quotaPartecipazione);
        }

        // GET: Oratorio/QuotePartecipazione/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuotaPartecipazione quotaPartecipazione = db.QuotePartecipazione.Find(id);
            if (quotaPartecipazione == null)
            {
                return HttpNotFound();
            }
            return View(quotaPartecipazione);
        }

        // POST: Oratorio/QuotePartecipazione/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuotaPartecipazione quotaPartecipazione = db.QuotePartecipazione.Find(id);
            db.QuotePartecipazione.Remove(quotaPartecipazione);
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
