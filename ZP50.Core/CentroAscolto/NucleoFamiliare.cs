using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZP50.Core.Common;

namespace ZP50.Core.CentroAscolto
{
    public class NucleoFamiliare
    {
        public Guid ID { get; set; }
        public string Nome { get; set; }
        public Indirizzo Residenza { get; set; }

        [DataType(DataType.MultilineText)]
        public string Annotazioni { get; set; }

        [Display(Name = "Codice ID")]
        public string CodiceIdentificativo { get; set; }
        [Display(Name = "Dichiarazione ISEE")]
        public DichiarazioneIsee DichiarazioneIsee { get; set; }
        [Display(Name = "Assistente sociale")]
        public string AssistenteSociale { get; set; }


        public virtual ICollection<Persona> Membri { get; set; }
        public virtual ICollection<SchedaIncontro> Schede { get; set; }
        public virtual ICollection<Richiesta> Richieste { get; set; }

        [Display(Name = "Creazione")]
        public DateTime CreataIl { get; set; }
        [Display(Name = "Creata da")]
        public string CreataDa { get; set; }
        [Display(Name = "Aggiornamento")]
        public DateTime AggiornataIl { get; set; }
        [Display(Name = "Aggiornata da")]
        public string AggiornataDa { get; set; }
    }

}
