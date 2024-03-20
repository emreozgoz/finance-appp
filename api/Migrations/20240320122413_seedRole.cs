using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class seedRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "126eedbe-37d7-4040-9c55-c841518b3aa4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca8f5d0d-e5fe-4c86-9eac-bc01c7b5565a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "21eec3ce-1dc1-453b-94e2-d1ffb4545c00", null, "User", "USER" },
                    { "bd654c60-1478-4d5a-aa66-a0866e315ade", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "21eec3ce-1dc1-453b-94e2-d1ffb4545c00");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd654c60-1478-4d5a-aa66-a0866e315ade");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "126eedbe-37d7-4040-9c55-c841518b3aa4", null, "User", "ADMIN" },
                    { "ca8f5d0d-e5fe-4c86-9eac-bc01c7b5565a", null, "Admin", "ADMIN" }
                });
        }
    }
}
