using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TDAUTadeuszWisniewskiProjekt.Models.Entities;

[Table("Cena")]
public partial class Cena
{
    [Key]
    public int Id { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? Wartosc { get; set; }

    [StringLength(50)]
    public string? Opis { get; set; }

    public bool? Aktywny { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? KiedyUtworzono { get; set; }

    [StringLength(50)]
    public string? KtoUtworzyl { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? KiedyZmieniono { get; set; }

    [StringLength(50)]
    public string? KtoZmienil { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? KiedyDezaktywowano { get; set; }

    [StringLength(50)]
    public string? KtoDezaktywowal { get; set; }

    [InverseProperty("IdCenaWyprzedazyNavigation")]
    public virtual ICollection<Towar> TowarIdCenaWyprzedazyNavigations { get; set; } = new List<Towar>();

    [InverseProperty("IdCenyNavigation")]
    public virtual ICollection<Towar> TowarIdCenyNavigations { get; set; } = new List<Towar>();
}
