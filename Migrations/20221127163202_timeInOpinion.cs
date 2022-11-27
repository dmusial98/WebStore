using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebStore.Migrations
{
    public partial class timeInOpinion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Time",
                table: "Opinions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Opinions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Time",
                value: new DateTime(2021, 2, 20, 14, 57, 21, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Opinions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Time",
                value: new DateTime(2021, 2, 21, 8, 33, 43, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "RefreshTokenExpiryTime",
                value: new DateTime(2022, 11, 27, 17, 32, 2, 418, DateTimeKind.Local).AddTicks(1409));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "RefreshTokenExpiryTime",
                value: new DateTime(2022, 11, 27, 17, 32, 2, 420, DateTimeKind.Local).AddTicks(4812));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Time",
                table: "Opinions");

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
    }
}
