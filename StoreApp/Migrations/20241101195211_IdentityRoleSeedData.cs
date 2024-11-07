using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreApp.Migrations
{
    public partial class IdentityRoleSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6f92bbf2-1dbb-40a2-a925-57545c888762", "9d0b3160-569e-4c24-b077-ca192a2c18ae", "Editor", "EDITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "966b67c8-ebfb-4a21-846e-aefde7553ff9", "79a1f330-2e50-47cb-a817-6238228467fd", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e0ab8e77-5cd5-4bd0-a6a9-27a67282ea29", "fee00804-dbc8-410d-b2f6-c7da4f3a48be", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6f92bbf2-1dbb-40a2-a925-57545c888762");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "966b67c8-ebfb-4a21-846e-aefde7553ff9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e0ab8e77-5cd5-4bd0-a6a9-27a67282ea29");
        }
    }
}
