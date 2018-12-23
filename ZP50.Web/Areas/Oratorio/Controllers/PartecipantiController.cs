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
using ZP50.Web.Areas.Oratorio.Models;

namespace ZP50.Web.Areas.Oratorio.Controllers
{
    public class PartecipantiController : Controller
    {
        private OratorioContext db = new OratorioContext();

        // GET: Oratorio/Partecipanti
        public ActionResult Index()
        {
            return View(db.Partecipanti.ToList());
        }

        // GET: Oratorio/Partecipanti/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partecipante partecipante = db.Partecipanti.Find(id);
            if (partecipante == null)
            {
                return HttpNotFound();
            }
            return View(partecipante);
        }

        // GET: Oratorio/Partecipanti/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Oratorio/Partecipanti/Create
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,Cognome,DataNascita,Indirizzo,Annotazioni")] Partecipante partecipante)
        {
            if (ModelState.IsValid)
            {
                db.Partecipanti.Add(partecipante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(partecipante);
        }

        // GET: Oratorio/Partecipanti/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partecipante partecipante = db.Partecipanti
                .Include(p => p.QuoteAcquistate)
                .Include(p => p.Recapiti)
                .First(x => x.ID == id);
            if (partecipante == null)
            {
                return HttpNotFound();
            }
            return View(partecipante);
        }

        // POST: Oratorio/Partecipanti/Edit/5
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Cognome,DataNascita,Indirizzo,Annotazioni, CodiceIdentificativo, QuoteAcquistate, Recapiti")] Partecipante partecipante)
        {
            if (ModelState.IsValid)
            {
                db.Partecipanti.Attach(partecipante);

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(partecipante);
        }

    //    private void Update(Partecipante model) { 
    //        var existingParent = db.Partecipanti
    //    .Where(p => p.ID == model.ID)
    //    .Include(p => p.QuoteAcquistate)
    //    .SingleOrDefault();

    //if (existingParent != null)
    //{
    //    // Update parent
    //    db.Entry(existingParent).CurrentValues.SetValues(model);

    //    // Delete children
    //    foreach (var existingChild in existingParent.Children.ToList())
    //    {
    //        if (!model.Children.Any(c => c.Id == existingChild.Id))
    //            _dbContext.Children.Remove(existingChild);
    //    }

    //    // Update and Insert children
    //    foreach (var childModel in model.Children)
    //    {
    //        var existingChild = existingParent.Children
    //            .Where(c => c.Id == childModel.Id)
    //            .SingleOrDefault();

    //        if (existingChild != null)
    //            // Update child
    //            _dbContext.Entry(existingChild).CurrentValues.SetValues(childModel);
    //        else
    //        {
    //            // Insert child
    //            var newChild = new Child
    //            {
    //                Data = childModel.Data,
    //                //...
    //            };
    //existingParent.Children.Add(newChild);
    //        }
    //    }

    //    _dbContext.SaveChanges();
    //}

        // GET: Oratorio/Partecipanti/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partecipante partecipante = db.Partecipanti.Find(id);
            if (partecipante == null)
            {
                return HttpNotFound();
            }
            return View(partecipante);
        }

        // POST: Oratorio/Partecipanti/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Partecipante partecipante = db.Partecipanti.Find(id);
            db.Partecipanti.Remove(partecipante);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult AssociaCodice(int id)
        {
            return View(new PartecipanteAssociaCodiceModel { PartecipanteId=id });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AssociaCodice(PartecipanteAssociaCodiceModel model)
        {
            if (ModelState.IsValid)
            {
                var partecipante = db.Partecipanti.FirstOrDefault(x => x.CodiceIdentificativo == model.CodiceIdentificativo);
                // se esiste già un partecipante associato a questo codice
                if (partecipante != null)
                {
                    if (partecipante.ID == model.PartecipanteId)
                    {
                        ModelState.AddModelError("CodiceIdentificativo", "Codice già associato a questo partecipante");
                    }
                    else
                    {
                        ModelState.AddModelError("CodiceIdentificativo", "Codice già associato ad un altro partecipante");
                    }
                }
                else
                {
                    partecipante = db.Partecipanti.FirstOrDefault(x => x.ID == model.PartecipanteId);
                    partecipante.CodiceIdentificativo = model.CodiceIdentificativo;
                    db.SaveChanges();
                    return RedirectToAction("Edit", new { id = model.PartecipanteId });
                }

            }

            return View(model);

        }

        public ActionResult AggiungiQuota(int id, int partecipanteId)
        {
            var quota = db.QuotePartecipazione.FirstOrDefault(x => x.ID == id);
            var model = new QuotaAcquistata {
                QuotaPartecipazioneID = quota.ID,
                PartecipanteID=partecipanteId,
                QuotaPartecipazione = quota };
            return PartialView("_QuotaAcquistata", model);
        }

        public ActionResult AggiungiRecapito(int partecipanteID)
        {
            var model = new Recapito
            {
                PartecipanteID=partecipanteID
            };
            db.Recapiti.Add(model);
            db.SaveChanges();
            return PartialView("_Recapito", model);
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
