using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreApp.Migrations
{
    public partial class mig_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Price", "ProductName" },
                values: new object[] { 1, 17000m, "Computer" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Price", "ProductName" },
                values: new object[] { 2, 1000m, "Keyboard" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Price", "ProductName" },
                values: new object[] { 3, 500m, "Mouse" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Price", "ProductName" },
                values: new object[] { 4, 3700m, "Monitor" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Price", "ProductName" },
                values: new object[] { 5, 2000m, "Head Set" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
