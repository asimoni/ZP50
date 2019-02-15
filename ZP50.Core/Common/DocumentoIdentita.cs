using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZP50.Core.Common
{
    public enum DocumentoIdentitaType
    {
        Nessuno=0,
        [Display(Name ="Carta d'identità")]
        CartaIdentita=1,
        [Display(Name = "Passaporto")]
        Passaporto = 2,
        [Display(Name = "Permesso di soggiorno")]
        PermessoSoggiorno = 3,
        [Display(Name = "Patente di guida")]
        PatenteGuida = 4

    }
    public class DocumentoIdentita
    {
        public DocumentoIdentitaType Tipo { get; set; }
        public string Identificativo { get; set; }
        [Display(Name = "Rilasciato da")]
        public string RilaciatoDa { get; set; }
        public string Comune { get; set; }
        [Display(Name ="Data scadenza")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]

        public DateTime? DataScadenza { get; set; }
    }
}
