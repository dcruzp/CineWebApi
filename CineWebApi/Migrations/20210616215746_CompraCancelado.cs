using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CineWebApi.Migrations
{
    public partial class CompraCancelado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asientos_Compra_CompraIdCompra",
                table: "Asientos");

            migrationBuilder.DropIndex(
                name: "IX_Asientos_CompraIdCompra",
                table: "Asientos");

            migrationBuilder.DropColumn(
                name: "CompraIdCompra",
                table: "Asientos");

            migrationBuilder.AddColumn<Guid>(
                name: "CompraIdCompra",
                table: "CompraAsientos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Cancelado",
                table: "Compra",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_CompraAsientos_CompraIdCompra",
                table: "CompraAsientos",
                column: "CompraIdCompra");

            migrationBuilder.AddForeignKey(
                name: "FK_CompraAsientos_Compra_CompraIdCompra",
                table: "CompraAsientos",
                column: "CompraIdCompra",
                principalTable: "Compra",
                principalColumn: "IdCompra",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompraAsientos_Compra_CompraIdCompra",
                table: "CompraAsientos");

            migrationBuilder.DropIndex(
                name: "IX_CompraAsientos_CompraIdCompra",
                table: "CompraAsientos");

            migrationBuilder.DropColumn(
                name: "CompraIdCompra",
                table: "CompraAsientos");

            migrationBuilder.DropColumn(
                name: "Cancelado",
                table: "Compra");

            migrationBuilder.AddColumn<Guid>(
                name: "CompraIdCompra",
                table: "Asientos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Asientos_CompraIdCompra",
                table: "Asientos",
                column: "CompraIdCompra");

            migrationBuilder.AddForeignKey(
                name: "FK_Asientos_Compra_CompraIdCompra",
                table: "Asientos",
                column: "CompraIdCompra",
                principalTable: "Compra",
                principalColumn: "IdCompra",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
