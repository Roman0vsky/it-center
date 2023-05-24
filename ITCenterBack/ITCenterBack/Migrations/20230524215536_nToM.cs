using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITCenterBack.Migrations
{
    public partial class nToM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Times_Applications_ApplicationId",
                table: "Times");

            migrationBuilder.DropIndex(
                name: "IX_Times_ApplicationId",
                table: "Times");

            migrationBuilder.DropColumn(
                name: "ApplicationId",
                table: "Times");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Applications");

            migrationBuilder.AddColumn<bool>(
                name: "IsAvaliable",
                table: "AvaliableTimes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "ApplicationTimes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationId = table.Column<long>(type: "bigint", nullable: false),
                    TimeId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationTimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationTimes_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationTimes_Times_TimeId",
                        column: x => x.TimeId,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseApplications",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationId = table.Column<long>(type: "bigint", nullable: false),
                    CourseId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseApplications_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseApplications_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ConcurrencyStamp",
                value: "fa4d53f9-3598-4d62-957d-7573dc154f96");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "92b9b757-4866-4fe9-bcc5-27e5cf94dfeb", "AQAAAAEAACcQAAAAEGgzoF4pE76dETGXuXiyU358zFUIS8E/Ry6oew/gYarZQbwq33m4375ErzOYdBYNYw==" });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationTimes_ApplicationId",
                table: "ApplicationTimes",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationTimes_TimeId",
                table: "ApplicationTimes",
                column: "TimeId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseApplications_ApplicationId",
                table: "CourseApplications",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseApplications_CourseId",
                table: "CourseApplications",
                column: "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationTimes");

            migrationBuilder.DropTable(
                name: "CourseApplications");

            migrationBuilder.DropColumn(
                name: "IsAvaliable",
                table: "AvaliableTimes");

            migrationBuilder.AddColumn<long>(
                name: "ApplicationId",
                table: "Times",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.CreateIndex(
                name: "IX_Times_ApplicationId",
                table: "Times",
                column: "ApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Times_Applications_ApplicationId",
                table: "Times",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "Id");
        }
    }
}
