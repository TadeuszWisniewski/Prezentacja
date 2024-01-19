using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TDAUTadeuszWisniewskiProjekt.Models.Entities;

[Table("PozycjaFaktury")]
public partial class PozycjaFaktury
{
    [Key]
    public int Id { get; set; }

    public int? IdTowar { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? Ilosc { get; set; }

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

    [ForeignKey("IdTowar")]
    [InverseProperty("PozycjaFakturies")]
    public virtual Towar? IdTowarNavigation { get; set; }
}
