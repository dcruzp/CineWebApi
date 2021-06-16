using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CineWebApi.Migrations
{
    public partial class DirectionFotoToPelicula : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compra_Asientos_IdAsientoNavigationIdAsiento",
                table: "Compra");

            migrationBuilder.DropForeignKey(
                name: "FK_Compra_Descuentos1",
                table: "Compra");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Compra",
                table: "Compra");

            migrationBuilder.DropIndex(
                name: "IX_Compra_IdAsientoNavigationIdAsiento",
                table: "Compra");

            migrationBuilder.DropColumn(
                name: "IdAsientoNavigationIdAsiento",
                table: "Compra");

            migrationBuilder.DropColumn(
                name: "Ocupado",
                table: "Asientos");

            migrationBuilder.RenameColumn(
                name: "IdDescuento",
                table: "Compra",
                newName: "DescuentoIdDescuento");

            migrationBuilder.RenameIndex(
                name: "IX_Compra_IdDescuento",
                table: "Compra",
                newName: "IX_Compra_DescuentoIdDescuento");

            migrationBuilder.AddColumn<string>(
                name: "DireccionFoto",
                table: "Pelicula",
                type: "varchar(250)",
                unicode: false,
                maxLength: 250,
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "IdEntrada",
                table: "Compra",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "(newid())");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdSala",
                table: "Asientos",
                type: "uniqueidentifier",
                nullable: false,
                comment: "Este campo es para tener una representacion del Id de la Sala en la que se encuantra el Asiento ",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Este compo es para tener una representacion del Id de la Sala en la que se encuantra el Asiento ");

            migrationBuilder.AddColumn<Guid>(
                name: "CompraIdCompra",
                table: "Asientos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "Asientos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Compra",
                table: "Compra",
                column: "IdCompra");

            migrationBuilder.CreateTable(
                name: "CompraAsientos",
                columns: table => new
                {
                    IdAsiento = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCompra = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdDescuento = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdDescuentoNavigationalIdDescuento = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdAsientoNavigationalIdAsiento = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdCompraNavigationalIdDescuento = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompraAsientos", x => x.IdAsiento);
                    table.ForeignKey(
                        name: "FK_CompraAsientos_Asientos_IdAsientoNavigationalIdAsiento",
                        column: x => x.IdAsientoNavigationalIdAsiento,
                        principalTable: "Asientos",
                        principalColumn: "IdAsiento",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompraAsientos_Descuentos_IdCompraNavigationalIdDescuento",
                        column: x => x.IdCompraNavigationalIdDescuento,
                        principalTable: "Descuentos",
                        principalColumn: "IdDescuento",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompraAsientos_Descuentos_IdDescuentoNavigationalIdDescuento",
                        column: x => x.IdDescuentoNavigationalIdDescuento,
                        principalTable: "Descuentos",
                        principalColumn: "IdDescuento",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asientos_CompraIdCompra",
                table: "Asientos",
                column: "CompraIdCompra");

            migrationBuilder.CreateIndex(
                name: "IX_CompraAsientos_IdAsientoNavigationalIdAsiento",
                table: "CompraAsientos",
                column: "IdAsientoNavigationalIdAsiento");

            migrationBuilder.CreateIndex(
                name: "IX_CompraAsientos_IdCompraNavigationalIdDescuento",
                table: "CompraAsientos",
                column: "IdCompraNavigationalIdDescuento");

            migrationBuilder.CreateIndex(
                name: "IX_CompraAsientos_IdDescuentoNavigationalIdDescuento",
                table: "CompraAsientos",
                column: "IdDescuentoNavigationalIdDescuento");

            migrationBuilder.AddForeignKey(
                name: "FK_Asientos_Compra_CompraIdCompra",
                table: "Asientos",
                column: "CompraIdCompra",
                principalTable: "Compra",
                principalColumn: "IdCompra",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Compra_Descuentos_DescuentoIdDescuento",
                table: "Compra",
                column: "DescuentoIdDescuento",
                principalTable: "Descuentos",
                principalColumn: "IdDescuento",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asientos_Compra_CompraIdCompra",
                table: "Asientos");

            migrationBuilder.DropForeignKey(
                name: "FK_Compra_Descuentos_DescuentoIdDescuento",
                table: "Compra");

            migrationBuilder.DropTable(
                name: "CompraAsientos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Compra",
                table: "Compra");

            migrationBuilder.DropIndex(
                name: "IX_Asientos_CompraIdCompra",
                table: "Asientos");

            migrationBuilder.DropColumn(
                name: "DireccionFoto",
                table: "Pelicula");

            migrationBuilder.DropColumn(
                name: "CompraIdCompra",
                table: "Asientos");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Asientos");

            migrationBuilder.RenameColumn(
                name: "DescuentoIdDescuento",
                table: "Compra",
                newName: "IdDescuento");

            migrationBuilder.RenameIndex(
                name: "IX_Compra_DescuentoIdDescuento",
                table: "Compra",
                newName: "IX_Compra_IdDescuento");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdEntrada",
                table: "Compra",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "(newid())",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "IdAsientoNavigationIdAsiento",
                table: "Compra",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "IdSala",
                table: "Asientos",
                type: "uniqueidentifier",
                nullable: false,
                comment: "Este compo es para tener una representacion del Id de la Sala en la que se encuantra el Asiento ",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Este campo es para tener una representacion del Id de la Sala en la que se encuantra el Asiento ");

            migrationBuilder.AddColumn<bool>(
                name: "Ocupado",
                table: "Asientos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Compra",
                table: "Compra",
                columns: new[] { "IdCompra", "IdEntrada" });

            migrationBuilder.CreateIndex(
                name: "IX_Compra_IdAsientoNavigationIdAsiento",
                table: "Compra",
                column: "IdAsientoNavigationIdAsiento");

            migrationBuilder.AddForeignKey(
                name: "FK_Compra_Asientos_IdAsientoNavigationIdAsiento",
                table: "Compra",
                column: "IdAsientoNavigationIdAsiento",
                principalTable: "Asientos",
                principalColumn: "IdAsiento",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Compra_Descuentos1",
                table: "Compra",
                column: "IdDescuento",
                principalTable: "Descuentos",
                principalColumn: "IdDescuento",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
