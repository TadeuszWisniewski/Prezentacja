using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDAUTadeuszWisniewskiProjekt.Models.EntitiesForView
{
    public class FakturaForView
    {
        #region Dane
        public int Id { get; set; }

        public string? Numer { get; set; }

        public bool? Dostawa { get; set; }

        public decimal? KosztDostawy { get; set; }

        public int? IdKontrahenta { get; set; }
        public string? NazwaKontrahenta { get; set; }

        public string? PozycjeFaktury { get; set; }

        public decimal? Wartosc { get; set; }

        public decimal? Rabat { get; set; }

        public decimal? WartoscPoRabacie { get; set; }

        public bool? Zaplacone { get; set; }

        public bool? Aktywny { get; set; }

        public string? Opis { get; set; }

        public DateTime? KiedyUtworzono { get; set; }

        public string? KtoUtworzyl { get; set; }

        public DateTime? KiedyZmieniono { get; set; }

        public string? KtoZmienil { get; set; }

        public DateTime? KiedyDezaktywowano { get; set; }

        public string? KtoDezaktywowal { get; set; }
        #endregion
    }
}
