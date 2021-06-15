﻿// <auto-generated />
using System;
using CineWebApi.DBModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CineWebApi.Migrations
{
    [DbContext(typeof(CineContext))]
    [Migration("20210615041328_numeroAsiento_asiento")]
    partial class numeroAsiento_asiento
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CineWebApi.DBModels.Asiento", b =>
                {
                    b.Property<Guid>("IdAsiento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<Guid>("IdSala")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Este compo es para tener una representacion del Id de la Sala en la que se encuantra el Asiento ");

                    b.Property<int>("NumeroAsiento")
                        .HasColumnType("int");

                    b.Property<bool>("Ocupado")
                        .HasColumnType("bit");

                    b.HasKey("IdAsiento");

                    b.HasIndex("IdSala");

                    b.ToTable("Asientos");
                });

            modelBuilder.Entity("CineWebApi.DBModels.CineUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("CineWebApi.DBModels.Compra", b =>
                {
                    b.Property<Guid>("IdCompra")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<Guid>("IdEntrada")
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<DateTime>("Hora")
                        .HasColumnType("datetime");

                    b.Property<Guid?>("IdDescuento")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdSocio")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdCompra", "IdEntrada");

                    b.HasIndex("IdDescuento");

                    b.HasIndex("IdEntrada");

                    b.ToTable("Compra");
                });

            modelBuilder.Entity("CineWebApi.DBModels.Descuento", b =>
                {
                    b.Property<Guid>("IdDescuento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<int>("PorcientoDeDescuento")
                        .HasColumnType("int");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.HasKey("IdDescuento");

                    b.ToTable("Descuentos");
                });

            modelBuilder.Entity("CineWebApi.DBModels.Entradum", b =>
                {
                    b.Property<Guid>("IdEntrada")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<DateTime>("Hora")
                        .HasColumnType("datetime");

                    b.Property<Guid>("IdAsiento")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdPelicula")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdSala")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Precio")
                        .HasColumnType("money");

                    b.HasKey("IdEntrada");

                    b.HasIndex("IdAsiento");

                    b.HasIndex("IdPelicula");

                    b.HasIndex("IdSala");

                    b.ToTable("Entrada");
                });

            modelBuilder.Entity("CineWebApi.DBModels.Pelicula", b =>
                {
                    b.Property<Guid>("IdPelicula")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<TimeSpan?>("Duracion")
                        .HasColumnType("time(3)");

                    b.Property<double>("Evaluacion")
                        .HasColumnType("float");

                    b.Property<DateTime?>("FechaEstreno")
                        .HasColumnType("date");

                    b.Property<string>("Genero")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Pais")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.HasKey("IdPelicula")
                        .HasName("PK_Pelicula_1");

                    b.ToTable("Pelicula");
                });

            modelBuilder.Entity("CineWebApi.DBModels.Sala", b =>
                {
                    b.Property<Guid>("IdSala")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<int>("CantidadAsientos")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.HasKey("IdSala");

                    b.ToTable("Sala");
                });

            modelBuilder.Entity("CineWebApi.DBModels.Socio", b =>
                {
                    b.Property<Guid>("IdSocio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("CI")
                        .IsRequired()
                        .HasMaxLength(11)
                        .IsUnicode(false)
                        .HasColumnType("varchar(11)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Puntos")
                        .HasColumnType("int");

                    b.HasKey("IdSocio");

                    b.ToTable("Socios");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("CineWebApi.DBModels.Asiento", b =>
                {
                    b.HasOne("CineWebApi.DBModels.Sala", "IdSalaNavigation")
                        .WithMany("Asientos")
                        .HasForeignKey("IdSala")
                        .HasConstraintName("FK_Asientos_Sala")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdSalaNavigation");
                });

            modelBuilder.Entity("CineWebApi.DBModels.Compra", b =>
                {
                    b.HasOne("CineWebApi.DBModels.Descuento", "IdDescuentoNavigation")
                        .WithMany("Compras")
                        .HasForeignKey("IdDescuento")
                        .HasConstraintName("FK_Compra_Descuentos1");

                    b.HasOne("CineWebApi.DBModels.Entradum", "IdEntradaNavigation")
                        .WithMany("Compras")
                        .HasForeignKey("IdEntrada")
                        .HasConstraintName("FK_Compra_Entrada")
                        .IsRequired();

                    b.Navigation("IdDescuentoNavigation");

                    b.Navigation("IdEntradaNavigation");
                });

            modelBuilder.Entity("CineWebApi.DBModels.Entradum", b =>
                {
                    b.HasOne("CineWebApi.DBModels.Asiento", "IdAsientoNavigation")
                        .WithMany("Entrada")
                        .HasForeignKey("IdAsiento")
                        .HasConstraintName("FK_Entrada_Asientos")
                        .IsRequired();

                    b.HasOne("CineWebApi.DBModels.Pelicula", "IdPeliculaNavigation")
                        .WithMany("Entrada")
                        .HasForeignKey("IdPelicula")
                        .HasConstraintName("FK_Entrada_Pelicula")
                        .IsRequired();

                    b.HasOne("CineWebApi.DBModels.Sala", "IdSalaNavigation")
                        .WithMany("Entrada")
                        .HasForeignKey("IdSala")
                        .HasConstraintName("FK_Entrada_Sala")
                        .IsRequired();

                    b.Navigation("IdAsientoNavigation");

                    b.Navigation("IdPeliculaNavigation");

                    b.Navigation("IdSalaNavigation");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("CineWebApi.DBModels.CineUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CineWebApi.DBModels.CineUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CineWebApi.DBModels.CineUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("CineWebApi.DBModels.CineUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CineWebApi.DBModels.Asiento", b =>
                {
                    b.Navigation("Entrada");
                });

            modelBuilder.Entity("CineWebApi.DBModels.Descuento", b =>
                {
                    b.Navigation("Compras");
                });

            modelBuilder.Entity("CineWebApi.DBModels.Entradum", b =>
                {
                    b.Navigation("Compras");
                });

            modelBuilder.Entity("CineWebApi.DBModels.Pelicula", b =>
                {
                    b.Navigation("Entrada");
                });

            modelBuilder.Entity("CineWebApi.DBModels.Sala", b =>
                {
                    b.Navigation("Asientos");

                    b.Navigation("Entrada");
                });
#pragma warning restore 612, 618
        }
    }
}