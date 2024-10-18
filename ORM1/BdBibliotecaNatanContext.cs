using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProjetoWebApiNatan.ORM3;

public partial class BdBibliotecaNatanContext : DbContext
{
    public BdBibliotecaNatanContext()
    {
    }

    public BdBibliotecaNatanContext(DbContextOptions<BdBibliotecaNatanContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbCategoria> TbCategorias { get; set; }

    public virtual DbSet<TbEmprestimo> TbEmprestimos { get; set; }

    public virtual DbSet<TbFuncionario> TbFuncionarios { get; set; }

    public virtual DbSet<TbLivro> TbLivros { get; set; }

    public virtual DbSet<TbMembro> TbMembros { get; set; }

    public virtual DbSet<TbReserva> TbReservas { get; set; }

    public virtual DbSet<TbUsuario> TbUsuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAB205_14\\SQLEXPRESS;Database=Bd_Biblioteca_Natan;User Id=NatanFonte;Password=natan12345;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbCategoria>(entity =>
        {
            entity.ToTable("TB_CATEGORIAS");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Categoria)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TbEmprestimo>(entity =>
        {
            entity.ToTable("TB_EMPRESTIMOS");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.TbEmprestimo)
                .HasForeignKey<TbEmprestimo>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TB_EMPRESTIMOS_TB_LIVROS");

            entity.HasOne(d => d.Id1).WithOne(p => p.TbEmprestimo)
                .HasForeignKey<TbEmprestimo>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TB_EMPRESTIMOS_TB_MEMBROS");
        });

        modelBuilder.Entity<TbFuncionario>(entity =>
        {
            entity.ToTable("TB_FUNCIONARIOS");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cargo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefone)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TbLivro>(entity =>
        {
            entity.ToTable("TB_LIVROS");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Autor)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Titulo)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.TbLivro)
                .HasForeignKey<TbLivro>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TB_LIVROS_TB_CATEGORIAS");
        });

        modelBuilder.Entity<TbMembro>(entity =>
        {
            entity.ToTable("TB_MEMBROS");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefone)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TipoMembro)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TbReserva>(entity =>
        {
            entity.ToTable("TB_RESERVAS");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.TbReserva)
                .HasForeignKey<TbReserva>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TB_RESERVAS_TB_LIVROS");

            entity.HasOne(d => d.Id1).WithOne(p => p.TbReserva)
                .HasForeignKey<TbReserva>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TB_RESERVAS_TB_MEMBROS");
        });

        modelBuilder.Entity<TbUsuario>(entity =>
        {
            entity.ToTable("TB_USUARIO");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Senha)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Usuario)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
