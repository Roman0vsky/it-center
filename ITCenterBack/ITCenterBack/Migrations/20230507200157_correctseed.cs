using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITCenterBack.Migrations
{
    public partial class correctseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ConcurrencyStamp",
                value: "ac7eff10-9dc5-4128-8ff3-3eac3b34a696");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "UserName" },
                values: new object[] { "805ee9ed-02e7-4ac3-9835-33a91fd8f88c", "AQAAAAEAACcQAAAAEGA1Rs9QE0IXvNzDe8Wxc92Cf0hzdAZOi73CJdbcLoZXAmaPFjMC4GaplJhxY0CvOQ==", "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ConcurrencyStamp",
                value: "5bcc7acd-3b31-4ef1-8b34-fe5e62c9ca12");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "UserName" },
                values: new object[] { "525c77b5-6fe3-49ea-8f8b-692045671a10", "AQAAAAEAACcQAAAAEMs82jvACEkMuiiSV5aowMOUEezUrDPkgpTptpBQRgkjReSdhz65Sv2+easAjgIcYQ==", null });
        }
    }
}
