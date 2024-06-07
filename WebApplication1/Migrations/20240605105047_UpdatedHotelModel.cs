using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class UpdatedHotelModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "73b87177-18e2-4bf4-9109-0998c53f8fd9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ccb0dd65-e1cf-4dbd-a6f9-ff58b8e47bdf");

            migrationBuilder.RenameColumn(
                name: "featuredImage",
                table: "Hotels",
                newName: "FeaturedImage");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "Hotels",
                newName: "City");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "133a5bad-8b86-4cd3-8fee-61601fab1e06", "ddf01a34-3ffc-404a-a2e6-873e8a0a8663", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b13da2fd-ab05-4bf4-98b6-7df5a6a512ac", "a6addd31-0a1d-45cf-883d-27294dd4f6ba", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "133a5bad-8b86-4cd3-8fee-61601fab1e06");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b13da2fd-ab05-4bf4-98b6-7df5a6a512ac");

            migrationBuilder.RenameColumn(
                name: "FeaturedImage",
                table: "Hotels",
                newName: "featuredImage");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Hotels",
                newName: "city");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "73b87177-18e2-4bf4-9109-0998c53f8fd9", "97153c38-9f6b-4bb0-9615-3149679c0dc9", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ccb0dd65-e1cf-4dbd-a6f9-ff58b8e47bdf", "7e3c88a8-e882-4207-a4f7-d9699748f144", "User", "USER" });
        }
    }
}
