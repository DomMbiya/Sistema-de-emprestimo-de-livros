using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SistemaAtualEmprestimo.Models;

public partial class EmprestimoAtualContext : DbContext
{
    public EmprestimoAtualContext()
    {
    }

    public EmprestimoAtualContext(DbContextOptions<EmprestimoAtualContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Tb_Cliente> Tb_Clientes { get; set; }

    public virtual DbSet<Tb_Contacto> Tb_Contactos { get; set; }

    public virtual DbSet<Tb_Devolucao> Tb_Devolucaos { get; set; }

    public virtual DbSet<Tb_Livro> Tb_Livros { get; set; }

    public virtual DbSet<Tb_LivroCliente> Tb_LivroClientes { get; set; }

    public virtual DbSet<Tb_Multum> Tb_Multa { get; set; }

    public virtual DbSet<Tb_Mun> Tb_Muns { get; set; }

    public virtual DbSet<Tb_Pag_Multum> Tb_Pag_Multa { get; set; }

    public virtual DbSet<Tb_Prov> Tb_Provs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=Dom-Mbiya;Initial Catalog=EmprestimoAtual;Integrated Security=True;Trust Server Certificate=True;Command Timeout=300; Encrypt=True;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tb_Cliente>(entity =>
        {
            entity.HasKey(e => e.Id_Cliente).HasName("PK__Tb_Clien__3DD0A8CBA5EBC902");

            entity.ToTable("Tb_Cliente");

            entity.HasIndex(e => e.Bi, "UQ__Tb_Clien__3214B53A383733B5").IsUnique();

            entity.Property(e => e.Bi)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Cod_MunNavigation).WithMany(p => p.Tb_Clientes)
                .HasForeignKey(d => d.Cod_Mun)
                .HasConstraintName("FK__Tb_Client__Cod_M__3D5E1FD2");
        });

        modelBuilder.Entity<Tb_Contacto>(entity =>
        {
            entity.HasKey(e => new { e.Id_Cliente, e.Contacto }).HasName("PK__Tb_Conta__E12E6CC7ECB4DCC9");

            entity.ToTable("Tb_Contacto");

            entity.Property(e => e.Contacto)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Id_ClienteNavigation).WithMany(p => p.Tb_Contactos)
                .HasForeignKey(d => d.Id_Cliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tb_Contac__Id_Cl__403A8C7D");
        });

        modelBuilder.Entity<Tb_Devolucao>(entity =>
        {
            entity.HasKey(e => e.Id_Devolucao).HasName("PK__Tb_Devol__2C3880D5C9300D0B");

            entity.ToTable("Tb_Devolucao");

            entity.Property(e => e.data_entregue)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");

            entity.HasOne(d => d.Id_LivroClienteNavigation).WithMany(p => p.Tb_Devolucaos)
                .HasForeignKey(d => d.Id_LivroCliente)
                .HasConstraintName("FK__Tb_Devolu__Id_Li__4D94879B");
        });

        modelBuilder.Entity<Tb_Livro>(entity =>
        {
            entity.HasKey(e => e.Id_Livro).HasName("PK__Tb_Livro__FE973F5BEF0916CD");

            entity.ToTable("Tb_Livro");

            entity.Property(e => e.Autor)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Edicao).HasDefaultValueSql("('1')");
            entity.Property(e => e.Editora)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.data_criacao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
            entity.Property(e => e.data_lancamento).HasColumnType("date");
            entity.Property(e => e.estado).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<Tb_LivroCliente>(entity =>
        {
            entity.HasKey(e => e.Id_LivroCliente).HasName("PK__Tb_Livro__4CACFD64EAEC2C18");

            entity.ToTable("Tb_LivroCliente");

            entity.Property(e => e.data_devolucao).HasColumnType("date");
            entity.Property(e => e.data_emprestimo)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
            entity.Property(e => e.entregue)
                .IsRequired()
                .HasDefaultValueSql("('false')");

            entity.HasOne(d => d.Id_ClienteNavigation).WithMany(p => p.Tb_LivroClientes)
                .HasForeignKey(d => d.Id_Cliente)
                .HasConstraintName("FK__Tb_LivroC__Id_Cl__49C3F6B7");

            entity.HasOne(d => d.Id_LivroNavigation).WithMany(p => p.Tb_LivroClientes)
                .HasForeignKey(d => d.Id_Livro)
                .HasConstraintName("FK__Tb_LivroC__Id_Li__48CFD27E");
        });

        modelBuilder.Entity<Tb_Multum>(entity =>
        {
            entity.HasKey(e => e.Id_Multa).HasName("PK__Tb_Multa__F56FD2450455E2C2");

            entity.Property(e => e.Valor)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Tb_Mun>(entity =>
        {
            entity.HasKey(e => e.Cod_Mun).HasName("PK__Tb_Mun__0583E5B4B1665CF8");

            entity.ToTable("Tb_Mun");

            entity.Property(e => e.Municipio)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Cod_ProvNavigation).WithMany(p => p.Tb_Muns)
                .HasForeignKey(d => d.Cod_Prov)
                .HasConstraintName("FK__Tb_Mun__Cod_Prov__398D8EEE");
        });

        modelBuilder.Entity<Tb_Pag_Multum>(entity =>
        {
            entity.HasKey(e => e.Id_Pag_Multa).HasName("PK__Tb_Pag_M__7DBE7B1A1952095A");

            entity.Property(e => e.Estado).HasDefaultValueSql("('false')");
            entity.Property(e => e.data_pag_multa)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");

            entity.HasOne(d => d.Id_DevolucaoNavigation).WithMany(p => p.Tb_Pag_Multa)
                .HasForeignKey(d => d.Id_Devolucao)
                .HasConstraintName("FK__Tb_Pag_Mu__Id_De__5441852A");

            entity.HasOne(d => d.Id_MultaNavigation).WithMany(p => p.Tb_Pag_Multa)
                .HasForeignKey(d => d.Id_Multa)
                .HasConstraintName("FK__Tb_Pag_Mu__Id_Mu__52593CB8");
        });

        modelBuilder.Entity<Tb_Prov>(entity =>
        {
            entity.HasKey(e => e.Cod_Prov).HasName("PK__Tb_Prov__5F08C422CDB0F7AD");

            entity.ToTable("Tb_Prov");

            entity.Property(e => e.Provincia)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingGeneratedProcedures(modelBuilder);
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
