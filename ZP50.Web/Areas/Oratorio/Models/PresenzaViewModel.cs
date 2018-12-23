using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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


}