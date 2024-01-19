using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TDAUTadeuszWisniewskiProjekt.Models.Entities;

[Table("EANTyp")]
public partial class Eantyp
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string? Nazwa { get; set; }

    public int? IloscCyfr { get; set; }

    public bool? Aktywny { get; set; }

    [StringLength(50)]
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

    [InverseProperty("IdEanuNavigation")]
    public virtual ICollection<Towar> Towars { get; set; } = new List<Towar>();
}
