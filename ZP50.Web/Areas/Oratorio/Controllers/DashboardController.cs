using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZP50.Core.DataLayer;
using ZP50.Web.Areas.Oratorio.Models;

namespace ZP50.Web.Areas.Oratorio.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationContext db = new ApplicationContext();
        // GET: Oratorio/Dashboard
        public ActionResult Index()
        {
            var items = db.QuoteAcquistate.AsQueryable();
            var summary = from r in items
                          orderby r.QuotaPartecipazione.Descrizione
                          group r by r.QuotaPartecipazione.Descrizione into grp
                          select new SummaryItem { Key = grp.Key, Qty = grp.Count() }; ;
            return View(summary);
        }
    }
}