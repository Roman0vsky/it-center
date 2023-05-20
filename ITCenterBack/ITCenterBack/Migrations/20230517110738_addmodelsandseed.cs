using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITCenterBack.Migrations
{
    public partial class addmodelsandseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Day",
                table: "Times");

            migrationBuilder.DropColumn(
                name: "IsAvaliable",
                table: "Times");

            migrationBuilder.CreateTable(
                name: "AvaliableTimes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<int>(type: "int", nullable: false),
                    TimeId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvaliableTimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvaliableTimes_Times_TimeId",
                        column: x => x.TimeId,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SliderImages",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SliderImages", x => x.Id);
                });

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

            migrationBuilder.InsertData(
                table: "SliderImages",
                columns: new[] { "Id", "Image" },
                values: new object[,]
                {
                    { 1L, "/assets/for_new/img/home-clubs/2.jpg" },
                    { 2L, "/assets/for_new/img/home-clubs/3.jpg" },
                    { 3L, "/assets/for_new/img/home-clubs/4.jpg" },
                    { 4L, "/assets/for_new/img/home-clubs/5.jpg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AvaliableTimes_TimeId",
                table: "AvaliableTimes",
                column: "TimeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvaliableTimes");

            migrationBuilder.DropTable(
                name: "SliderImages");

            migrationBuilder.AddColumn<int>(
                name: "Day",
                table: "Times",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsAvaliable",
                table: "Times",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ConcurrencyStamp",
                value: "8fa351fe-3571-496c-9070-f4e66105d198");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fb2785c2-a7c9-46e0-9ddb-d161a68d7794", "AQAAAAEAACcQAAAAEL7xAj4xkw9vlCX1MkO2q40Xsu5dnFM7mi3SIsQQB061jcazJz+r81/GqbumaPSTCg==" });
        }
    }
}
