using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebStore.Migrations
{
    public partial class refreshtoken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "RefreshTokenExpiryTime",
                value: new DateTime(2021, 12, 20, 13, 21, 46, 653, DateTimeKind.Local).AddTicks(7283));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "RefreshTokenExpiryTime",
                value: new DateTime(2021, 12, 20, 13, 21, 46, 660, DateTimeKind.Local).AddTicks(9502));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "Users");
        }
    }
}
