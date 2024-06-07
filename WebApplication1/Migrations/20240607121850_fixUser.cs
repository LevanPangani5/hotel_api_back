using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class fixUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "7cb947c7-373d-4a6e-a771-137de4c0b631", "824ae6e5-b9f2-4842-bd2b-135b117e593e", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "811b1275-9e19-4c07-b236-84af9cb3e150", "f001fa04-6ecc-45fb-8811-1af4dd45883d", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7cb947c7-373d-4a6e-a771-137de4c0b631");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "811b1275-9e19-4c07-b236-84af9cb3e150");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "313a48eb-2bfa-447a-8fdb-8844603e94a8", "4a73bf6a-1875-4297-a95b-2e1272cb3ba0", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "39c2d7aa-94ee-43ef-8dc0-1b74aec9869a", "2bf1170c-1e91-40db-b178-3eb658c41f9a", "User", "USER" });
        }
    }
}
