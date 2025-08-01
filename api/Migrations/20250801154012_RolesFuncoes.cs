using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class RolesFuncoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "nivel_acesso",
                table: "AspNetUsers");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "nivel_acesso",
                table: "AspNetUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
