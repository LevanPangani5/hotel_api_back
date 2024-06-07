using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class FixBooking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "69b0c901-7c02-49b9-884b-dfdf855f3f03", "f22717c7-f6c1-4884-888f-9a067a334b50", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6e718fad-15c8-49c9-90c7-ce45e01560b7", "e76d99b9-8171-4f59-bf13-6622ab3a159c", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "69b0c901-7c02-49b9-884b-dfdf855f3f03");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e718fad-15c8-49c9-90c7-ce45e01560b7");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7cb947c7-373d-4a6e-a771-137de4c0b631", "824ae6e5-b9f2-4842-bd2b-135b117e593e", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "811b1275-9e19-4c07-b236-84af9cb3e150", "f001fa04-6ecc-45fb-8811-1af4dd45883d", "Admin", "ADMIN" });
        }
    }
}
