﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDAUTadeuszWisniewskiProjekt.Models.EntitiesForView
{
    public class TypStawkiForView
    {
        public int Id { get; set; }
        public string? Nazwa { get; set; }
        public string? Opis { get; set; }
        public bool? Aktywny { get; set; }
        public DateTime? KiedyUtworzono { get; set; }
        public string? KtoUtworzyl { get; set; }
        public DateTime? KiedyZmodyfikowal { get; set; }
        public string? KtoZmodyfikowal { get; set; }
        public DateTime? KiedyDezaktywowano { get; set; }
        public string? KtoDezaktywowal { get; set; }
    }
}
