using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebStore.Migrations
{
    public partial class categoriesnamepaths : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NamePath",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "NamePath",
                value: "Stoly-do-gry");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "NamePath",
                value: "Okladziny");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "RefreshTokenExpiryTime",
                value: new DateTime(2022, 1, 6, 0, 20, 21, 762, DateTimeKind.Local).AddTicks(2742));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "RefreshTokenExpiryTime",
                value: new DateTime(2022, 1, 6, 0, 20, 21, 765, DateTimeKind.Local).AddTicks(4721));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NamePath",
                table: "Categories");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "RefreshTokenExpiryTime",
                value: new DateTime(2021, 12, 26, 0, 41, 36, 286, DateTimeKind.Local).AddTicks(1304));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "RefreshTokenExpiryTime",
                value: new DateTime(2021, 12, 26, 0, 41, 36, 288, DateTimeKind.Local).AddTicks(6794));
        }
    }
}
