using System;

namespace ZP50.Core.CentroAscolto
{
    public class Richiesta
    {
        public Richiesta()
        {
            DataRichiesta = DateTime.Today;
        }
        public Guid ID { get; set; }
        public Guid NucleoFamiliareID { get; set; }

        public DateTime DataRichiesta { get; set; }
        public DateTime? DataEvasione { get; set; }
        public string Tipo { get; set; }
        public string Stato { get; set; }
        public string Descrizione { get; set; }
    }

}
