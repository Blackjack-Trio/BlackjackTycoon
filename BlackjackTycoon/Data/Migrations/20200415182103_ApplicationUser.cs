using Microsoft.EntityFrameworkCore.Migrations;

namespace BlackjackTycoon.Data.Migrations
{
    public partial class ApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Bankroll",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<decimal>(
                name: "Borrowed",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Borrowed",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "Bankroll",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
