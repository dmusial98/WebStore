using Microsoft.EntityFrameworkCore.Migrations;

namespace WebStore.Migrations
{
    public partial class storemigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Description",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescriptionText = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Description", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AboutUsDescriptionId = table.Column<int>(type: "int", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Store_Description_AboutUsDescriptionId",
                        column: x => x.AboutUsDescriptionId,
                        principalTable: "Description",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StoreEMail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    EmailContent = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreEMail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreEMail_Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StoreHours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<int>(type: "int", nullable: false),
                    OpenHour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CloseHour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StoreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreHours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreHours_Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StoreTelephoneNumber",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    TelephoneNumberContent = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreTelephoneNumber", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreTelephoneNumber_Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Store",
                columns: new[] { "Id", "AboutUsDescriptionId", "Address" },
                values: new object[] { 1, null, "ul. Poziomkowa 88 24-987 Warszawa" });

            migrationBuilder.InsertData(
                table: "StoreEMail",
                columns: new[] { "Id", "EmailContent", "StoreId" },
                values: new object[,]
                {
                    { 1, "good.store@gmail.com", 1 },
                    { 2, "dobry.sklep@gmail.com", 1 }
                });

            migrationBuilder.InsertData(
                table: "StoreHours",
                columns: new[] { "Id", "CloseHour", "Day", "OpenHour", "StoreId" },
                values: new object[,]
                {
                    { 1, "16:00", 1, "8:00", 1 },
                    { 2, "16:00", 2, "8:00", 1 },
                    { 3, "16:00", 3, "8:00", 1 },
                    { 4, "16:00", 4, "8:00", 1 },
                    { 5, "16:00", 5, "8:00", 1 },
                    { 6, "16:00", 6, "8:00", 1 }
                });

            migrationBuilder.InsertData(
                table: "StoreTelephoneNumber",
                columns: new[] { "Id", "StoreId", "TelephoneNumberContent" },
                values: new object[,]
                {
                    { 1, 1, "+48 123 456 789" },
                    { 2, 1, "+48 32 12 36 647" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Store_AboutUsDescriptionId",
                table: "Store",
                column: "AboutUsDescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreEMail_StoreId",
                table: "StoreEMail",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreHours_StoreId",
                table: "StoreHours",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreTelephoneNumber_StoreId",
                table: "StoreTelephoneNumber",
                column: "StoreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StoreEMail");

            migrationBuilder.DropTable(
                name: "StoreHours");

            migrationBuilder.DropTable(
                name: "StoreTelephoneNumber");

            migrationBuilder.DropTable(
                name: "Store");

            migrationBuilder.DropTable(
                name: "Description");
        }
    }
}
