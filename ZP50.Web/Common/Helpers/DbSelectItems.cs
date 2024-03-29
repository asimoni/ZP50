﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZP50.Core.DataLayer;

namespace ZP50.Web.Common.Helpers
{
    public static class DbSelectItems
    {
        private static ApplicationContext db;

        public static List<SelectListItem> QuotePartecipazione()
        {
            db = new ApplicationContext();
            return db.QuotePartecipazione.Select(x => new SelectListItem { Text=x.Descrizione, Value=x.ID.ToString()}).ToList();
        }

    }
}