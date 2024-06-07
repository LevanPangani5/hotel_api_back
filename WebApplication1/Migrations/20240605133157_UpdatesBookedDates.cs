using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class UpdatesBookedDates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "Date",
                table: "BookedDates",
                newName: "CheckOut");

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckIn",
                table: "BookedDates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5f0557ac-cef9-4e65-b633-be64fa29c12a", "a4953064-1a05-4872-9786-6683153f7cb3", "User", "USER" },
                    { "649153e2-b3b5-4bce-ab44-8628454123f9", "40aceae6-8b00-4d44-b027-b10dcd873042", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "RoomTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Single Room" },
                    { 2, "Double  Room" },
                    { 3, "Deluxe  Room" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f0557ac-cef9-4e65-b633-be64fa29c12a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "649153e2-b3b5-4bce-ab44-8628454123f9");

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "CheckIn",
                table: "BookedDates");

            migrationBuilder.RenameColumn(
                name: "CheckOut",
                table: "BookedDates",
                newName: "Date");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "133a5bad-8b86-4cd3-8fee-61601fab1e06", "ddf01a34-3ffc-404a-a2e6-873e8a0a8663", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b13da2fd-ab05-4bf4-98b6-7df5a6a512ac", "a6addd31-0a1d-45cf-883d-27294dd4f6ba", "Admin", "ADMIN" });
        }
    }
}
