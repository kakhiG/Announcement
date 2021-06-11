using Microsoft.EntityFrameworkCore.Migrations;

namespace Items.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    MobileNumber = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Description", "MobileNumber", "Title" },
                values: new object[] { 1, "good camera nokia phone", "9919291", "Mobile Phone " });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Description", "MobileNumber", "Title" },
                values: new object[] { 2, "new audi car ", "121212", "Car " });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Description", "MobileNumber", "Title" },
                values: new object[] { 3, "new xbox ", "121212", "Game Console" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Description", "MobileNumber", "Title" },
                values: new object[] { 4, "19th century table ", "121212", "Antique" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Description", "MobileNumber", "Title" },
                values: new object[] { 5, "4 floor house in village ", "121212", "New House" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Description", "MobileNumber", "Title" },
                values: new object[] { 6, "new mercedes-benz car ", "121212", "Car Selling" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
