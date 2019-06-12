using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZP50.Core.DataLayer;

namespace ZP50.Web.Areas.Oratorio.Models
{

    public static class ValueBundle
    {
        public static IEnumerable<SelectListItem> ClassiScolastiche
        {
            get
            {
                return new SelectListItem[]{
                    new SelectListItem{Text="", Value=""},
                    new SelectListItem{Text="1 elementare", Value="1 elementare"},
                    new SelectListItem{Text="2 elementare", Value="2 elementare"},
                    new SelectListItem{Text="3 elementare", Value="3 elementare"},
                    new SelectListItem{Text="4 elementare", Value="4 elementare"},
                    new SelectListItem{Text="5 elementare", Value="5 elementare"},
                    new SelectListItem{Text="1 media", Value="1 media"},
                    new SelectListItem{Text="2 media", Value="2 media"},
                    new SelectListItem{Text="3 media", Value="3 media"},
                };

            }
        }
        public static IEnumerable<SelectListItem> PresenzaStato
        {
            get
            {
                return new SelectListItem[]{
                    new SelectListItem{Text="", Value=""},
                    new SelectListItem{Text="Presente", Value="Presente"},
                    new SelectListItem{Text="Uscito", Value="Uscito"}
                };
            }
        }
        public static IEnumerable<SelectListItem> Quote
        {
            get
            {
                ApplicationContext db = new ApplicationContext();
                return db.QuotePartecipazione
                    .Select(x => new SelectListItem { Text = x.Descrizione, Value = x.Descrizione })
                    .Distinct()
                    .OrderBy(x => x.Text)
                    .ToArray();
    }
            
        }
    }

}