using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

#nullable disable

namespace CineWebApi.DBModels
{
    public partial class CineContext:IdentityDbContext<CineUser>
    {
        public CineContext()
        {
        }

        public CineContext(DbContextOptions<CineContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CompraAsientos> CompraAsientos { get; set;  }
        public virtual DbSet<Asiento> Asientos { get; set; }
        public virtual DbSet<Compra> Compras { get; set; }
        public virtual DbSet<Descuento> Descuentos { get; set; }
        public virtual DbSet<Entradas> Entrada { get; set; }
        public virtual DbSet<Pelicula> Peliculas { get; set; }
        public virtual DbSet<Sala> Salas { get; set; }
        public virtual DbSet<Socio> Socios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=DESKTOP-5FBAI0E;Initial Catalog=Cine; Integrated Security=true");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Asiento>(entity =>
            {
                entity.HasKey(e => e.IdAsiento);

                entity.Property(e => e.IdAsiento).HasDefaultValueSql("(newid())");

                entity.Property(e => e.IdSala).HasComment("Este campo es para tener una representacion del Id de la Sala en la que se encuantra el Asiento ");

                entity.HasOne(d => d.IdSalaNavigation)
                    .WithMany(p => p.Asientos)
                    .HasForeignKey(d => d.IdSala)
                    .HasConstraintName("FK_Asientos_Sala");
            });

            modelBuilder.Entity<Compra>(entity =>
            {
                entity.HasKey(e => new { e.IdCompra });

                entity.ToTable("Compra");

                entity.Property(e => e.IdCompra).HasDefaultValueSql("(newid())");


                entity.Property(e => e.Hora).HasColumnType("datetime");

               

                entity.HasOne(d => d.IdEntradaNavigation)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.IdEntrada)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Compra_Entrada");
                

            });

            modelBuilder.Entity<Descuento>(entity =>
            {
                entity.HasKey(e => e.IdDescuento);

                entity.Property(e => e.IdDescuento).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CompraAsientos>(entity =>
                {
                    entity.HasKey(x => x.IdCompra);

                    entity.HasKey(x => x.IdAsiento);

                    entity.HasOne(d => d.IdAsientoNavigational);
                        
                    
                });

            modelBuilder.Entity<Entradas>(entity =>
            {
                entity.HasKey(e => e.IdEntrada);

                entity.Property(e => e.IdEntrada).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Hora).HasColumnType("datetime");

                entity.Property(e => e.Precio).HasColumnType("money");
                             
                entity.HasOne(d => d.IdPeliculaNavigation)
                    .WithMany(p => p.Entrada)
                    .HasForeignKey(d => d.IdPelicula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Entrada_Pelicula");

                entity.HasOne(d => d.IdSalaNavigation)
                    .WithMany(p => p.Entrada)
                    .HasForeignKey(d => d.IdSala)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Entrada_Sala");
            });

            modelBuilder.Entity<Pelicula>(entity =>
            {
                entity.HasKey(e => e.IdPelicula)
                    .HasName("PK_Pelicula_1");

                entity.ToTable("Pelicula");

                entity.Property(e => e.IdPelicula).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Duracion).HasColumnType("time(3)");

                entity.Property(e => e.FechaEstreno).HasColumnType("date");

                entity.Property(e => e.Genero)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pais)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sala>(entity =>
            {
                entity.HasKey(e => e.IdSala);

                entity.ToTable("Sala");

                entity.Property(e => e.IdSala).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Socio>(entity =>
            {
                entity.HasKey(e => e.IdSocio);

                entity.Property(e => e.IdSocio).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CI)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
