using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDAUTadeuszWisniewskiProjekt.Models.EntitiesForView
{
    public class TypNIPForView
    {
        public int Id { get; set; }
        public int? IloscCyfr { get; set; }
        public string? Opis { get; set; }
        public bool? Aktywny { get; set; }
        public DateTime? KiedyUtworzone { get; set; }
        public string? KtoUtworzyl { get; set; }
        public DateTime? KiedyZmieniono { get; set; }
        public string? KtoZmienil { get; set; }
        public DateTime? KiedyDezaktywowano { get; set; }
        public string? KtoDezaktywowal { get; set; }
    }
}
