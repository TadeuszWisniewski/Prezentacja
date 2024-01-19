using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TDAUTadeuszWisniewskiProjekt.Models.Entities;

public partial class AdresZameldowanium
{
    [Key]
    public int Id { get; set; }

    public int? IdKraju { get; set; }

    public int? IdWojewodztwa { get; set; }

    public int? IdMiejscowosc { get; set; }

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

    [StringLength(50)]
    public string? Telefon { get; set; }

    [Column("TelefonSMS")]
    [StringLength(50)]
    public string? TelefonSms { get; set; }

    [Column("E-mail")]
    [StringLength(50)]
    public string? EMail { get; set; }

    public bool? Aktywny { get; set; }

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

    [ForeignKey("IdKraju")]
    [InverseProperty("AdresZameldowania")]
    public virtual Kraj? IdKrajuNavigation { get; set; }

    [ForeignKey("IdMiejscowosc")]
    [InverseProperty("AdresZameldowania")]
    public virtual Miejscowosc? IdMiejscowoscNavigation { get; set; }

    [ForeignKey("IdWojewodztwa")]
    [InverseProperty("AdresZameldowania")]
    public virtual Wojewodztwo? IdWojewodztwaNavigation { get; set; }

    [InverseProperty("IdAdresuDoKorespondencjiNavigation")]
    public virtual ICollection<Kontrahent> KontrahentIdAdresuDoKorespondencjiNavigations { get; set; } = new List<Kontrahent>();

    [InverseProperty("IdAdresuZameldowaniaNavigation")]
    public virtual ICollection<Kontrahent> KontrahentIdAdresuZameldowaniaNavigations { get; set; } = new List<Kontrahent>();

    [InverseProperty("IdAdresuKorespondencjiNavigation")]
    public virtual ICollection<Pracownik> PracownikIdAdresuKorespondencjiNavigations { get; set; } = new List<Pracownik>();

    [InverseProperty("IdAdresuZamieszkaniaNavigation")]
    public virtual ICollection<Pracownik> PracownikIdAdresuZamieszkaniaNavigations { get; set; } = new List<Pracownik>();
}
