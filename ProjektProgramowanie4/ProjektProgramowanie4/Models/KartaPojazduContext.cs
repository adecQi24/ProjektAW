using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProjektProgramowanie4.Models;

public partial class KartaPojazduContext : DbContext
{
    public KartaPojazduContext()
    {
    }

    public KartaPojazduContext(DbContextOptions<KartaPojazduContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ewidencje> Ewidencje { get; set; }

    public virtual DbSet<LiczbaKilometrow> LiczbaKilometrow { get; set; }

    public virtual DbSet<OsobyKierujace> OsobyKierujace { get; set; }

    public virtual DbSet<Pojazdy> Pojazdy { get; set; }

    public virtual DbSet<Wpisy> Wpisy { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=DESKTOP-4NK0R5G;Database=KartaPojazdu;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ewidencje>(entity =>
        {
            entity.HasKey(e => e.IdEwidencji);

            entity.ToTable("Ewidencje");

            entity.Property(e => e.IdEwidencji);
            entity.Property(e => e.DataRozpoczecia)
                .HasColumnType("date");
            entity.Property(e => e.DataZakonczenia)
                .HasColumnType("date");
            entity.Property(e => e.IdLiczby);
            entity.Property(e => e.IdWpisu);
            entity.Property(e => e.StanLicznikaKoncowy);
            entity.Property(e => e.StanLicznikaPoczatkowy);

            entity.HasOne(d => d.IdLiczbyNavigation).WithMany(p => p.Ewidencje)
                .HasForeignKey(d => d.IdLiczby)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ewidencje_Liczba_Kilometrow");

            entity.HasOne(d => d.IdWpisuNavigation).WithMany(p => p.Ewidencje)
                .HasForeignKey(d => d.IdWpisu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ewidencje_Wpisy");
        });

        modelBuilder.Entity<LiczbaKilometrow>(entity =>
        {
            entity.HasKey(e => e.IdLiczby);

            entity.ToTable("Liczba_Kilometrow");

            entity.Property(e => e.IdLiczby);
            entity.Property(e => e.LiczbaKmKoncowa);
        });

        modelBuilder.Entity<OsobyKierujace>(entity =>
        {
            entity.HasKey(e => e.IdOsoby);

            entity.ToTable("Osoby_Kierujace");

            entity.Property(e => e.IdOsoby);
            entity.Property(e => e.Adres)
                .HasMaxLength(60);
            entity.Property(e => e.Imie)
                .HasMaxLength(30);
            entity.Property(e => e.Nazwisko)
                .HasMaxLength(30);
        });

        modelBuilder.Entity<Pojazdy>(entity =>
        {
            entity.HasKey(e => e.NrRejestracyjny);

            entity.ToTable("Pojazdy");

            entity.Property(e => e.NrRejestracyjny)
                .HasMaxLength(7);
            entity.Property(e => e.IdEwidencji);
            entity.Property(e => e.MarkaPojazdu)
                .HasMaxLength(30);
            entity.Property(e => e.RodzajPojazdu)
                .HasMaxLength(30);

            entity.HasOne(d => d.IdEwidencjiNavigation).WithMany(p => p.Pojazdy)
                .HasForeignKey(d => d.IdEwidencji)
                .HasConstraintName("FK_Pojazdy_Ewidencje");
        });

        modelBuilder.Entity<Wpisy>(entity =>
        {
            entity.HasKey(e => e.IdWpisu);

            entity.ToTable("Wpisy");

            entity.Property(e => e.IdWpisu);
            entity.Property(e => e.DataWyjazdu)
                .HasColumnType("date");
            entity.Property(e => e.IdLiczby);
            entity.Property(e => e.IdOsoby);
            entity.Property(e => e.KolejnyNrWpisu);
            entity.Property(e => e.LiczbaPrzejechanychKm);
            entity.Property(e => e.OpisTrasy)
                .HasMaxLength(255)
                .HasColumnName("opis_trasy");

            entity.HasOne(d => d.IdLiczbyNavigation).WithMany(p => p.Wpisy)
                .HasForeignKey(d => d.IdLiczby)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Wpisy_Liczba_Kilometrow");

            entity.HasOne(d => d.IdOsobyNavigation).WithMany(p => p.Wpisy)
                .HasForeignKey(d => d.IdOsoby)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Wpisy_Osoby_Kierujace");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
