using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TDAUTadeuszWisniewskiProjekt.Models.Entities;

[Table("AdresDoKorespondencji")]
public partial class AdresDoKorespondencji
{
    [Key]
    public int Id { get; set; }

    public int? IdKraju { get; set; }

    public int? IdWojewodztwo { get; set; }

    [StringLength(50)]
    public string? Powiat { get; set; }

    [StringLength(10)]
    public string? KodGminy { get; set; }

    [StringLength(50)]
    public string? Ulica { get; set; }

    [StringLength(10)]
    public string? NumerDomu { get; set; }

    [StringLength(10)]
    public string? NumerLokalu { get; set; }

    [StringLength(10)]
    public string? KodPocztowy { get; set; }

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

    [ForeignKey("IdKraju")]
    [InverseProperty("AdresDoKorespondencjis")]
    public virtual Kraj? IdKrajuNavigation { get; set; }

    [ForeignKey("IdWojewodztwo")]
    [InverseProperty("AdresDoKorespondencjis")]
    public virtual Wojewodztwo? IdWojewodztwoNavigation { get; set; }
}
