using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class AddRelationshioUserBookedDates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f0557ac-cef9-4e65-b633-be64fa29c12a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "649153e2-b3b5-4bce-ab44-8628454123f9");

            migrationBuilder.AddColumn<bool>(
                name: "IsConfirmed",
                table: "BookedDates",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "BookedDates",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4fc141f8-8aed-463b-a8a1-63528bfe34d0", "139ddfa7-0f4f-44fc-8cdc-1a9004994463", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "54b2362b-a2c2-441a-8116-fab4ca249023", "e9bc7414-9b6b-4b56-9f05-d49106b3590c", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_BookedDates_UserId",
                table: "BookedDates",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookedDates_AspNetUsers_UserId",
                table: "BookedDates",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookedDates_AspNetUsers_UserId",
                table: "BookedDates");

            migrationBuilder.DropIndex(
                name: "IX_BookedDates_UserId",
                table: "BookedDates");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4fc141f8-8aed-463b-a8a1-63528bfe34d0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54b2362b-a2c2-441a-8116-fab4ca249023");

            migrationBuilder.DropColumn(
                name: "IsConfirmed",
                table: "BookedDates");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BookedDates");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5f0557ac-cef9-4e65-b633-be64fa29c12a", "a4953064-1a05-4872-9786-6683153f7cb3", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "649153e2-b3b5-4bce-ab44-8628454123f9", "40aceae6-8b00-4d44-b027-b10dcd873042", "Admin", "ADMIN" });
        }
    }
}
