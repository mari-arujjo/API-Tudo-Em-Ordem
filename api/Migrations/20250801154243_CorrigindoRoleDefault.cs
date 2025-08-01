using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class CorrigindoRoleDefault : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1957d639-dcb6-4f31-91aa-424273ec4567");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c1ecb60-8e84-42fd-ab67-ee4fc12ed19d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7498ef6-3bc1-4439-a929-0ef82c315e4b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5470cbca-0026-414a-a24c-72e605af6f65", null, "Mod", "MOD" },
                    { "704556df-9d1d-44ce-80d8-3b3faecf5e24", null, "Adm", "ADM" },
                    { "96293a53-c86e-4e28-a35a-1f4d627bf17b", null, "Default", "DEF" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5470cbca-0026-414a-a24c-72e605af6f65");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "704556df-9d1d-44ce-80d8-3b3faecf5e24");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "96293a53-c86e-4e28-a35a-1f4d627bf17b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1957d639-dcb6-4f31-91aa-424273ec4567", null, "Mod", "MOD" },
                    { "3c1ecb60-8e84-42fd-ab67-ee4fc12ed19d", null, "Adm", "ADM" },
                    { "a7498ef6-3bc1-4439-a929-0ef82c315e4b", null, "Default", "Def" }
                });
        }
    }
}
