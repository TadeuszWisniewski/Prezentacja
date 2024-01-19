using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TDAUTadeuszWisniewskiProjekt.Models.Entities;

[Table("RodzajVAT")]
public partial class RodzajVat
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string? Nazwa { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? Wysokosc { get; set; }

    public bool? Aktywny { get; set; }

    [StringLength(50)]
    public string? Opis { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? KiedyUtworzone { get; set; }

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

    [InverseProperty("IdStawkiVatsprzedazyNavigation")]
    public virtual ICollection<Towar> TowarIdStawkiVatsprzedazyNavigations { get; set; } = new List<Towar>();

    [InverseProperty("IdStawkiVatzakupuNavigation")]
    public virtual ICollection<Towar> TowarIdStawkiVatzakupuNavigations { get; set; } = new List<Towar>();
}
