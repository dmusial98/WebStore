using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebStore.Migrations
{
    public partial class productnamepath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NamePath",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "NamePath",
                value: "rakietki");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "NamePath",
                value: "stoly-do-gry");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "NamePath",
                value: "okladziny");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "NamePath",
                value: "deski");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "NamePath",
                value: "rakietka-donic-waldner-2000");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "NamePath",
                value: "stol-do-tenisa-stolowego-joma-3250");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "RefreshTokenExpiryTime",
                value: new DateTime(2022, 1, 6, 23, 34, 53, 551, DateTimeKind.Local).AddTicks(2109));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "RefreshTokenExpiryTime",
                value: new DateTime(2022, 1, 6, 23, 34, 53, 554, DateTimeKind.Local).AddTicks(4764));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NamePath",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "NamePath",
                value: null);

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
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "NamePath",
                value: null);

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
    }
}
