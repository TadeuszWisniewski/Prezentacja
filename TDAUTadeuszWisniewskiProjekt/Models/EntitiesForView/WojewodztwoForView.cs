using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDAUTadeuszWisniewskiProjekt.Models.EntitiesForView
{
    public class WojewodztwoForView
    {
        #region Dane
        public int Id { get; set; }//

        public string? Nazwa { get; set; }//
        public string? Opis { get; set; }//
        public DateTime? DataUtworzenia { get; set; }//
        public DateTime? DataModyfikacji { get; set; }//
        public bool? Aktywny { get; set; }//
        public DateTime? KiedyUtworzone { get; set; }
        public string? KtoUtworzyl { get; set; }
        public DateTime? KiedyZmieniono { get; set; }
        public string? KtoZmienil { get; set; }
        public DateTime? KiedyDezaktywowano { get; set; }
        public string? KtoDezaktywowal { get; set; }

        #endregion
    }
}
