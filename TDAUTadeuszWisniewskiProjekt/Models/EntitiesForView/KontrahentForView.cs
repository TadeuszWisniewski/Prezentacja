using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDAUTadeuszWisniewskiProjekt.Models.EntitiesForView
{
    public class KontrahentForView
    {
        public int Id { get; set; }

        public string? Kod { get; set; }

        public string? Bazwa { get; set; }

        public string? Nip { get; set; }

        public bool? PodatnikVat { get; set; }

        public int? IdRodzajVatSprzedazy { get; set; }
        public string? RodzajVatSprzedazyNazwa { get; set; }

        public int? IdRodzajVatZakupu { get; set; }
        public string? RodzajVatZakupuNazwa { get; set; }

        public int? IdStatusWbazieMf { get; set; }
        public string? StatusWbazieMfNazwa { get; set; }

        public int? IdStatusWbazieVies { get; set; }
        public string? StatusWbazieViesNazwa { get; set; }

        public int? IdStatus { get; set; }
        public string? StatusNazwa { get; set; }

        public int? IdFormaPrawna { get; set; }
        public string? FormaPrawnaNazwa { get; set; }

        public string? VatLiczonyOd { get; set; }

        public int? IdAdresu { get; set; }

        public string? Pesel { get; set; }

        public string? Krs { get; set; }

        public string? StronaWww { get; set; }

        public string? Regon { get; set; }

        public string? GlnIln { get; set; }

        public int? IdDefinicjaPlatnosci { get; set; }
        public string? DefinicjaPlatnosciNazwa { get; set; }

        public bool? BlokadaSprzedazy { get; set; }

        public decimal? LimitKredytu { get; set; }

        public int? Termin { get; set; }

        public int? IdWaluta { get; set; }
        public string? WalutaNazwa {  get; set; }

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
