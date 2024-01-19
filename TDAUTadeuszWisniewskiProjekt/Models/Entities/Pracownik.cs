using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TDAUTadeuszWisniewskiProjekt.Models.Entities;

[Table("Pracownik")]
public partial class Pracownik
{
    [Key]
    public int Id { get; set; }

    public int? IdJednostkaOrganizacyjna { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DataZawarciaUmowy { get; set; }

    public int? IdPodstawyZatrudnienia { get; set; }

    [Column("IdTypUmowyOPrace")]
    public int? IdTypUmowyOprace { get; set; }

    public int? IdStanowisko { get; set; }

    public int? IdWymiaruEtatu { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? Stawka { get; set; }

    public int? IdTypStawki { get; set; }

    [StringLength(50)]
    public string? Akronim { get; set; }

    [StringLength(50)]
    public string? Imie { get; set; }

    [Column("PESEL")]
    [StringLength(50)]
    public string? Pesel { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DataUrodzenia { get; set; }

    [StringLength(50)]
    public string? ImieOjca { get; set; }

    [StringLength(50)]
    public string? NazwiskoRodowe { get; set; }

    [StringLength(50)]
    public string? Nazwisko { get; set; }

    [StringLength(50)]
    public string? DrugieImie { get; set; }

    [Column("IdTypNIP")]
    public int? IdTypNip { get; set; }

    [Column("NIP")]
    [StringLength(50)]
    public string? Nip { get; set; }

    public int? IdMiejsceUrodzenia { get; set; }

    [StringLength(50)]
    public string? ImieMatki { get; set; }

    [StringLength(50)]
    public string? NazwiskoRodoweMatki { get; set; }

    public int? IdAdresuZamieszkania { get; set; }

    public int? IdAdresuKorespondencji { get; set; }

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
    public string? KtoDezaktyowal { get; set; }

    [ForeignKey("IdAdresuKorespondencji")]
    [InverseProperty("PracownikIdAdresuKorespondencjiNavigations")]
    public virtual AdresZameldowanium? IdAdresuKorespondencjiNavigation { get; set; }

    [ForeignKey("IdAdresuZamieszkania")]
    [InverseProperty("PracownikIdAdresuZamieszkaniaNavigations")]
    public virtual AdresZameldowanium? IdAdresuZamieszkaniaNavigation { get; set; }

    [ForeignKey("IdJednostkaOrganizacyjna")]
    [InverseProperty("Pracowniks")]
    public virtual JednostkaOrganizacyjna? IdJednostkaOrganizacyjnaNavigation { get; set; }

    [ForeignKey("IdMiejsceUrodzenia")]
    [InverseProperty("Pracowniks")]
    public virtual MiejsceUrodzenium? IdMiejsceUrodzeniaNavigation { get; set; }

    [ForeignKey("IdPodstawyZatrudnienia")]
    [InverseProperty("Pracowniks")]
    public virtual PodstawaZatrudnienium? IdPodstawyZatrudnieniaNavigation { get; set; }

    [ForeignKey("IdStanowisko")]
    [InverseProperty("Pracowniks")]
    public virtual Stanowisko? IdStanowiskoNavigation { get; set; }

    [ForeignKey("IdTypNip")]
    [InverseProperty("Pracowniks")]
    public virtual TypNip? IdTypNipNavigation { get; set; }

    [ForeignKey("IdTypStawki")]
    [InverseProperty("Pracowniks")]
    public virtual TypStawki? IdTypStawkiNavigation { get; set; }

    [ForeignKey("IdTypUmowyOprace")]
    [InverseProperty("Pracowniks")]
    public virtual TypUmowyOprace? IdTypUmowyOpraceNavigation { get; set; }

    [ForeignKey("IdWymiaruEtatu")]
    [InverseProperty("Pracowniks")]
    public virtual WymiarEtatu? IdWymiaruEtatuNavigation { get; set; }
}
