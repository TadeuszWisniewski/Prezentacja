using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TDAUTadeuszWisniewskiProjekt.Models.Entities;

[Table("TypNIP")]
public partial class TypNip
{
    [Key]
    public int Id { get; set; }

    public int? IloscCyfr { get; set; }

    public string? Opis { get; set; }

    public bool? Aktywny { get; set; }

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

    [InverseProperty("IdTypNipNavigation")]
    public virtual ICollection<Pracownik> Pracowniks { get; set; } = new List<Pracownik>();
}
