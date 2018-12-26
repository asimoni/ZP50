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
}