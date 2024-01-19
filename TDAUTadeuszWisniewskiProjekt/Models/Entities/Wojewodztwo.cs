﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TDAUTadeuszWisniewskiProjekt.Models.Entities;

[Table("Wojewodztwo")]
public partial class Wojewodztwo
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string? Nazwa { get; set; }

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

    [InverseProperty("IdWojewodztwaNavigation")]
    public virtual ICollection<AdresZameldowanium> AdresZameldowania { get; set; } = new List<AdresZameldowanium>();
}