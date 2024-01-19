using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDAUTadeuszWisniewskiProjekt.Models.EntitiesForView
{
    //Ta klasa jest po to, żeby zamiast kluczy obcych z tabeli faktura wyświetlac konkretne dane z tabel powiązanych
    public class AdresDoKorespondencjiForView
    {
        #region Dane
        public int Id { get; set; }
        public int? IdKraju { get; set; }
        public string? NazwaKraju { get; set; }
        public string? NazwaPowiatu { get; set; }
        public string? Ulica { get; set; }
        public int? IdMiejscowosc { get; set; }
        public string? NazwaMiejscowosci { get; set; }
        public string? Telefon { get; set; }
        public string? Email { get; set; }
        public int? IdWojewodztwa { get; set; }
        public string? NazwaWojewodztwa { get; set; }
        public string? KodGminy { get; set; }
        public string? NumerDomu { get; set; }
        public string? NumerLokalu { get; set; }
        public string? KodPocztowy { get; set; }
        public string? TelefonSMS { get; set; }
        public bool? Aktywny { get; set; }
        public string? Opis { get; set; }
        public DateTime? KiedyUtworzone { get; set; }
        public string? KtoUtworzyl { get; set; }
        public DateTime? KiedyZmieniono { get; set; }
        public string? KtoZmienil { get; set; }
        public DateTime? KiedyDezaktywowano { get; set; }
        public string? KtoDezaktywowal { get; set; }
        #endregion
    }
}
