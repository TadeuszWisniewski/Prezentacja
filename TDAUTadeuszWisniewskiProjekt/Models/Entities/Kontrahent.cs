using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TDAUTadeuszWisniewskiProjekt.Models.Entities;

[Table("Kontrahent")]
public partial class Kontrahent
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string? Kod { get; set; }

    [StringLength(50)]
    public string? Bazwa { get; set; }

    [Column("NIP")]
    [StringLength(50)]
    public string? Nip { get; set; }

    [Column("PodatnikVAT")]
    public bool? PodatnikVat { get; set; }

    [Column("IdStatusWBazieMF")]
    public int? IdStatusWbazieMf { get; set; }

    [Column("IdStatusWBazieVIES")]
    public int? IdStatusWbazieVies { get; set; }

    public int? IdStatus { get; set; }

    public int? IdFormaPrawna { get; set; }

    [Column("DataAktualizacjiMF", TypeName = "datetime")]
    public DateTime? DataAktualizacjiMf { get; set; }

    [Column("DataAktualizacjiVIES", TypeName = "datetime")]
    public DateTime? DataAktualizacjiVies { get; set; }

    public int? IdAdresuZameldowania { get; set; }

    public int? IdAdresuDoKorespondencji { get; set; }

    [Column("PESEL")]
    [StringLength(50)]
    public string? Pesel { get; set; }

    [Column("KRS")]
    [StringLength(50)]
    public string? Krs { get; set; }

    [Column("StronaWWW")]
    [StringLength(50)]
    public string? StronaWww { get; set; }

    [Column("REGON")]
    [StringLength(50)]
    public string? Regon { get; set; }

    [Column("GLN/ILN")]
    [StringLength(50)]
    public string? GlnIln { get; set; }

    public int? IdDefinicjaPlatnosci { get; set; }

    public bool? BlokadaSprzedazy { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? LacznaWartoscFaktur { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? LimitKredytu { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? SumaZaleglychNaleznosci { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? PozostalyLimit { get; set; }

    public int? Termin { get; set; }

    public int? IdWaluta { get; set; }

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

    [InverseProperty("IdKontrahentaNavigation")]
    public virtual ICollection<Faktura> Fakturas { get; set; } = new List<Faktura>();

    [ForeignKey("IdAdresuDoKorespondencji")]
    [InverseProperty("KontrahentIdAdresuDoKorespondencjiNavigations")]
    public virtual AdresZameldowanium? IdAdresuDoKorespondencjiNavigation { get; set; }

    [ForeignKey("IdAdresuZameldowania")]
    [InverseProperty("KontrahentIdAdresuZameldowaniaNavigations")]
    public virtual AdresZameldowanium? IdAdresuZameldowaniaNavigation { get; set; }

    [ForeignKey("IdDefinicjaPlatnosci")]
    [InverseProperty("Kontrahents")]
    public virtual DefinicjaPlatnosci? IdDefinicjaPlatnosciNavigation { get; set; }

    [ForeignKey("IdFormaPrawna")]
    [InverseProperty("Kontrahents")]
    public virtual FormaPrawna? IdFormaPrawnaNavigation { get; set; }

    [ForeignKey("IdStatus")]
    [InverseProperty("Kontrahents")]
    public virtual Status? IdStatusNavigation { get; set; }

    [ForeignKey("IdStatusWbazieMf")]
    [InverseProperty("KontrahentIdStatusWbazieMfNavigations")]
    public virtual StatusWbazie? IdStatusWbazieMfNavigation { get; set; }

    [ForeignKey("IdStatusWbazieVies")]
    [InverseProperty("KontrahentIdStatusWbazieViesNavigations")]
    public virtual StatusWbazie? IdStatusWbazieViesNavigation { get; set; }

    [ForeignKey("IdWaluta")]
    [InverseProperty("Kontrahents")]
    public virtual Walutum? IdWalutaNavigation { get; set; }
}
