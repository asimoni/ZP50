using System;
using System.ComponentModel.DataAnnotations;
using ZP50.Core.Common;

namespace ZP50.Core.CentroAscolto
{
    public enum SessoType
    {
        Maschio=1,
        Femmina=2
    }

    public class Persona
    {
        public Guid ID { get; set; }
        public Guid NucleoFamiliareID { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Cognome { get; set; }
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Immettere un numero di telefono valido")]
        public string Telefono { get; set; }
        [DataType(DataType.Date)]
        [Display(Name ="Data nascita")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? DataNascita { get; set; }

        [RegularExpression(@"1/^(?:(?:[B-DF-HJ-NP-TV-Z]|[AEIOU])[AEIOU][AEIOUX]|[B-DF-HJ-NP-TV-Z]{2}[A-Z]){2}[\dLMNP-V]{2}(?:[A-EHLMPR-T](?:[04LQ][1-9MNP-V]|[1256LMRS][\dLMNP-V])|[DHPS][37PT][0L]|[ACELMRT][37PT][01LM])(?:[A-MZ][1-9MNP-V][\dLMNP-V]{2}|[A-M][0L](?:[1-9MNP-V][\dLMNP-V]|[0L][1-9MNP-V]))[A-Z]$", ErrorMessage = "Immettere un codice fiscale valido")]
        public string CodiceFiscale { get; set; }
        [Display(Name = "Nazionalità")]
        public string Nazionalita { get; set; }
        public SessoType Sesso { get; set; }
        public DocumentoIdentita Documento { get; set; }
        public InfoOccupazione Occupazione { get; set; } = InfoOccupazione.Disoccupato();
    }


    public static class PersonaExtensionMethods
    {
        public static int? Age(this Persona persona)
        {
            if (!persona.DataNascita.HasValue) return null;
            var dataNascita = persona.DataNascita.Value;
            // Save today's date.
            var today = DateTime.Today;
            // Calculate the age.
            var age = today.Year - dataNascita.Year;
            // Go back to the year the person was born in case of a leap year
            if (dataNascita > today.AddYears(-age)) age--;
            return age;
        }
        public static string PrintableAge(this Persona persona)
        {

            return persona.Age()?.ToString() ?? "-";
        }
        public static string SexLetter(this Persona persona)
        {
            switch (persona.Sesso)
            {
                case SessoType.Femmina: return "F";
                case SessoType.Maschio: return "M";
            }
            return "-";
        }
    }
}
