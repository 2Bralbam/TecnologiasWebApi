using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace TecnologiasWebApi.Models.Entities;

public partial class ChismografoContext : DbContext
{
    public ChismografoContext()
    {
    }

    public ChismografoContext(DbContextOptions<ChismografoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Chisme> Chisme { get; set; }

    public virtual DbSet<Usuarios> Usuarios { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Chisme>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("chisme");

            entity.HasIndex(e => e.Titulo, "Titulo_UNIQUE").IsUnique();

            entity.HasIndex(e => e.IdUsuario, "fkChismeUsuario_idx");

            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.Titulo).HasMaxLength(120);

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.InverseIdUsuarioNavigation)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkChismeUsuario");
        });

        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("usuarios");

            entity.HasIndex(e => e.Correo, "NombreUsuario_UNIQUE").IsUnique();

            entity.Property(e => e.Correo).HasMaxLength(80);
            entity.Property(e => e.Password).HasMaxLength(45);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
