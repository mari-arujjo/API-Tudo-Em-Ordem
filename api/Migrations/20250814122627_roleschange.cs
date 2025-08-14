using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class roleschange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "0ec2ca54-a0e6-4ac8-b151-7e26bd1cf645", null, "Def", "DEF" },
                    { "2e3458a9-33b1-4cee-a94e-160ae79b1407", null, "Mod", "MOD" },
                    { "d3fdd23a-5434-4480-85b7-42846b2c49a0", null, "Adm", "ADM" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0ec2ca54-a0e6-4ac8-b151-7e26bd1cf645");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2e3458a9-33b1-4cee-a94e-160ae79b1407");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d3fdd23a-5434-4480-85b7-42846b2c49a0");

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
    }
}
