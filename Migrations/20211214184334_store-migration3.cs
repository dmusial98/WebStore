using Microsoft.EntityFrameworkCore.Migrations;

namespace WebStore.Migrations
{
    public partial class storemigration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Store_Description_AboutUsDescriptionId",
                table: "Store");

            migrationBuilder.DropTable(
                name: "Description");

            migrationBuilder.DropIndex(
                name: "IX_Store_AboutUsDescriptionId",
                table: "Store");

            migrationBuilder.DropColumn(
                name: "AboutUsDescriptionId",
                table: "Store");

            migrationBuilder.CreateTable(
                name: "StoreDescription",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    DescriptionText = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreDescription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreDescription_Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "StoreDescription",
                columns: new[] { "Id", "DescriptionText", "StoreId" },
                values: new object[] { 1, "Nasz sklep zajmuje się sprzedażą sprzętu sportowego, mamy wieloletnie doświadczeniue w dostosowywaniu oferty do potrzeb klienta.", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_StoreDescription_StoreId",
                table: "StoreDescription",
                column: "StoreId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StoreDescription");

            migrationBuilder.AddColumn<int>(
                name: "AboutUsDescriptionId",
                table: "Store",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Store_AboutUsDescriptionId",
                table: "Store",
                column: "AboutUsDescriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Store_Description_AboutUsDescriptionId",
                table: "Store",
                column: "AboutUsDescriptionId",
                principalTable: "Description",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
