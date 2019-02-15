using System;
using System.ComponentModel.DataAnnotations;

namespace ZP50.Core.CentroAscolto
{
    public class InfoOccupazione
    {
        public InfoOccupazione()
        {
            UltimoAggiornamento = DateTime.Now;
        }
        public string Occupazione { get; set; }
        [Display(Name = "Stipendio mensile")]
        public int StipendioMensile { get; set; }
        public string Azienda { get; set; }
        [DataType(DataType.MultilineText)]
        public string Note { get; set; }
        public DateTime UltimoAggiornamento { get; set; }

        public static InfoOccupazione Disoccupato()
        {
            return new InfoOccupazione
            {
                Occupazione = "Disoccupato",
                StipendioMensile = 0,
                Azienda = string.Empty
            };
        }
    }

}
