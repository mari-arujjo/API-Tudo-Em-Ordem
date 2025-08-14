using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoAtributoNome : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "nome",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "31f5f80a-c870-44bd-9cba-e52c88ad0020", null, "Mod", "MOD" },
                    { "90dae26f-78c5-4d4c-9cf8-2e40d717cde0", null, "Adm", "ADM" },
                    { "991de97d-cea0-46d7-a0b5-89b0a05cf96c", null, "Def", "DEF" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "31f5f80a-c870-44bd-9cba-e52c88ad0020");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "90dae26f-78c5-4d4c-9cf8-2e40d717cde0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "991de97d-cea0-46d7-a0b5-89b0a05cf96c");

            migrationBuilder.DropColumn(
                name: "nome",
                table: "AspNetUsers");

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
    }
}
