using System;

namespace ZP50.Core.CentroAscolto
{
    public class SchedaIncontro
    {
        public Guid ID { get; set; }
        public Guid NucleoFamiliareID { get; set; }
        public string Sintesi { get; set; }
        public DateTime CreataIl { get; set; }
        public DateTime CreataDa { get; set; }
    }

}
