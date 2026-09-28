using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace appSatTech.Models;

public partial class DbTecnicoContext : DbContext
{
    public DbTecnicoContext()
    {
    }

    public DbTecnicoContext(DbContextOptions<DbTecnicoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Chamado> Chamados { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Tecnico> Tecnicos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConexaoSqlServer");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Chamado>(entity =>
        {
            entity.HasKey(e => e.Codigo);

            entity.ToTable("Chamado");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.DataHora).HasColumnType("datetime");
            entity.Property(e => e.StatusAtendimento)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TecnicoId).HasColumnName("TecnicoID");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Chamados)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Chamado_Cliente");

            entity.HasOne(d => d.Tecnico).WithMany(p => p.Chamados)
                .HasForeignKey(d => d.TecnicoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Chamado_Tecnico");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Codigo);

            entity.ToTable("Cliente");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.Cpf)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CPF");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Telefone)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Tecnico>(entity =>
        {
            entity.HasKey(e => e.Codigo);

            entity.ToTable("Tecnico");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.Especialidade)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.RegistroTecnico)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
