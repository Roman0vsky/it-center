using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITCenterBack.Migrations
{
    public partial class dataseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AboutUs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutUs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Info",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SliderBigText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SliderSmallText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameOfTheCenter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeaderLogo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FooterLogo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameOfUniversity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdressOfUniversity = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Info", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AboutUs",
                columns: new[] { "Id", "Description", "Url" },
                values: new object[] { 1L, "<span class=\"formula\">IT-центр</span> - открывает детям двери в мир IT, не забывая об их росте как личности и прививая им важные социальные ценности. Мы больше, чем просто компьютерные курсы для детей. Мы предоставляем не только обучение программированию или робототехнике, но и все возможности для роста, общения и развития.<br>\r\n<span class=\"formula\">IT-центр</span> - стиль жизни и образ мышления, среда роста и творчества. Современный рынок цифровых продуктов - это уже не поле для деятельности специалистов-одиночек, это полигон борьбы глобальных проектов. Мы готовим специалистов, нацеленных на командную работу и общий успех!\r\n                                        ", "https://www.youtube.com/embed/KrreehNgcgA" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ConcurrencyStamp",
                value: "b2c180f6-33bf-4116-86d0-fd9742130bb1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a8d26fdb-90c4-45a5-b5cb-a4fdb47dc6dc", "AQAAAAEAACcQAAAAEIwUL4+bhVfVfqbZcafM/ibdBXgm+JOt+pOchkyN4b2X+9lrSWBgothH1dqhr+CF3A==" });

            migrationBuilder.InsertData(
                table: "Info",
                columns: new[] { "Id", "AdressOfUniversity", "FooterLogo", "HeaderLogo", "NameOfTheCenter", "NameOfUniversity", "SliderBigText", "SliderSmallText" },
                values: new object[] { 1L, "Республика Беларусь 210038, г. Витебск, Московский проспект 33", "images/gllg.png", "assets/for_new/img/icons/logo.svg", "IT-центр", "ВГУ имени П.М.Машерова", "IT-центр", "УЧРЕЖДЕНИЕ ОБРАЗОВАНИЯ \"ВГУ ИМЕНИ П.М.МАШЕРОВА\"" });

            migrationBuilder.InsertData(
                table: "SocialLinks",
                columns: new[] { "Id", "Name", "Url" },
                values: new object[,]
                {
                    { 1L, "ВКонтакте", "https://vk.com/abiturvsu" },
                    { 2L, "Instagram", "https://www.instagram.com/tvu.vsu/" },
                    { 3L, "Youtube", "https://www.youtube.com/channel/UCo18_krqqaEWSb6_cbHnupQ" },
                    { 4L, "Facebook", "https://www.facebook.com/vsu.by" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutUs");

            migrationBuilder.DropTable(
                name: "Info");

            migrationBuilder.DeleteData(
                table: "SocialLinks",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "SocialLinks",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "SocialLinks",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "SocialLinks",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ConcurrencyStamp",
                value: "bbbd5270-bca9-4817-a4fa-5a96d5458807");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ca4aaec6-e03e-4a69-b2c7-56d20cec70ed", "AQAAAAEAACcQAAAAEO6mn7DxnWvCHHCDNW53QoJOc7hLYDZ6/N0CPJwv7NICM43J5wmv0H5wRlC0nHS3Ag==" });
        }
    }
}
