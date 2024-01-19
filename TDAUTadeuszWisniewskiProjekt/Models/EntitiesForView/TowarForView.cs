using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDAUTadeuszWisniewskiProjekt.Models.EntitiesForView
{
    public class TowarForView
    {
        public int Id { get; set; }

        public int? IdCeny { get; set; }

        public int? IdCenaWyprzedazy { get; set; }

        public decimal? CenaKoncowa { get; set; }

        public string? Nazwa { get; set; }

        public int? IdStawkiVatzakupu { get; set; }

        public int? IdStawkiVatsprzedazy { get; set; }

        public decimal? WysokoscVAT { get; set; }

        public string? NumerKatalogowy { get; set; }

        public int? IdTypu { get; set; }

        public string? KodKreskowy { get; set; }

        public int? IdEanu { get; set; }

        public int? PkwiU { get; set; }

        public bool? Opakowanie { get; set; }

        public decimal? KosztOpakowania { get; set; }

        public int? IdJednostka { get; set; }

        public string? PodstawaZastosowaniaStawkiVat { get; set; }

        public bool? DoWyprzedazy { get; set; }

        public bool? Blokada { get; set; }

        public string? PowodBlokady { get; set; }

        public bool? UslugaPodnoszacaWartoscMagazynowa { get; set; }

        public decimal? WartoscUslugi { get; set; }

        public int? IdKodCpv { get; set; }

        public bool? DodatkowyKoszt { get; set; }

        public decimal? WartoscDodatkowegoKosztu { get; set; }

        public bool? Aktywny { get; set; }

        public string? Opis { get; set; }

        public DateTime? KiedyUtworzone { get; set; }

        public string? KtoUtworzyl { get; set; }

        public DateTime? KiedyZmieniono { get; set; }

        public string? KtoZmienil { get; set; }

        public DateTime? KiedyDezaktywowano { get; set; }

        public string? KtoDezaktywowal { get; set; }
    }
}
