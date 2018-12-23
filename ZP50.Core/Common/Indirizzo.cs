using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZP50.Core.Common
{
    public class Indirizzo
    {
        public string Via { get; set; }
        public string Civico { get; set; }
        public string Comune { get; set; }
        [StringLength(5)]
        public string Cap { get; set; }
        public string Provincia { get; set; }
    }
}
