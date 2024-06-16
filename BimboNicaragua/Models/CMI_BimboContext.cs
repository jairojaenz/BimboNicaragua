using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BimboNicaragua.Models
{
    public partial class CMI_BimboContext : DbContext
    {
        public CMI_BimboContext()
        {
        }

        public CMI_BimboContext(DbContextOptions<CMI_BimboContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cmi> Cmis { get; set; } = null!;
        public virtual DbSet<Indicador> Indicadors { get; set; } = null!;
        public virtual DbSet<IndicadorDato> IndicadorDatos { get; set; } = null!;
        public virtual DbSet<Metum> Meta { get; set; } = null!;
        public virtual DbSet<Objetivo> Objetivos { get; set; } = null!;
        public virtual DbSet<Perspectiva> Perspectivas { get; set; } = null!;
        public virtual DbSet<Tipo> Tipos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;DataBase=CMI_Bimbo;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cmi>(entity =>
            {
                entity.ToTable("CMI");

                entity.Property(e => e.CmiId).HasColumnName("CMI_id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Periodo)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Indicador>(entity =>
            {
                entity.ToTable("Indicador");

                entity.Property(e => e.IndicadorId).HasColumnName("Indicador_id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ObjetivoId).HasColumnName("Objetivo_id");

                entity.Property(e => e.TipoId).HasColumnName("Tipo_id");

                entity.HasOne(d => d.Objetivo)
                    .WithMany(p => p.Indicadors)
                    .HasForeignKey(d => d.ObjetivoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Indicador__Objet__4316F928");

                entity.HasOne(d => d.Tipo)
                    .WithMany(p => p.Indicadors)
                    .HasForeignKey(d => d.TipoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Indicador__TipoI__440B1D61");
            });

            modelBuilder.Entity<IndicadorDato>(entity =>
            {
                entity.HasKey(e => e.IndicaDatoId)
                    .HasName("PK__Indicado__3214EC27BC880952");

                entity.ToTable("Indicador_Datos");

                entity.Property(e => e.IndicaDatoId).HasColumnName("IndicaDato_id");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.IndicadorId).HasColumnName("Indicador_id");

                entity.Property(e => e.Valor).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Indicador)
                    .WithMany(p => p.IndicadorDatos)
                    .HasForeignKey(d => d.IndicadorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Indicador__Indic__44FF419A");
            });

            modelBuilder.Entity<Metum>(entity =>
            {
                entity.HasKey(e => e.MetaId)
                    .HasName("PK__Meta__3214EC278B5D01B1");

                entity.Property(e => e.MetaId).HasColumnName("Meta_id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FechaLimite)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_limite");

                entity.Property(e => e.IndicadorId).HasColumnName("Indicador_id");

                entity.Property(e => e.ValorEsperado)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Valor_esperado");

                entity.HasOne(d => d.Indicador)
                    .WithMany(p => p.Meta)
                    .HasForeignKey(d => d.IndicadorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Meta__IndicadorI__45F365D3");
            });

            modelBuilder.Entity<Objetivo>(entity =>
            {
                entity.ToTable("Objetivo");

                entity.Property(e => e.ObjetivoId).HasColumnName("Objetivo_id");

                entity.Property(e => e.CmiId).HasColumnName("CMI_id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PerspectivaId).HasColumnName("Perspectiva_id");

                entity.HasOne(d => d.Cmi)
                    .WithMany(p => p.Objetivos)
                    .HasForeignKey(d => d.CmiId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Objetivo__CMIID__46E78A0C");

                entity.HasOne(d => d.Perspectiva)
                    .WithMany(p => p.Objetivos)
                    .HasForeignKey(d => d.PerspectivaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Objetivo__Perspe__47DBAE45");
            });

            modelBuilder.Entity<Perspectiva>(entity =>
            {
                entity.ToTable("Perspectiva");

                entity.Property(e => e.PerspectivaId).HasColumnName("Perspectiva_id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tipo>(entity =>
            {
                entity.ToTable("Tipo");

                entity.Property(e => e.TipoId).HasColumnName("Tipo_id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
