﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZP50.Core.Common;

namespace ZP50.Core.Oratorio
{
    public class Partecipante
    {
        public int ID { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Cognome { get; set; }
        [Required]
        public string DataNascita { get; set; }
        public Indirizzo Indirizzo { get; set; }

        [DataType(DataType.MultilineText)]
        public string Annotazioni { get; set; }

        public string CodiceIdentificativo { get; set; }
        public virtual ICollection<Recapito> Recapiti { get; set; }
        public virtual ICollection<QuotaAcquistata> QuoteAcquistate { get; set; }
    }


    public class QuotaAcquistata
    {
        [Key, Column(Order = 0)]
        public int QuotaPartecipazioneID { get; set; }
        [Key, Column(Order = 1)]
        public int PartecipanteID { get; set; }

        public virtual QuotaPartecipazione QuotaPartecipazione { get; set; }
        public virtual Partecipante Partecipante { get; set; }
        public double Versato { get; set; }
    }

    public class QuotaPartecipazione
    {
        public int ID { get; set; }
        [Required]
        public string Descrizione { get; set; }
        [DataType(DataType.Currency)]
        public double Costo { get; set; }
        public bool Vendibile { get; set; }
    }

    public class Recapito
    {
        public int ID { get; set; }
        public int PartecipanteID { get; set; }
        public string TipoRecapito { get; set; }
        public string Valore { get; set; }
        public string Note { get; set; }
    }

    public class Presenza
    {
        public int ID { get; set; }
        public int PartecipanteID { get; set; }
        public virtual Partecipante Partecipante { get; set; }
        public DateTime Giorno { get; set; }
        public DateTime Ingresso { get; set; }
        public DateTime? Uscita { get; set; }

    }




}
