using System;
using System.ComponentModel.DataAnnotations;

namespace ZP50.Core.CentroAscolto
{
    public class SchedaIncontro
    {
        public Guid ID { get; set; }
        public Guid NucleoFamiliareID { get; set; }

        public virtual NucleoFamiliare NucleoFamiliare { get; set; }

        [DataType(DataType.MultilineText)]
        public string Sintesi { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data nascita")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime CreataIl { get; set; }
        public string CreataDa { get; set; }
    }

}
