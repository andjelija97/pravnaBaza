using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PravnaBazaBE.Models
{
    public partial class obrazovn_AdminPanelContext : DbContext
    {
        public obrazovn_AdminPanelContext()
        {
        }

        public obrazovn_AdminPanelContext(DbContextOptions<obrazovn_AdminPanelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alineja> Alineja { get; set; }
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<Clan> Clan { get; set; }
        public virtual DbSet<DonosilacSm> DonosilacSm { get; set; }
        public virtual DbSet<DonosilacSp> DonosilacSp { get; set; }
        public virtual DbSet<GlavneOblasti> GlavneOblasti { get; set; }
        public virtual DbSet<NivoPodnaslova> NivoPodnaslova { get; set; }
        public virtual DbSet<Podnaslov> Podnaslov { get; set; }
        public virtual DbSet<PodpodrubrikaSm> PodpodrubrikaSm { get; set; }
        public virtual DbSet<PodpodrubrikaSp> PodpodrubrikaSp { get; set; }
        public virtual DbSet<Podrubrika> Podrubrika { get; set; }
        public virtual DbSet<PodrubrikaSm> PodrubrikaSm { get; set; }
        public virtual DbSet<PodrubrikaSp> PodrubrikaSp { get; set; }
        public virtual DbSet<Pretplatnik> Pretplatnik { get; set; }
        public virtual DbSet<Propis> Propis { get; set; }
        public virtual DbSet<PropisSluzbenoMisljenje> PropisSluzbenoMisljenje { get; set; }
        public virtual DbSet<PropisSudskaPraksa> PropisSudskaPraksa { get; set; }
        public virtual DbSet<Rubrika> Rubrika { get; set; }
        public virtual DbSet<RubrikaSm> RubrikaSm { get; set; }
        public virtual DbSet<RubrikaSp> RubrikaSp { get; set; }
        public virtual DbSet<SluzbenoMisljenje> SluzbenoMisljenje { get; set; }
        public virtual DbSet<Stav> Stav { get; set; }
        public virtual DbSet<SudskaPraksa> SudskaPraksa { get; set; }
        public virtual DbSet<Tacka> Tacka { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=RYZEN\\SQLANDJA;Database=obrazovn_AdminPanel;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alineja>(entity =>
            {
                entity.Property(e => e.NazivAlineje).HasMaxLength(255);
            });

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Clan>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Naziv).HasMaxLength(250);

                entity.HasOne(d => d.IdPodnaslovNavigation)
                    .WithMany(p => p.Clan)
                    .HasForeignKey(d => d.IdPodnaslov)
                    .HasConstraintName("FK_Clan_Podnaslovi");

                entity.HasOne(d => d.IdPropisNavigation)
                    .WithMany(p => p.Clan)
                    .HasForeignKey(d => d.IdPropis)
                    .HasConstraintName("FK_Clan_Propis1");
            });

            modelBuilder.Entity<DonosilacSm>(entity =>
            {
                entity.ToTable("DonosilacSM");
            });

            modelBuilder.Entity<DonosilacSp>(entity =>
            {
                entity.ToTable("DonosilacSP");
            });

            modelBuilder.Entity<GlavneOblasti>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Naziv).HasMaxLength(255);
            });

            modelBuilder.Entity<NivoPodnaslova>(entity =>
            {
                entity.Property(e => e.Naziv).HasMaxLength(250);
            });

            modelBuilder.Entity<Podnaslov>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdNivoPodnaslovaNavigation)
                    .WithMany(p => p.Podnaslov)
                    .HasForeignKey(d => d.IdNivoPodnaslova)
                    .HasConstraintName("FK_Podnaslov_NivoPodnaslova");

                entity.HasOne(d => d.IdPropisNavigation)
                    .WithMany(p => p.Podnaslov)
                    .HasForeignKey(d => d.IdPropis)
                    .HasConstraintName("FK_Podnaslov_Propis");
            });

            modelBuilder.Entity<PodpodrubrikaSm>(entity =>
            {
                entity.ToTable("PodpodrubrikaSM");

                entity.HasOne(d => d.IdPodrubrikaNavigation)
                    .WithMany(p => p.PodpodrubrikaSm)
                    .HasForeignKey(d => d.IdPodrubrika)
                    .HasConstraintName("FK_PodpodrubrikaSM_PodrubrikaSM");
            });

            modelBuilder.Entity<PodpodrubrikaSp>(entity =>
            {
                entity.ToTable("PodpodrubrikaSP");

                entity.HasOne(d => d.IdPodrubrikaNavigation)
                    .WithMany(p => p.PodpodrubrikaSp)
                    .HasForeignKey(d => d.IdPodrubrika)
                    .HasConstraintName("FK_PodpodrubrikaSP_PodrubrikaSP");
            });

            modelBuilder.Entity<Podrubrika>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.HasOne(d => d.IdRubrikaNavigation)
                    .WithMany(p => p.Podrubrika)
                    .HasForeignKey(d => d.IdRubrika)
                    .HasConstraintName("FK_Podrubrika_Rubrika");
            });

            modelBuilder.Entity<PodrubrikaSm>(entity =>
            {
                entity.ToTable("PodrubrikaSM");

                entity.HasOne(d => d.IdRubrikaNavigation)
                    .WithMany(p => p.PodrubrikaSm)
                    .HasForeignKey(d => d.IdRubrika)
                    .HasConstraintName("FK_PodrubrikaSM_RubrikaSM");
            });

            modelBuilder.Entity<PodrubrikaSp>(entity =>
            {
                entity.ToTable("PodrubrikaSP");

                entity.HasOne(d => d.IdRubrikaNavigation)
                    .WithMany(p => p.PodrubrikaSp)
                    .HasForeignKey(d => d.IdRubrika)
                    .HasConstraintName("FK_PodrubrikaSP_RubrikaSP");
            });

            modelBuilder.Entity<Pretplatnik>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BrojTelefona).HasMaxLength(50);

                entity.Property(e => e.DatumKrajaPretplate).HasMaxLength(50);

                entity.Property(e => e.DatumPocetkaPretplate).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Ime).HasMaxLength(50);

                entity.Property(e => e.KorisnickoIme).HasMaxLength(50);

                entity.Property(e => e.MaticniBroj).HasMaxLength(50);

                entity.Property(e => e.Pib)
                    .HasColumnName("PIB")
                    .HasMaxLength(50);

                entity.Property(e => e.Pretplata).HasMaxLength(50);

                entity.Property(e => e.Prezime).HasMaxLength(50);
            });

            modelBuilder.Entity<Propis>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DatumObjavljivanjaOsnovnogTeksta).HasColumnType("datetime");

                entity.Property(e => e.DatumObjavljivanjaVerzije).HasColumnType("datetime");

                entity.Property(e => e.DatumPocetkaPrimene).HasColumnType("datetime");

                entity.Property(e => e.DatumPrestankaVazenjaPropisa).HasColumnType("datetime");

                entity.Property(e => e.DatumPrestankaVerzije).HasColumnType("datetime");

                entity.Property(e => e.DatumStupanjaNaSnaguMeđunarodnogUgovora).HasColumnType("datetime");

                entity.Property(e => e.DatumStupanjaNaSnaguOsnovnogTekstaPropisa).HasColumnType("datetime");

                entity.Property(e => e.DatumStupanjaNaSnaguVerzijePropisa).HasColumnType("datetime");

                entity.Property(e => e.GlasiloIdatumObjavljivanja).HasColumnName("GlasiloIDatumObjavljivanja");

                entity.Property(e => e.Naslov).HasMaxLength(255);

                entity.Property(e => e.Preambula).IsUnicode(false);

                entity.HasOne(d => d.IdPodrubrikeNavigation)
                    .WithMany(p => p.Propis)
                    .HasForeignKey(d => d.IdPodrubrike)
                    .HasConstraintName("FK_Propis_Podrubrika1");

                entity.HasOne(d => d.IdRubrikeNavigation)
                    .WithMany(p => p.Propis)
                    .HasForeignKey(d => d.IdRubrike)
                    .HasConstraintName("FK_Propis_Rubrika");
            });

            modelBuilder.Entity<PropisSluzbenoMisljenje>(entity =>
            {
                entity.Property(e => e.DatumUnosa).HasColumnType("datetime");
            });

            modelBuilder.Entity<PropisSudskaPraksa>(entity =>
            {
                entity.Property(e => e.DatumUnosa).HasColumnType("datetime");
            });

            modelBuilder.Entity<Rubrika>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.HasOne(d => d.IdOblastNavigation)
                    .WithMany(p => p.Rubrika)
                    .HasForeignKey(d => d.IdOblast)
                    .HasConstraintName("FK_Rubrika_GlavneOblasti");
            });

            modelBuilder.Entity<RubrikaSm>(entity =>
            {
                entity.ToTable("RubrikaSM");
            });

            modelBuilder.Entity<RubrikaSp>(entity =>
            {
                entity.ToTable("RubrikaSP");
            });

            modelBuilder.Entity<SluzbenoMisljenje>(entity =>
            {
                entity.Property(e => e.DatumDonosenja).HasColumnType("datetime");

                entity.Property(e => e.IdDonosilacSm).HasColumnName("IdDonosilacSM");

                entity.Property(e => e.IdPodpodrubrikaSm).HasColumnName("IdPodpodrubrikaSM");

                entity.Property(e => e.IdPodrubrikaSm).HasColumnName("IdPodrubrikaSM");

                entity.Property(e => e.IdRubrikaSm).HasColumnName("IdRubrikaSM");

                entity.HasOne(d => d.IdClanNavigation)
                    .WithMany(p => p.SluzbenoMisljenje)
                    .HasForeignKey(d => d.IdClan)
                    .HasConstraintName("FK_SluzbenoMisljenje_Clan");

                entity.HasOne(d => d.IdDonosilacSmNavigation)
                    .WithMany(p => p.SluzbenoMisljenje)
                    .HasForeignKey(d => d.IdDonosilacSm)
                    .HasConstraintName("FK_SluzbenaMisljenja_DonosilacSM");

                entity.HasOne(d => d.IdPodpodrubrikaSmNavigation)
                    .WithMany(p => p.SluzbenoMisljenje)
                    .HasForeignKey(d => d.IdPodpodrubrikaSm)
                    .HasConstraintName("FK_SluzbenoMisljenje_PodpodrubrikaSM");

                entity.HasOne(d => d.IdPodrubrikaSmNavigation)
                    .WithMany(p => p.SluzbenoMisljenje)
                    .HasForeignKey(d => d.IdPodrubrikaSm)
                    .HasConstraintName("FK_SluzbenaMisljenja_PodrubrikaSM");

                entity.HasOne(d => d.IdPropisNavigation)
                    .WithMany(p => p.SluzbenoMisljenje)
                    .HasForeignKey(d => d.IdPropis)
                    .HasConstraintName("FK_SluzbenoMisljenje_Propis");

                entity.HasOne(d => d.IdRubrikaSmNavigation)
                    .WithMany(p => p.SluzbenoMisljenje)
                    .HasForeignKey(d => d.IdRubrikaSm)
                    .HasConstraintName("FK_SluzbenaMisljenja_RubrikaSM");

                entity.HasOne(d => d.IdStavNavigation)
                    .WithMany(p => p.SluzbenoMisljenje)
                    .HasForeignKey(d => d.IdStav)
                    .HasConstraintName("FK_SluzbenoMisljenje_Stav");

                entity.HasOne(d => d.IdTackaNavigation)
                    .WithMany(p => p.SluzbenoMisljenje)
                    .HasForeignKey(d => d.IdTacka)
                    .HasConstraintName("FK_SluzbenoMisljenje_Tacka");
            });

            modelBuilder.Entity<Stav>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdClanNavigation)
                    .WithMany(p => p.Stav)
                    .HasForeignKey(d => d.IdClan)
                    .HasConstraintName("FK_Stav_Clan");
            });

            modelBuilder.Entity<SudskaPraksa>(entity =>
            {
                entity.Property(e => e.Datum).HasColumnType("datetime");

                entity.Property(e => e.IdDonosilacSp).HasColumnName("IdDonosilacSP");

                entity.Property(e => e.IdPodpodrubrikaSp).HasColumnName("IdPodpodrubrikaSP");

                entity.Property(e => e.IdPodrubrikaSp).HasColumnName("IdPodrubrikaSP");

                entity.Property(e => e.IdRubrikaSp).HasColumnName("IdRubrikaSP");

                entity.HasOne(d => d.IdClanNavigation)
                    .WithMany(p => p.SudskaPraksa)
                    .HasForeignKey(d => d.IdClan)
                    .HasConstraintName("FK_SudskaPraksa_Clan");

                entity.HasOne(d => d.IdDonosilacSpNavigation)
                    .WithMany(p => p.SudskaPraksa)
                    .HasForeignKey(d => d.IdDonosilacSp)
                    .HasConstraintName("FK_SudskaPraksa_DonosilacSP");

                entity.HasOne(d => d.IdPodpodrubrikaSpNavigation)
                    .WithMany(p => p.SudskaPraksa)
                    .HasForeignKey(d => d.IdPodpodrubrikaSp)
                    .HasConstraintName("FK_SudskaPraksa_PodpodrubrikaSP");

                entity.HasOne(d => d.IdPodrubrikaSpNavigation)
                    .WithMany(p => p.SudskaPraksa)
                    .HasForeignKey(d => d.IdPodrubrikaSp)
                    .HasConstraintName("FK_SudskaPraksa_PodrubrikaSP");

                entity.HasOne(d => d.IdPropisNavigation)
                    .WithMany(p => p.SudskaPraksa)
                    .HasForeignKey(d => d.IdPropis)
                    .HasConstraintName("FK_SudskaPraksa_Propis");

                entity.HasOne(d => d.IdRubrikaSpNavigation)
                    .WithMany(p => p.SudskaPraksa)
                    .HasForeignKey(d => d.IdRubrikaSp)
                    .HasConstraintName("FK_SudskaPraksa_RubrikaSP");

                entity.HasOne(d => d.IdStavNavigation)
                    .WithMany(p => p.SudskaPraksa)
                    .HasForeignKey(d => d.IdStav)
                    .HasConstraintName("FK_SudskaPraksa_Stav");

                entity.HasOne(d => d.IdTackaNavigation)
                    .WithMany(p => p.SudskaPraksa)
                    .HasForeignKey(d => d.IdTacka)
                    .HasConstraintName("FK_SudskaPraksa_Tacka");
            });

            modelBuilder.Entity<Tacka>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Naziv).HasMaxLength(250);

                entity.HasOne(d => d.IdStavNavigation)
                    .WithMany(p => p.Tacka)
                    .HasForeignKey(d => d.IdStav)
                    .HasConstraintName("FK_Tacka_Stav");
            });
        }
    }
}
