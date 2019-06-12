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
    public class PartecipantiController : BaseController
    {
        private ApplicationContext db = new ApplicationContext();

        // GET: Oratorio/Partecipanti
        public ActionResult Index(PartecipanteFilterModel filter)
        {
            var items = db.Partecipanti.AsQueryable();
            items = filter.Apply(items);
            return View(new PartecipanteQueryResultModel
            {
                Items = items.ToList(),
                Filter = filter
            });

        }

        public ActionResult Printable(PartecipanteFilterModel filter)
        {
            var items = db.Partecipanti.AsQueryable();
            items = filter.Apply(items);
            return View(new PartecipanteQueryResultModel
            {
                Items = items.ToList(),
                Filter = filter
            });

        }

        [ChildActionOnly]
        public ActionResult SummaryByQuote()
        {
            var items = db.QuoteAcquistate.AsQueryable();
            var summary = from r in items
                     orderby r.QuotaPartecipazione.Descrizione
                     group r by r.QuotaPartecipazione.Descrizione into grp
                     select new SummaryItem { Key = grp.Key, Qty = grp.Count() }; ;
            return PartialView("_SummaryByQuote", summary);
        }
        // GET: Oratorio/Partecipanti/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partecipante partecipante = db.Partecipanti
                .Include(p => p.QuoteAcquistate)
                .Include(p => p.Contatti)
                .First(x => x.ID == id);
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
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,Cognome,DataNascita,ClasseFrequentata,Indirizzo,Annotazioni")] Partecipante partecipante)
        {
            if (ModelState.IsValid)
            {
                if(db.Partecipanti.Any(x=> x.Cognome==partecipante.Cognome && x.Nome==partecipante.Nome && x.DataNascita == partecipante.DataNascita)){
                    ModelState.AddModelError("", "Esiste già un partecipante con questi dati");
                    return View(partecipante);
                }

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
                .Include(p => p.Contatti)
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
        public ActionResult Edit([Bind(Include = "ID,Nome,Cognome,DataNascita,ClasseFrequentata,Indirizzo,Annotazioni, CodiceIdentificativo, QuoteAcquistate, Recapiti")] Partecipante partecipante)
        {
            if (ModelState.IsValid)
            {

                db.Entry(db.Partecipanti
                  .First(x => x.ID == partecipante.ID))
                  .CurrentValues.SetValues(partecipante);
                //db.Partecipanti.Attach(partecipante);

                db.SaveChanges();
                //return RedirectToAction("Index");
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
            return View(new PartecipanteAssociaCodiceModel { PartecipanteId = id });
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

        #region Quote

        public ActionResult Quote(int id)
        {
            Partecipante partecipante = db.Partecipanti.Include("QuoteAcquistate").Single(x => x.ID == id);
            var model = partecipante.QuoteAcquistate;
            return View(partecipante);
        }

        public ActionResult AggiungiQuota(int partecipanteID)
        {
            var partecipante = db.Partecipanti.Include("QuoteAcquistate").Single(x => x.ID == partecipanteID);
            var quote = db.QuotePartecipazione.ToList();
            var quoteAcquistate = partecipante.QuoteAcquistate.Select(x => x.QuotaPartecipazione).ToArray();
            var model = new PartecipanteAggiungiQuotaModel
            {
                PartecipanteID = partecipanteID,
                QuoteDaAcquistare = quote.Except(quoteAcquistate).Select(x => new QuotaDaAcquistareModel
                {
                    Categoria = x.Categoria,
                    Descrizione = x.Descrizione,
                    Costo = x.Costo,
                    ID = x.ID
                }).ToArray()
            };
            return View(model);
        }

        public ActionResult AggiornaQuota(int partecipanteID, int quotaID)
        {
            var quota = db.QuoteAcquistate.First(x => x.PartecipanteID == partecipanteID && x.QuotaPartecipazioneID == quotaID);

            return View(quota);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AggiornaQuota(QuotaAcquistata model)
        {
            if (ModelState.IsValid)
            {
                var quota = db.QuoteAcquistate.First(x => x.PartecipanteID == model.PartecipanteID && x.QuotaPartecipazioneID == model.QuotaPartecipazioneID);
                quota.Versato = model.Versato;
                db.SaveChanges();
            }
            return RedirectToAction("Quote", new { id = model.PartecipanteID });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AggiungiQuota(PartecipanteAggiungiQuotaModel model)
        {
            var partecipante = db.Partecipanti.Find(model.PartecipanteID);
            foreach (var item in model.QuoteDaAcquistare.Where(x => x.Aggiungi))
            {
                var quota = new QuotaAcquistata
                {
                    QuotaPartecipazioneID = item.ID,
                    PartecipanteID = partecipante.ID,
                };
                partecipante.QuoteAcquistate.Add(quota);
            }
            db.SaveChanges();
            return RedirectToAction("Quote", new { id = partecipante.ID });
        }

        public ActionResult RimuoviQuota(int quotaID, int partecipanteID)
        {

            var partecipante = db.Partecipanti.Find(partecipanteID);
            var quota = partecipante.QuoteAcquistate.Single(x => x.QuotaPartecipazioneID == quotaID);

            partecipante.QuoteAcquistate.Remove(quota);
            db.SaveChanges();
            return RedirectToAction("Quote", new { id = partecipanteID });
        }

        #endregion


        #region Contatti
        public ActionResult Contatti(int id)
        {
            Partecipante partecipante = db.Partecipanti.Include("Contatti").Single(x => x.ID == id);
            var model = partecipante.Contatti;
            return View(partecipante);
        }

        public ActionResult SuggerisciContatti(int partecipanteID, string nome, string cognome)
        {
            var model = new PartecipanteSuggerimentoContattiModel
            {
                PartecipanteID = partecipanteID,
                Contatti = db.Contatti.Where(x => x.Nome.StartsWith(nome) && x.Cognome.StartsWith(cognome)).ToList()

            };

            return PartialView("_SuggerisciContatti", model);
        }

        public ActionResult AggiungiContatto(int partecipanteID)
        {
            return View(new PartecipanteAggiungiContattoModel { PartecipanteID = partecipanteID });
        }

        public ActionResult RimuoviContatto(int partecipanteID, int contattoID)
        {
            var partecipante = db.Partecipanti.Find(partecipanteID);
            var contatto = partecipante.Contatti.Single(x => x.ID == contattoID);
            partecipante.Contatti.Remove(contatto);
            db.SaveChanges();
            return RedirectToAction("Contatti", new { id = partecipanteID });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AggiungiContatto(PartecipanteAggiungiContattoModel model)
        {
            if (ModelState.IsValid)
            {
                var partecipante = db.Partecipanti.Find(model.PartecipanteID);
                var contatto = new Contatto
                {
                    Cognome = model.Cognome,
                    Nome = model.Nome,
                    Telefono = model.Telefono,
                    Email = model.Email
                };
                partecipante.Contatti.Add(contatto);
                db.Contatti.Add(contatto);
                db.SaveChanges();
                contatto.Partecipanti.Add(partecipante);
                db.SaveChanges();
                return RedirectToAction("Contatti", new { id = model.PartecipanteID });

            }

            return View(model);

        }

        public ActionResult AggiungiContattoSuggerito(int partecipanteID, int contattoID)
        {
            var partecipante = db.Partecipanti.Find(partecipanteID);
            var contatto = db.Contatti.Find(contattoID);
            partecipante.Contatti.Add(contatto);
            db.SaveChanges();
            return RedirectToAction("Contatti", new { id = partecipanteID });

        }

        #endregion

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
