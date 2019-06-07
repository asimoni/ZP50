using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZP50.Core.DataLayer;
using ZP50.Web.Areas.Oratorio.Models;

namespace ZP50.Web.Areas.Oratorio.Controllers
{
    public class PresenzeController : BaseController
    {
        private ApplicationContext db = new ApplicationContext();

        // GET: Oratorio/Presenze
        public ActionResult Index()
        {
            var model = db.Presenze.Where(x => x.Giorno == DateTime.Today).ToList();
            return View(model);
        }

        public ActionResult Ingresso()
        {
            return View(new RegistraPresenzaModel());
        }
        [HttpPost]
        public ActionResult Ingresso(RegistraPresenzaModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var partecipante = db.Partecipanti.FirstOrDefault(x => x.CodiceIdentificativo == model.CodiceIdentificativo);
            if (partecipante == null)
            {
                ModelState.AddModelError("CodiceIdentificativo", "Il codice non è associato a nessun partecipante");
                return View(new RegistraPresenzaModel());
            }

            var presente = db.Presenze.Any(x => x.PartecipanteID == partecipante.ID && x.Giorno == DateTime.Today && !x.Uscita.HasValue);
            if (presente)
            {
                ModelState.AddModelError("", $"{partecipante.Cognome} {partecipante.Nome} risulta già presente");
                return View(new RegistraPresenzaModel());
            }

            ViewBag.Partecipante = partecipante;
            db.Presenze.Add(new Core.Oratorio.Presenza
            {
                PartecipanteID = partecipante.ID,
                Giorno = DateTime.Today,
                Ingresso = DateTime.Now
            });
            db.SaveChanges();
            return View(new RegistraPresenzaModel());

            //return RedirectToAction("Index");

        }

        public ActionResult Uscita()
        {
            return View(new RegistraPresenzaModel());
        }
        [HttpPost]
        public ActionResult Uscita(RegistraPresenzaModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var partecipante = db.Partecipanti.FirstOrDefault(x => x.CodiceIdentificativo == model.CodiceIdentificativo);
            if (partecipante == null)
            {
                ModelState.AddModelError("CodiceIdentificativo", "Il codice non è associato a nessun partecipante");
                return View(new RegistraPresenzaModel());
            }

            var presente = db.Presenze.FirstOrDefault(x => x.PartecipanteID == partecipante.ID && x.Giorno == DateTime.Today && !x.Uscita.HasValue);
            if (presente == null)
            {
                ModelState.AddModelError("", $"{partecipante.Cognome} {partecipante.Nome} non risulta presente");
                return View(new RegistraPresenzaModel());
            }

            ViewBag.Partecipante = partecipante;

            presente.Uscita = DateTime.Now;
            db.SaveChanges();
            return View(new RegistraPresenzaModel());

            //return RedirectToAction("Index");

        }

    }
}