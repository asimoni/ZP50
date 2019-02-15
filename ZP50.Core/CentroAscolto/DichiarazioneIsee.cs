using System;
using System.ComponentModel.DataAnnotations;

namespace ZP50.Core.CentroAscolto
{
    public class DichiarazioneIsee
    {
        [Display(Name = "Valore indicatore")]
        [DataType(DataType.Currency)]
        public double ValoreIndicatore { get; set; }
        [Display(Name = "Data scadenza")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DataScadenza { get; set; }
        public bool IsScaduta()
        {
            return DataScadenza < DateTime.Today;
        }
    }

}
