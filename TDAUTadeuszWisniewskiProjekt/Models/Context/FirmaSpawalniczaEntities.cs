using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TDAUTadeuszWisniewskiProjekt.Models.Entities;

namespace TDAUTadeuszWisniewskiProjekt.Models.Context;

public partial class FirmaSpawalniczaEntities : DbContext
{
    public FirmaSpawalniczaEntities()
    {
    }

    public FirmaSpawalniczaEntities(DbContextOptions<FirmaSpawalniczaEntities> options)
        : base(options)
    {
    }

    public virtual DbSet<AdresZameldowanium> AdresZameldowania { get; set; }

    public virtual DbSet<Cena> Cenas { get; set; }

    public virtual DbSet<DefinicjaPlatnosci> DefinicjaPlatnoscis { get; set; }

    public virtual DbSet<Eantyp> Eantyps { get; set; }

    public virtual DbSet<Faktura> Fakturas { get; set; }

    public virtual DbSet<FormaPrawna> FormaPrawnas { get; set; }

    public virtual DbSet<Jednostka> Jednostkas { get; set; }

    public virtual DbSet<JednostkaOrganizacyjna> JednostkaOrganizacyjnas { get; set; }

    public virtual DbSet<KodCpv> KodCpvs { get; set; }

    public virtual DbSet<Kontrahent> Kontrahents { get; set; }

    public virtual DbSet<Kraj> Krajs { get; set; }

    public virtual DbSet<MiejsceUrodzenium> MiejsceUrodzenia { get; set; }

    public virtual DbSet<Miejscowosc> Miejscowoscs { get; set; }

    public virtual DbSet<PodstawaZatrudnienium> PodstawaZatrudnienia { get; set; }

    public virtual DbSet<Pracownik> Pracowniks { get; set; }

    public virtual DbSet<RodzajVat> RodzajVats { get; set; }

    public virtual DbSet<Stanowisko> Stanowiskos { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<StatusWbazie> StatusWbazies { get; set; }

    public virtual DbSet<Towar> Towars { get; set; }

    public virtual DbSet<Typ> Typs { get; set; }

    public virtual DbSet<TypNip> TypNips { get; set; }

    public virtual DbSet<TypStawki> TypStawkis { get; set; }

    public virtual DbSet<TypUmowyOprace> TypUmowyOpraces { get; set; }

    public virtual DbSet<Walutum> Waluta { get; set; }

    public virtual DbSet<Wojewodztwo> Wojewodztwos { get; set; }

    public virtual DbSet<WymiarEtatu> WymiarEtatus { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=MójLaptop;TrustServerCertificate=True;Integrated Security=True;Database=FirmaSpawalniczaZaliczenie");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Latin1_General_CI_AS");

        modelBuilder.Entity<AdresZameldowanium>(entity =>
        {
            entity.Property(e => e.KodGminy).IsFixedLength();
            entity.Property(e => e.KodPocztowy).IsFixedLength();
            entity.Property(e => e.NumerDomu).IsFixedLength();
            entity.Property(e => e.NumerLokalu).IsFixedLength();

            entity.HasOne(d => d.IdKrajuNavigation).WithMany(p => p.AdresZameldowania).HasConstraintName("FK_AdresZameldowania_Kraj");

            entity.HasOne(d => d.IdMiejscowoscNavigation).WithMany(p => p.AdresZameldowania).HasConstraintName("FK_AdresZameldowania_Miejscowosc1");

            entity.HasOne(d => d.IdWojewodztwaNavigation).WithMany(p => p.AdresZameldowania).HasConstraintName("FK_AdresZameldowania_Wojewodztwo");
        });

        modelBuilder.Entity<Faktura>(entity =>
        {
            entity.HasOne(d => d.IdKontrahentaNavigation).WithMany(p => p.Fakturas).HasConstraintName("FK_Faktura_Kontrahent");
        });

        modelBuilder.Entity<Kontrahent>(entity =>
        {
            entity.HasOne(d => d.IdAdresuDoKorespondencjiNavigation).WithMany(p => p.KontrahentIdAdresuDoKorespondencjiNavigations).HasConstraintName("FK_Kontrahent_AdresZameldowania1");

            entity.HasOne(d => d.IdAdresuZameldowaniaNavigation).WithMany(p => p.KontrahentIdAdresuZameldowaniaNavigations).HasConstraintName("FK_Kontrahent_AdresZameldowania");

            entity.HasOne(d => d.IdDefinicjaPlatnosciNavigation).WithMany(p => p.Kontrahents).HasConstraintName("FK_Kontrahent_DefinicjaPlatnosci");

            entity.HasOne(d => d.IdFormaPrawnaNavigation).WithMany(p => p.Kontrahents).HasConstraintName("FK_Kontrahent_FormaPrawna");

            entity.HasOne(d => d.IdStatusNavigation).WithMany(p => p.Kontrahents).HasConstraintName("FK_Kontrahent_Status");

            entity.HasOne(d => d.IdStatusWbazieMfNavigation).WithMany(p => p.KontrahentIdStatusWbazieMfNavigations).HasConstraintName("FK_Kontrahent_StatusWBazie");

            entity.HasOne(d => d.IdStatusWbazieViesNavigation).WithMany(p => p.KontrahentIdStatusWbazieViesNavigations).HasConstraintName("FK_Kontrahent_StatusWBazie1");

            entity.HasOne(d => d.IdWalutaNavigation).WithMany(p => p.Kontrahents).HasConstraintName("FK_Kontrahent_Waluta");
        });

        modelBuilder.Entity<MiejsceUrodzenium>(entity =>
        {
            entity.HasOne(d => d.IdMiejscowoscNavigation).WithMany(p => p.MiejsceUrodzenia).HasConstraintName("FK_MiejsceUrodzenia_Miejscowosc");
        });

        modelBuilder.Entity<Pracownik>(entity =>
        {
            entity.HasOne(d => d.IdAdresuKorespondencjiNavigation).WithMany(p => p.PracownikIdAdresuKorespondencjiNavigations).HasConstraintName("FK_Pracownik_AdresZameldowania1");

            entity.HasOne(d => d.IdAdresuZamieszkaniaNavigation).WithMany(p => p.PracownikIdAdresuZamieszkaniaNavigations).HasConstraintName("FK_Pracownik_AdresZameldowania");

            entity.HasOne(d => d.IdJednostkaOrganizacyjnaNavigation).WithMany(p => p.Pracowniks).HasConstraintName("FK_Pracownik_JednostkaOrganizacyjna");

            entity.HasOne(d => d.IdMiejsceUrodzeniaNavigation).WithMany(p => p.Pracowniks).HasConstraintName("FK_Pracownik_MiejsceUrodzenia");

            entity.HasOne(d => d.IdPodstawyZatrudnieniaNavigation).WithMany(p => p.Pracowniks).HasConstraintName("FK_Pracownik_PodstawaZatrudnienia");

            entity.HasOne(d => d.IdStanowiskoNavigation).WithMany(p => p.Pracowniks).HasConstraintName("FK_Pracownik_Stanowisko");

            entity.HasOne(d => d.IdTypNipNavigation).WithMany(p => p.Pracowniks).HasConstraintName("FK_Pracownik_TypNIP");

            entity.HasOne(d => d.IdTypStawkiNavigation).WithMany(p => p.Pracowniks).HasConstraintName("FK_Pracownik_TypStawki");

            entity.HasOne(d => d.IdTypUmowyOpraceNavigation).WithMany(p => p.Pracowniks).HasConstraintName("FK_Pracownik_TypUmowyOPrace");

            entity.HasOne(d => d.IdWymiaruEtatuNavigation).WithMany(p => p.Pracowniks).HasConstraintName("FK_Pracownik_WymiarEtatu");
        });

        modelBuilder.Entity<Towar>(entity =>
        {
            entity.Property(e => e.KodKreskowy).IsFixedLength();

            entity.HasOne(d => d.IdCenaWyprzedazyNavigation).WithMany(p => p.TowarIdCenaWyprzedazyNavigations).HasConstraintName("FK_Towar_Cena1");

            entity.HasOne(d => d.IdCenyNavigation).WithMany(p => p.TowarIdCenyNavigations).HasConstraintName("FK_Towar_Cena");

            entity.HasOne(d => d.IdEanuNavigation).WithMany(p => p.Towars).HasConstraintName("FK_Towar_EANTyp");

            entity.HasOne(d => d.IdJednostkaNavigation).WithMany(p => p.Towars).HasConstraintName("FK_Towar_Jednostka");

            entity.HasOne(d => d.IdKodCpvNavigation).WithMany(p => p.Towars).HasConstraintName("FK_Towar_KodCPV");

            entity.HasOne(d => d.IdStawkiVatsprzedazyNavigation).WithMany(p => p.TowarIdStawkiVatsprzedazyNavigations).HasConstraintName("FK_Towar_RodzajVAT");

            entity.HasOne(d => d.IdStawkiVatzakupuNavigation).WithMany(p => p.TowarIdStawkiVatzakupuNavigations).HasConstraintName("FK_Towar_RodzajVAT1");

            entity.HasOne(d => d.IdTypuNavigation).WithMany(p => p.Towars).HasConstraintName("FK_Towar_Typ");
        });

        modelBuilder.Entity<Walutum>(entity =>
        {
            entity.Property(e => e.Skrot).IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
