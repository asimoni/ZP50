using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZP50.Web.Areas.Oratorio.Models
{
    public class PartecipanteAssociaCodiceModel
    {
        [Required]
        public int PartecipanteId { get; set; }
        [Required]
        public string CodiceIdentificativo { get; set; }
    }
}