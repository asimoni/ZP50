using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ZP50.Core.Oratorio;

namespace ZP50.Web.Areas.Oratorio.Models
{
    public class PartecipanteAssociaCodiceModel
    {
        [Required]
        public int PartecipanteId { get; set; }
        [Required]
        public string CodiceIdentificativo { get; set; }
    }

    public class PartecipanteSuggerimentoContattiModel
    {
        public int PartecipanteID { get; set; }
        public IEnumerable<Contatto> Contatti { get; set; }
    }

    public class PartecipanteAggiungiContattoModel : Contatto
    {
        public int PartecipanteID { get; set; }
    }
    public class PartecipanteAggiungiQuotaModel
    {
        public int PartecipanteID { get; set; }
        public QuotaDaAcquistareModel[] QuoteDaAcquistare { get; set; }
    }
    public class PartecipanteAggiornaQuotaModel
    {
        public int PartecipanteID { get; set; }
        public QuotaAcquistata QuotaAcquistata { get; set; }
    }
    public class QuotaDaAcquistareModel: QuotaPartecipazione
    {
        public double Versato { get; set; }
        public bool Aggiungi { get; set; }
    }


    public class PartecipanteFilterModel
    {
        public string Query { get; set; }
        public string Quota { get; set; }
        public string ClasseFrequentata { get; set; }
        public IQueryable<Partecipante> Apply(IQueryable<Partecipante> queryable)
        {
            if (!String.IsNullOrEmpty(Query))
            {
                queryable = queryable.Where(x => x.Nome.Contains(Query) || x.Cognome.Contains(Query));
            }
            if (!String.IsNullOrEmpty(Quota))
            {
                queryable = queryable.Where(p => p.QuoteAcquistate.Any(c => c.QuotaPartecipazione.Descrizione.Equals(Quota)));
            }
            if (!String.IsNullOrEmpty(ClasseFrequentata))
            {
                queryable = queryable.Where(p => p.ClasseFrequentata.Equals(ClasseFrequentata));
            }

            return queryable;
        }
    }

    public class PartecipanteQueryResultModel
    {
        public PartecipanteFilterModel Filter { get; set; }
        public IEnumerable<Partecipante> Items { get; set; }
    }


    public class SummaryItem
    {
        public string Key { get; set; }
        public int Qty { get; set; }
    }
}