using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using TheLastBugPrueba.Models;

namespace TheLastBugPrueba.DAL
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Region> Regiones { get; set; }
        public DbSet<Comuna> Comunas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<AyudaSocial> AyudasSociales { get; set; }
        public DbSet<AsignacionAyudaSocial> AsignacionAyudaSociales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.UsuarioId);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Email)
                    .HasMaxLength(100);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(15);

                entity.HasMany(u => u.AyudasSociales)
                    .WithOne(a => a.Usuario)
                    .HasForeignKey(a => a.UsuarioId);

                entity.HasMany(u => u.AsignacionesAyudaSocial)
                    .WithOne(a => a.Usuario)
                    .HasForeignKey(a => a.UsuarioId)
                    .OnDelete(DeleteBehavior.NoAction);
            });
            modelBuilder.Entity<Region>(entity =>
            {
                entity.HasKey(e => e.RegionId);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Pais)
                    .WithMany(p => p.Regiones)
                    .HasForeignKey(d => d.PaisId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasMany(e => e.Comunas)
                    .WithOne(c => c.Region)
                    .HasForeignKey(c => c.RegionId);
            });
            modelBuilder.Entity<Pais>(entity =>
            {
                entity.HasKey(e => e.PaisId);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Regiones)
                .IsRequired(false);


                entity.HasMany(e => e.Regiones)
                    .WithOne(r => r.Pais)
                    .HasForeignKey(r => r.PaisId)
                    .OnDelete(DeleteBehavior.NoAction);
            });
            modelBuilder.Entity<Comuna>(entity =>
            {
                entity.HasKey(e => e.ComunaId);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(e => e.Region)
                    .WithMany(r => r.Comunas)
                    .HasForeignKey(e => e.RegionId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasMany(e => e.AyudasSociales)
                    .WithOne(a => a.Comuna)
                    .HasForeignKey(a => a.ComunaId)
                    .OnDelete(DeleteBehavior.NoAction);
            });
            modelBuilder.Entity<AyudaSocial>(entity =>
            {
                entity.HasKey(e => e.AyudaSocialId);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(e => e.Comuna)
                    .WithMany(c => c.AyudasSociales)
                    .HasForeignKey(e => e.ComunaId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(e => e.Usuario)
                    .WithMany(u => u.AyudasSociales)
                    .HasForeignKey(e => e.UsuarioId)
                    .OnDelete(DeleteBehavior.NoAction);
            });
            modelBuilder.Entity<AsignacionAyudaSocial>(entity =>
            {
                entity.HasKey(a => a.AsignacionAyudaSocialId);

                // Configuración de la relación con Usuario
                entity.HasOne(a => a.Usuario)
                    .WithMany(u => u.AsignacionesAyudaSocial)
                    .HasForeignKey(a => a.UsuarioId)
                    .OnDelete(DeleteBehavior.NoAction);

                // Configuración de la relación con AyudaSocial
                entity.HasOne(a => a.AyudaSocial)
                    .WithMany(ay => ay.AsignacionesAyudaSocial)
                    .HasForeignKey(a => a.AyudaSocialId)
                    .OnDelete(DeleteBehavior.NoAction);

                // Configuración de propiedad
                entity.Property(a => a.FechaAsignacion)
                    .IsRequired();
            });
        }
    }
}
