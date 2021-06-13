using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CineWebApi.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Descuentos",
                columns: table => new
                {
                    IdDescuento = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Tipo = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    PorcientoDeDescuento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Descuentos", x => x.IdDescuento);
                });

            migrationBuilder.CreateTable(
                name: "Pelicula",
                columns: table => new
                {
                    IdPelicula = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Titulo = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Genero = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Pais = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    FechaEstreno = table.Column<DateTime>(type: "date", nullable: true),
                    Duracion = table.Column<TimeSpan>(type: "time(3)", nullable: true),
                    Evaluacion = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pelicula_1", x => x.IdPelicula);
                });

            migrationBuilder.CreateTable(
                name: "Sala",
                columns: table => new
                {
                    IdSala = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Nombre = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    CantidadAsientos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sala", x => x.IdSala);
                });

            migrationBuilder.CreateTable(
                name: "Socios",
                columns: table => new
                {
                    IdSocio = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Apellidos = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Puntos = table.Column<int>(type: "int", nullable: false),
                    CI = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Socios", x => x.IdSocio);
                });

            migrationBuilder.CreateTable(
                name: "Asientos",
                columns: table => new
                {
                    IdAsiento = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Ocupado = table.Column<bool>(type: "bit", nullable: false),
                    IdSala = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Este compo es para tener una representacion del Id de la Sala en la que se encuantra el Asiento ")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asientos", x => x.IdAsiento);
                    table.ForeignKey(
                        name: "FK_Asientos_Sala",
                        column: x => x.IdSala,
                        principalTable: "Sala",
                        principalColumn: "IdSala",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Entrada",
                columns: table => new
                {
                    IdEntrada = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    IdSala = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdAsiento = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdPelicula = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Hora = table.Column<DateTime>(type: "datetime", nullable: false),
                    Precio = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entrada", x => x.IdEntrada);
                    table.ForeignKey(
                        name: "FK_Entrada_Asientos",
                        column: x => x.IdAsiento,
                        principalTable: "Asientos",
                        principalColumn: "IdAsiento",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Entrada_Pelicula",
                        column: x => x.IdPelicula,
                        principalTable: "Pelicula",
                        principalColumn: "IdPelicula",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Entrada_Sala",
                        column: x => x.IdSala,
                        principalTable: "Sala",
                        principalColumn: "IdSala",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Compra",
                columns: table => new
                {
                    IdCompra = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    IdEntrada = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    IdDescuento = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Hora = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdSocio = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compra", x => new { x.IdCompra, x.IdEntrada });
                    table.ForeignKey(
                        name: "FK_Compra_Descuentos1",
                        column: x => x.IdDescuento,
                        principalTable: "Descuentos",
                        principalColumn: "IdDescuento",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Compra_Entrada",
                        column: x => x.IdEntrada,
                        principalTable: "Entrada",
                        principalColumn: "IdEntrada",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asientos_IdSala",
                table: "Asientos",
                column: "IdSala");

            migrationBuilder.CreateIndex(
                name: "IX_Compra_IdDescuento",
                table: "Compra",
                column: "IdDescuento");

            migrationBuilder.CreateIndex(
                name: "IX_Compra_IdEntrada",
                table: "Compra",
                column: "IdEntrada");

            migrationBuilder.CreateIndex(
                name: "IX_Entrada_IdAsiento",
                table: "Entrada",
                column: "IdAsiento");

            migrationBuilder.CreateIndex(
                name: "IX_Entrada_IdPelicula",
                table: "Entrada",
                column: "IdPelicula");

            migrationBuilder.CreateIndex(
                name: "IX_Entrada_IdSala",
                table: "Entrada",
                column: "IdSala");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Compra");

            migrationBuilder.DropTable(
                name: "Socios");

            migrationBuilder.DropTable(
                name: "Descuentos");

            migrationBuilder.DropTable(
                name: "Entrada");

            migrationBuilder.DropTable(
                name: "Asientos");

            migrationBuilder.DropTable(
                name: "Pelicula");

            migrationBuilder.DropTable(
                name: "Sala");
        }
    }
}
