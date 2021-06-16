using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CineWebApi.Migrations
{
    public partial class Compras_Asientos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entrada_Asientos",
                table: "Entrada");

            migrationBuilder.DropIndex(
                name: "IX_Entrada_IdAsiento",
                table: "Entrada");

            migrationBuilder.DropColumn(
                name: "IdAsiento",
                table: "Entrada");

            migrationBuilder.AddColumn<Guid>(
                name: "AsientoIdAsiento",
                table: "Entrada",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdAsientoNavigationIdAsiento",
                table: "Compra",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Entrada_AsientoIdAsiento",
                table: "Entrada",
                column: "AsientoIdAsiento");

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
                name: "FK_Entrada_Asientos_AsientoIdAsiento",
                table: "Entrada",
                column: "AsientoIdAsiento",
                principalTable: "Asientos",
                principalColumn: "IdAsiento",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compra_Asientos_IdAsientoNavigationIdAsiento",
                table: "Compra");

            migrationBuilder.DropForeignKey(
                name: "FK_Entrada_Asientos_AsientoIdAsiento",
                table: "Entrada");

            migrationBuilder.DropIndex(
                name: "IX_Entrada_AsientoIdAsiento",
                table: "Entrada");

            migrationBuilder.DropIndex(
                name: "IX_Compra_IdAsientoNavigationIdAsiento",
                table: "Compra");

            migrationBuilder.DropColumn(
                name: "AsientoIdAsiento",
                table: "Entrada");

            migrationBuilder.DropColumn(
                name: "IdAsientoNavigationIdAsiento",
                table: "Compra");

            migrationBuilder.AddColumn<Guid>(
                name: "IdAsiento",
                table: "Entrada",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Entrada_IdAsiento",
                table: "Entrada",
                column: "IdAsiento");

            migrationBuilder.AddForeignKey(
                name: "FK_Entrada_Asientos",
                table: "Entrada",
                column: "IdAsiento",
                principalTable: "Asientos",
                principalColumn: "IdAsiento",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
