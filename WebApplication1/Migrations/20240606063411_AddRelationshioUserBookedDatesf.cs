using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class AddRelationshioUserBookedDatesf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4fc141f8-8aed-463b-a8a1-63528bfe34d0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54b2362b-a2c2-441a-8116-fab4ca249023");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "313a48eb-2bfa-447a-8fdb-8844603e94a8", "4a73bf6a-1875-4297-a95b-2e1272cb3ba0", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "39c2d7aa-94ee-43ef-8dc0-1b74aec9869a", "2bf1170c-1e91-40db-b178-3eb658c41f9a", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "313a48eb-2bfa-447a-8fdb-8844603e94a8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39c2d7aa-94ee-43ef-8dc0-1b74aec9869a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4fc141f8-8aed-463b-a8a1-63528bfe34d0", "139ddfa7-0f4f-44fc-8cdc-1a9004994463", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "54b2362b-a2c2-441a-8116-fab4ca249023", "e9bc7414-9b6b-4b56-9f05-d49106b3590c", "Admin", "ADMIN" });
        }
    }
}
