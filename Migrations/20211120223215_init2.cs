using Microsoft.EntityFrameworkCore.Migrations;

namespace WebStore.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Opinions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CriticId",
                value: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Opinions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CriticId",
                value: null);
        }
    }
}
