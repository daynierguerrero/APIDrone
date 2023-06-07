using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Drone.Model;

namespace Drone.DAL.DbContex;

public partial class DbDroneContext : DbContext
{
    public DbDroneContext()
    {
    }

    public DbDroneContext(DbContextOptions<DbDroneContext> options)
        : base(options)
    {
    }


    public virtual DbSet<Dron> Drones { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Medicamento> Medicamentos { get; set; }
    public virtual DbSet<Modelo> Modelos { get; set; }



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {


     

        modelBuilder.Entity<Dron>(entity =>
        {
            entity.HasKey(e => e.IdDrone).HasName("PK__Drone__2CE1B38B031563CC");

            entity.ToTable("Drone");

            entity.Property(e => e.IdDrone).HasColumnName("idDrone");
            entity.Property(e => e.CapacidadBateria).HasColumnName("capacidadBateria");
            entity.Property(e => e.IdEstado).HasColumnName("idEstado");
            entity.Property(e => e.IdModelo).HasColumnName("idModelo");
            entity.Property(e => e.NumerSerie)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("numerSerie");
            entity.Property(e => e.PesoLimite)
                .HasColumnType("decimal(3, 2)")
                .HasColumnName("pesoLimite");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Drones)
                .HasForeignKey(d => d.IdEstado)
                .HasConstraintName("FK__Drone__idEstado__619B8048");

            entity.HasOne(d => d.IdModeloNavigation).WithMany(p => p.Drones)
                .HasForeignKey(d => d.IdModelo)
                .HasConstraintName("FK__Drone__idModelo__60A75C0F");
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.IdEstado).HasName("PK__Estado__62EA894A6169A70C");

            entity.ToTable("Estado");

            entity.Property(e => e.IdEstado).HasColumnName("idEstado");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<Medicamento>(entity =>
        {
            entity.HasKey(e => e.IdMedicamento).HasName("PK__Medicame__42B24C58DDF7C54C");

            entity.ToTable("Medicamento");

            entity.Property(e => e.IdMedicamento).HasColumnName("idMedicamento");
            entity.Property(e => e.Codigo)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("codigo");
            entity.Property(e => e.Imagen).HasColumnName("imagen");
            entity.Property(e => e.Nombre)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Peso)
                .HasColumnType("decimal(3, 2)")
                .HasColumnName("peso");
        });


        modelBuilder.Entity<Modelo>(entity =>
        {
            entity.HasKey(e => e.IdModelo).HasName("PK__Modelo__13A52CD135EA748A");

            entity.ToTable("Modelo");

            entity.Property(e => e.IdModelo).HasColumnName("idModelo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("descripcion");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
