using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITCenterBack.Migrations
{
    public partial class fixedtime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeInterval",
                table: "Times");

            migrationBuilder.AddColumn<DateTime>(
                name: "From",
                table: "Times",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "To",
                table: "Times",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ConcurrencyStamp",
                value: "03af7ec9-e4c1-40d8-902c-4f0f0745af4f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8996ee65-ca7e-4d2a-b46c-668280e39e8f", "AQAAAAEAACcQAAAAELCOjxmL7rSI5fUJi3s80AHfP35t+hns/v/Kds0pgk2nFRbgpjLeRVb5SrUGrP2YYw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "From",
                table: "Times");

            migrationBuilder.DropColumn(
                name: "To",
                table: "Times");

            migrationBuilder.AddColumn<string>(
                name: "TimeInterval",
                table: "Times",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ConcurrencyStamp",
                value: "009020e8-c2bb-43d1-85e7-8d581365128a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0bf5e467-7248-47ad-b575-238689e6306f", "AQAAAAEAACcQAAAAEDvKrN7hNnBUhu1H4oPP6FIOzCkw3ykh+rkiP/x5vFch6pOCpshRPkd0uYa9MTabxg==" });
        }
    }
}
