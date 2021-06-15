using Microsoft.EntityFrameworkCore.Migrations;

namespace CineWebApi.Migrations
{
    public partial class numeroAsiento_asiento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumeroAsiento",
                table: "Asientos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumeroAsiento",
                table: "Asientos");
        }
    }
}
