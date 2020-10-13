using Microsoft.EntityFrameworkCore.Migrations;

namespace WickedAir.Models.Migrations
{
    public partial class verion1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "Rating",
                schema: "dbo",
                table: "Airline",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                schema: "dbo",
                table: "Airline");
        }
    }
}
