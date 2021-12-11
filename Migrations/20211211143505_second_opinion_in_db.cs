using Microsoft.EntityFrameworkCore.Migrations;

namespace WebStore.Migrations
{
    public partial class second_opinion_in_db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Opinions",
                columns: new[] { "Id", "Content", "CriticId", "ProductId", "Value" },
                values: new object[] { 2, "Wszystko w jak największym porządku", 1, 1, 5 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Opinions",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
