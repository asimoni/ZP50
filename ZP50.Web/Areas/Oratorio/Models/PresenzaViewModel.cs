using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZP50.Core.Oratorio;

namespace ZP50.Web.Areas.Oratorio.Models
{
    public class PresenzaViewModel
    {
        public int PartecipanteID { get; set; }
        public string Cognome { get; set; }
        public string Nome { get; set; }
    }

    public class RegistraPresenzaModel
    {
        public string CodiceIdentificativo { get; set; }
    }


    public class PresenzaFilterModel
    {
        public DateTime Giorno { get; set; } = DateTime.Today;
        public string Query { get; set; }
        public string Stato { get; set; }
        public string ClasseFrequentata { get; set; }
        public IQueryable<Presenza> Apply(IQueryable<Presenza> queryable)
        {
            queryable = queryable.Where(p => p.Giorno.Equals(DateTime.Today));
            if (!String.IsNullOrEmpty(Query))
            {
                queryable = queryable.Where(x => x.Partecipante.Nome.Contains(Query) || x.Partecipante.Cognome.Contains(Query));
            }
            if (!String.IsNullOrEmpty(Stato))
            {
                if (Stato == "Uscito")
                {
                    queryable = queryable.Where(p => p.Uscita.HasValue);
                }
                if (Stato == "Presente")
                {
                    queryable = queryable.Where(p => !p.Uscita.HasValue);
                }
            }
            if (!String.IsNullOrEmpty(ClasseFrequentata))
            {
                queryable = queryable.Where(p => p.Partecipante.ClasseFrequentata.Equals(ClasseFrequentata));
            }

            return queryable;
        }
    }

    public class PresenzaQueryResultModel
    {
        public PresenzaFilterModel Filter { get; set; }
        public IEnumerable<Presenza> Items { get; set; }
    }
}