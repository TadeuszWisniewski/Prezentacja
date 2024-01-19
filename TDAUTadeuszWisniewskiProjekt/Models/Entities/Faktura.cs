using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TDAUTadeuszWisniewskiProjekt.Models.Entities;

[Table("Faktura")]
public partial class Faktura
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string? Numer { get; set; }

    public bool? Dostawa { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? KosztDostawy { get; set; }

    public int? IdKontrahenta { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? Wartosc { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? Rabat { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? WartoscPoRabacie { get; set; }

    public bool? Zaplacone { get; set; }

    public bool? Aktywny { get; set; }

    public string? Opis { get; set; }

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

    [ForeignKey("IdKontrahenta")]
    [InverseProperty("Fakturas")]
    public virtual Kontrahent? IdKontrahentaNavigation { get; set; }
}
