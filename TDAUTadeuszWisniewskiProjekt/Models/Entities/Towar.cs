using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TDAUTadeuszWisniewskiProjekt.Models.Entities;

[Table("Towar")]
public partial class Towar
{
    [Key]
    public int Id { get; set; }

    public int? IdCeny { get; set; }

    public int? IdCenaWyprzedazy { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? CenaKoncowa { get; set; }

    [StringLength(50)]
    public string? Nazwa { get; set; }

    [Column("IdStawkiVATZakupu")]
    public int? IdStawkiVatzakupu { get; set; }

    [Column("IdStawkiVATSprzedazy")]
    public int? IdStawkiVatsprzedazy { get; set; }

    [StringLength(50)]
    public string? NumerKatalogowy { get; set; }

    public int? IdTypu { get; set; }

    [StringLength(10)]
    public string? KodKreskowy { get; set; }

    [Column("IdEANu")]
    public int? IdEanu { get; set; }

    [Column("PKWiU")]
    [StringLength(50)]
    public string? PkwiU { get; set; }

    public bool? Opakowanie { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? KosztOpakowania { get; set; }

    public int? IdJednostka { get; set; }

    [Column("PodstawaZastosowaniaStawkiVAT")]
    [StringLength(50)]
    public string? PodstawaZastosowaniaStawkiVat { get; set; }

    public bool? DoWyprzedazy { get; set; }

    public bool? Blokada { get; set; }

    [StringLength(50)]
    public string? PowodBlokady { get; set; }

    public bool? UslugaPodnoszacaWartoscMagazynowa { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? WartoscUslugi { get; set; }

    [Column("IdKodCPV")]
    public int? IdKodCpv { get; set; }

    public bool? DodatkowyKoszt { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? WartoscDodatkowegoKosztu { get; set; }

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

    [ForeignKey("IdCenaWyprzedazy")]
    [InverseProperty("TowarIdCenaWyprzedazyNavigations")]
    public virtual Cena? IdCenaWyprzedazyNavigation { get; set; }

    [ForeignKey("IdCeny")]
    [InverseProperty("TowarIdCenyNavigations")]
    public virtual Cena? IdCenyNavigation { get; set; }

    [ForeignKey("IdEanu")]
    [InverseProperty("Towars")]
    public virtual Eantyp? IdEanuNavigation { get; set; }

    [ForeignKey("IdJednostka")]
    [InverseProperty("Towars")]
    public virtual Jednostka? IdJednostkaNavigation { get; set; }

    [ForeignKey("IdKodCpv")]
    [InverseProperty("Towars")]
    public virtual KodCpv? IdKodCpvNavigation { get; set; }

    [ForeignKey("IdStawkiVatsprzedazy")]
    [InverseProperty("TowarIdStawkiVatsprzedazyNavigations")]
    public virtual RodzajVat? IdStawkiVatsprzedazyNavigation { get; set; }

    [ForeignKey("IdStawkiVatzakupu")]
    [InverseProperty("TowarIdStawkiVatzakupuNavigations")]
    public virtual RodzajVat? IdStawkiVatzakupuNavigation { get; set; }

    [ForeignKey("IdTypu")]
    [InverseProperty("Towars")]
    public virtual Typ? IdTypuNavigation { get; set; }
}
