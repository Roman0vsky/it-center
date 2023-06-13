using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITCenterBack.Migrations
{
    public partial class entitiesupd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AboutUs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Url = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutUs", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Administration",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Image = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Link = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsAdministrator = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsHeadOfThecenter = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administration", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Age = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Requirements = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Image = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Info",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SliderFirstText = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SliderSecondText = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SliderThirdText = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NameOfTheCenter = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HeaderLogo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FooterLogo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NameOfUniversity = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AdressOfUniversity = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber1 = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber2 = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SchoolYear = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Info", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PublicationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ShortText = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Text = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Image = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Image = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Image = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SliderImages",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Image = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SliderImages", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SocialLinks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Url = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialLinks", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Squares",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Image = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Title = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TextPreview = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Content = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Squares", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TeacherCourses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CoursesId = table.Column<long>(type: "bigint", nullable: false),
                    TeacherId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherCourses", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Image = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Link = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Times",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    From = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    To = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Times", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderKey = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SchoolId = table.Column<long>(type: "bigint", nullable: true),
                    SchoolName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Class = table.Column<int>(type: "int", nullable: false),
                    ListenerFullName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RepresentativeFullName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RepresentativePhoneNumber = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Time = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Applications_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AvaliableTimes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsAvaliable = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Day = table.Column<int>(type: "int", nullable: false),
                    TimeId = table.Column<long>(type: "bigint", nullable: false),
                    TimeFrom = table.Column<DateTime>(type: "datetime(6)", nullable: false)
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ApplicationTimes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Day = table.Column<int>(type: "int", nullable: false),
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CourseApplications",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AboutUs",
                columns: new[] { "Id", "Description", "Url" },
                values: new object[] { 1L, "IT-центр - открывает детям двери в мир IT, не забывая об их росте как личности и прививая им важные социальные ценности. Мы больше, чем просто компьютерные курсы для детей. Мы предоставляем не только обучение программированию или робототехнике, но и все возможности для роста, общения и развития.\r\nIT-центр - стиль жизни и образ мышления, среда роста и творчества. Современный рынок цифровых продуктов - это уже не поле для деятельности специалистов-одиночек, это полигон борьбы глобальных проектов. Мы готовим специалистов, нацеленных на командную работу и общий успех!\r\n                                        ", "https://www.youtube.com/embed/KrreehNgcgA" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 1L, "dc18968a-20fc-4ff6-90d3-a655742a692b", "Administrator", "Administrator" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1L, 0, "1edff17f-bdc5-436b-8c69-1d8e57bd39cb", null, false, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEDCyszHb0b5VokYxswbyRunpu0B0Sw13aWYmOrogTSalpSW6n1mZr6huCcCmdJuAWg==", null, false, null, false, "admin" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Age", "Description", "Image", "Name", "Requirements" },
                values: new object[,]
                {
                    { 4L, "10-15 лет", "В индустрии компьютерной графики множество направлений: пространственный дизайн, обработка фотографий, дизайн логотипов, разработка трехмерных моделей, анимации и прочее. Цель данного курса – подготовить юных слушателей к знакомству с миром компьютерной графики, дизайна, композиции. Основным инструментом на курсе является всемирно известный редактор графики Adobe Photoshop, а также некоторые другие инструменты для творчества. Все эти навыки пригодятся для дальнейшей работы с самыми известными и полезными программами на других направлениях – Illustrator, Blender, Figma. В процессе обучения, слушатели смогут раскрыть в себе творческий потенциал и интерес к изучению определенной сферы графического дизайна. Знания, полученные на курсе «Основы компьютерной графики» обязательно пригодятся и в смежных сферах – разработке сайтов, игр, видеомонтаже, робототехнике", "/assets/for_new/img/courses/design/starter-graphics.svg", "Основы компьютерной графики", "уверенные навыки использования компьютера" },
                    { 5L, "8-11 лет", "В современном мире, без навыков использования компьютера справиться с повседневными задачами в учебе и работе очень сложно. Курс «Мой компьютер» является первой ступеней в процессе подготовки будущего IT-специалиста, а также пригодится абсолютно любому современному человеку. На занятиях слушатели учатся уверенно использовать свой компьютер в качестве универсального инструмента для решения задач, обслуживать и настраивать операционную систему, изучают основные пакеты офисных программ. В рамках курса затрагиваются такие темы, как основы обработки графики, информационной безопасности и алгоритмизации", "/assets/for_new/img/courses/pk/my-pc.svg", "Мой компьютер - для начинающих", "нет" },
                    { 6L, "12-17 лет", "Мир трехмерной графики охватывает множество направлений - геймдизайн и разработка игр, архитектурная визуализация и рендеринг, анимация и визуальные эффекты, 3D - печать и . На направлении \"3D-графика\" студенты изучают один из самых известных и гибких редакторов - Blender. Редактор Blender - мощный инструмент для создания трехмерных моделей, обладающий огромным сообществом фанатов и профессионалов, а также наличием большого количества модулей и плагинов, которые позволяют решить абсолютно любую задачу - от симуляции трехмерной виртуальной одежды, до просчетов физики жидкостей! Навыки, полученные при прохождении курса, расширяют возможности юных дизайнеров в сфере графического дизайна, а также открывают двери в такие направления, как разработка игр, архитектурную визуализацию и создание видеороликов с использованием 3D графики!", "/assets/for_new/img/courses/3d/graphics-3d.svg", "3D графика, анимация и рендеринг", "предварительное прохождение курса \"Компьютерная графика\"" }
                });

            migrationBuilder.InsertData(
                table: "Info",
                columns: new[] { "Id", "AdressOfUniversity", "Email", "FooterLogo", "HeaderLogo", "NameOfTheCenter", "NameOfUniversity", "PhoneNumber1", "PhoneNumber2", "SchoolYear", "SliderFirstText", "SliderSecondText", "SliderThirdText" },
                values: new object[] { 1L, "Республика Беларусь 210038, г. Витебск, Московский проспект 33", "fmiit@vsu.by", "/images/gllg.png", "/assets/for_new/img/icons/logo.svg", "IT-центр", "ВГУ имени П.М.Машерова", "8 (0212) 37-58-36", "+375 (33) 317-95-02", "2023/2024", "Учреждение образования \"Витебский государственный университет имени П.М.Машерова\"", "Образовательный IT-Центр", "Математика Информатика Робототехника Будущего" });

            migrationBuilder.InsertData(
                table: "Schedule",
                columns: new[] { "Id", "Description", "Image" },
                values: new object[] { 1L, "АКТУАЛЬНОЕ РАСПИСАНИЕ ВСЕГДА МОЖНО НАЙТИ\r\n НА СТЕНДЕ НАПРОТИВ ДЕКАНАТА (АУД. 316).", "/images/shedule.png" });

            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Гимназия № 1 имени Ж.И.Алфёрова" },
                    { 2L, "Гимназия № 2" },
                    { 3L, "Гимназия № 3 имени А.С.Пушкина" },
                    { 4L, "Гимназия № 4" },
                    { 5L, "Гимназия № 5 имени И.И.Людникова" },
                    { 6L, "Гимназия № 7 имени П.Е.Кондратенко" },
                    { 7L, "Гимназия № 8" },
                    { 8L, "Гимназия № 9 имени А.П.Белобородова" },
                    { 9L, "Средняя школа № 2 имени Ф.Т.Блохина" },
                    { 10L, "Средняя школа № 3 имени Л.Н.Белицкого" },
                    { 11L, "Средняя школа № 4" },
                    { 12L, "Средняя школа № 5 имени Г.И.Богомазова" },
                    { 13L, "Средняя школа № 6 имени А.Е.Белохвостикова" },
                    { 14L, "Средняя школа № 7" },
                    { 15L, "Средняя школа № 8 имени А.М.Испенкова" },
                    { 16L, "Средняя школа № 9" },
                    { 17L, "Средняя школа № 10 имени А.К.Горовца" },
                    { 18L, "Средняя школа № 11" },
                    { 19L, "Средняя школа № 12 имени Л.Н.Филипенко" },
                    { 20L, "Средняя школа № 14" },
                    { 21L, "Средняя школа № 15 имени М.Я.Чуманихиной" },
                    { 22L, "Средняя школа № 16 имени М.И.Дружинина" },
                    { 23L, "Средняя школа № 17 имени И.Р.Бумагина" },
                    { 24L, "Средняя школа № 18 имени В.С.Сметанина" },
                    { 25L, "Средняя школа № 19" },
                    { 26L, "Средняя школа № 21 имени В.А.Демидова" },
                    { 27L, "Средняя школа № 22" },
                    { 28L, "Средняя школа № 23 имени О.Р.Тувальского" },
                    { 29L, "Средняя школа № 24 имени М.Ф.Маскаева" },
                    { 30L, "Средняя школа № 25" },
                    { 31L, "Средняя школа № 27" },
                    { 32L, "Средняя школа № 28 имени Е.С.Зеньковой" },
                    { 33L, "Средняя школа № 29 имени В.В.Пименова" },
                    { 34L, "Средняя школа № 30" },
                    { 35L, "Средняя школа № 31 имени В.З.Хоружей" },
                    { 36L, "Средняя школа № 33 имени И.Д.Черняховского" },
                    { 37L, "Средняя школа № 34" },
                    { 38L, "Средняя школа № 35" },
                    { 39L, "Средняя школа № 38" },
                    { 40L, "Средняя школа № 40 имени М.М.Громова" },
                    { 41L, "Средняя школа № 41" },
                    { 42L, "Средняя школа № 42 имени Д.Ф.Райцева" },
                    { 43L, "Средняя школа № 43 имени М.Ф.Шмырёва" },
                    { 44L, "Средняя школа № 44" },
                    { 45L, "Средняя школа № 45 имени В.Ф.Маргелова" },
                    { 46L, "Средняя школа № 46 имени И.Х.Баграмяна" },
                    { 47L, "Средняя школа № 47 имени Е.Ф.Ивановского" },
                    { 48L, "Специальная  школа № 26" },
                    { 49L, "Витебская специальная школа-интернат" }
                });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "Id", "Description", "Image", "Name" },
                values: new object[,]
                {
                    { 1L, "На занятиях по математике слушатели IT-академии занимаются\r\n\r\n решением задач игрового, логического и занимательного характера с целью выявления и развития математических способностей и углубления интереса к математике, а также повышения общего уровня математических знаний, умений и навыков.\r\n Кроме того в рамках курсов подробно разбираются задачи различных математических олимпиад, турниров и конкурсов.\r\n Продемонстрировать полученные умения и навыки учащиеся могут приняв участие в следующих мероприятиях:\r\nМеждународный математический Турнир городов (по г.Витебску)\r\n Республиканский турнир юных математиков\r\n Районные и областные этапы республиканской олимпиады школьников по математике и многих других мероприятиях\r\n Слушатели, проявившие себя с наилучшей стороны, могут принять участие в работе Республиканской летней научно-исследовательской школы “Бригантина”.\r\n Для учащихся 10-11 классов в рамках работы секции проводятся курсы подготовки к ЦТ.\r\n", "/assets/for_new/img/courses/c/c.svg", "Математика" },
                    { 2L, "В рамках секции информатики и программирования занятия проводятся по следующим направлениям:\r\n\r\n Scratch-программирование: курс предназначен для самых юных слушателей TI-академии и направлен на изучение основ алгоритмизации и программирования на базе языка Scratch.\r\nJava для начинающих: язык программирования Java является одним из наиболее популярных и распространенных в мире на текущий момент. В рамках данного курса ученики познакомятся с его синтаксисом и изучат способы его применения для решения задач.\r\nWeb-программирование: курс посвящен изучению таких технологий как HTML/CSS/JS, которые применяются при разработке сайтов и клиентской частей интернет-приложений.\r\n Компьютерная графика и web-дизайн: данный курс будет полезен всем, кто занимается художественным творчеством и желает использовать компьютер как инструмент в художественной деятельности.\r\n Кроме того, учащиеся IT-академии имеют возможность проявить себя, принимая участие в различных мероприятиях и соревнованиях по информатике и программированию как республиканского так и международного уровня.\r\n", "/assets/for_new/img/courses/c/c.svg", "Информатика и программирование" },
                    { 3L, "За время учебы на курсах «физика и робототехника» слушатели развивают умения и навыки работы с техническими устройствами на примере образовательной робототехники на базе платформ Lego, Arduino и Festo Robotino.\r\n\r\n Платформа LEGO Mindstorms EV3 является наиболее популярной при изучении робототехники. С помощью различных сочетаний программных блоков, моторов и датчиков можно заставить модели ходить, говорить, захватывать предметы, думать, стрелять и выполнять любые действия, которые только можно придумать.\r\n Arduino – это небольшая плата с собственным процессором и памятью. В Arduino можно загрузить программу, которая будет управлять различными устройствами по заданному алгоритму. Таким образом можно создать множество уникальных и классных механизмов, сделанных своими руками и по собственной задумке.\r\n Помимо этого слушатели изучают теоретические основы робототехники. Рассматриваются такие темы как механика и электричество. А также во время курсов ученики имеют возможность посетить планетарий университета, оснащенный современными телескопами, и узнать больше о Солнечной системе и Вселенной.\r\n", "/assets/for_new/img/courses/c/c.svg", "Физика и робототехника" }
                });

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

            migrationBuilder.InsertData(
                table: "SocialLinks",
                columns: new[] { "Id", "Name", "Url" },
                values: new object[,]
                {
                    { 1L, "ВКонтакте", "https://vk.com/mf_vsu" },
                    { 2L, "Instagram", "https://www.instagram.com/fmiit_vsu/" },
                    { 3L, "Телеграм", "https://t.me/fmiit_vsu" },
                    { 4L, "Сайт факультета", "https://fmiit.vsu.by/" }
                });

            migrationBuilder.InsertData(
                table: "Squares",
                columns: new[] { "Id", "Content", "Image", "TextPreview", "Title" },
                values: new object[,]
                {
                    { 1L, "<p>\r\n <h>Изменения, которые происходят в нынешнем информационном обществе, устанавливают новые взгляды и методы в современном образовании. Для соответствия знаний, умений и навыков студентов требованиям современного общества в учебном процессе студентов факультета математики и информационных технологий используются современные инновационные технологии, которые повышают качество образования, позволяют результативно распределить учебное время.</h6> \r\n <br>\r\n      \r\n <h>Применение информационных и телекоммуникационных технологий дает возможность создания качественно новой информационной образовательной среды, среды без границ с возможностью построения глобальной системы дистанционного обучения. Одним из приоритетных направлений в этой области является широкое внедрение электронных технологий в учебный процесс.</h6> \r\n <br>\r\n <ul>\r\n <li><p><h>успешно функционирует виртуальная образовательная среда (sdo.vsu.by), в которой размещены материалы по всем дисциплинам учебных планов;</h4></li>\r\n <li><p><h>в учебные планы включаются новые дисциплины, направленные на изучение ИКТ, например, образовательный курс Intel \"Проектная деятельность в информационно-образовательной среде XXI века\", курс \"Облачные сервисы\" и др;</h4></p></li>\r\n <li><p><h>с 2009г. созданы два учебно-научно-производственных комплекса с резидентом номер один Парка высоких технологий – ИЧУПТП «ЭПАМ Системз» и ООО «Фабрика инноваций и решений».В рамках комплекса с «ЭПАМ Системз» создана лаборатория компьютерных технологий, на базе которой IT-компанией «ЭПАМ Системз» бесплатно осуществляется дополнительная подготовка студентов факультета сверх учебных планов в области информационных технологий (элективные курсы, организуемые «ЭПАМ Системз», с выдачей сертификата) и организуются тренинги для студентов факультета, позволяющие максимально приблизить уровень подготовки студентов к требованиям современного высокотехнологичного предприятия;</h6></p></li>\r\n <li><p><h>совместно с Парком высоких технологий создан региональный белорусско-индийский учебный центр в области информационных и коммуникационных технологий. Благодаря установленному в центре новейшему оборудованию студенты участвуют в on-line семинарах, которые организуются администрацией Парка высоких технологий в Минске, а также в международных видеоконференциях, слушают лекции преподавателей известных университетов мира и ведущих специалистов в области IT- технологий.</h6></p></li>\r\n  </p>\r\n </ul>   \r\n <br><br>", "/assets/for_new/img/icons/club.svg", "Дружелюбная атмосфера не заставит скучать", "Технологии обучения" },
                    { 2L, "<p>\r\n <h>На 5 кафедрах факультета работают 62 преподавателя, из которых 65% имеют ученые степени и звания: 5 доктора наук, 6 профессоров и 34 кандидата наук.</h6>  <br>\r\n <p><img src=\"/images/dMbEC4XuNT7V0mr.jpg\" /><br></p>\r\n  <h6>Воробьев Николай Тимофеевич</h6> \r\n <p>\r\n <h>Профессор, доктор физико-математических наук, заведующий кафедрой алгебры и методики преподавания математики. Николай Тимофеевич принимает участие в международных научных программах, реализуемых учеными Республики Беларусь совместно с учеными России, Германии, Испании, Польши, Венгрии и Китая и имеет совместные научные труды с ведущими учеными КНР и Польши, является постоянным обозревателем двух крупных международных журналов (издательств США, Германии), членом редколлегии научных журналов «Веснiк ВДУ», «Вестник ПГУ», членом экспертного Совета ВАК Республики Беларусь, членом собрания НАН Республики Беларусь, членом Совета по защите докторских и кандидатских диссертаций в области алгебры. Н.Т.Воробьев является автором более 250 научных работ, в том числе, в ведущих научных журналах Беларуси, России, США, Германии, Китая, Японии, Венгрии и Польши.</h6> \r\n <br>\r\n  <h>Член Белорусского математического общества, член Американского математического общества. Награжден нагрудным знаком «Отличник образования РБ» и Медалью «Франциска Скорины», Почетной Грамотой управления образования Витебского облисполкома за многолетнюю добросовестную работу в системе образования, Почетной грамотой Министерства образования РБ за многолетнюю плодотворную научно-педагогическую деятельность, Почетной Грамотой Президиума и исполкома городского Совета народных депутатов за плодотворную научно-педагогическую деятельность по подготовке учительских кадров, Грамотой Министерства образования РБ за многолетнюю плодотворную научно-педагогическую деятельность. Получил звание «Лауреат премии за лучшую НИР ВГУ», «Человек года ВГУ 2013», «Человек года Витебщины 2015».</h6>\r\n <br>\r\n <h>Тема докторской диссертации: Развитие локального метода Хартли в теории конечных разрешимых групп</h6><br> </p>\r\n <p><img src=\"/images/Dxw9pFiPsrM4GXY.jpg\" /><br></p>\r\n <h6>Трубников Юрий Валентинович</h6>\r\n  <p>\r\n  <h>Профессор, доктор физико-математических наук, профессор кафедры геометрии и математического анализа.</h6>\r\n <br>\r\n  <h>Юрий Валентинович является специалистом по теории функций и и функциональному анализу. Результаты научных исследований докладывались им на многих конференциях.</h6>\r\n <br>\r\n <h>Трубников Ю.В. реферирует научные статьи для журнала «Mathematical Reviews», является членом Белорусского и Американского математического общества.</h6>\r\n <br>\r\n <h>Автор более 100 научных работ и 4 монографий.</h6>\r\n <br>\r\n <h>Тема докторской диссертации: Монотонные дифференциальные уравнения.</h6>\r\n <br>\r\n <h>Научные интересы: сложные динамические системы, теория апроксимации.</h6>\r\n  <p><img src=\"/images/hVTlJI9e4LXSMky.jpg\" /><br>\r\n <h6>Семенов Ефим Евстафьевич</h6> </p>\r\n <p>\r\n <h>Профессор, кандидат педагогических наук, профессор кафедры алгебры и методики преподавания математики.</h6>\r\n <br>\r\n <h>Награжден Почетнай грамотой Министерства просвещения РСФСР за успешную работу по подготовке кадров народного образования, грамотой ВГПИ им.С.М.Кирова в связи с 55-летием, почетной грамотой Первомайского райкома КП Белоруссии за большую и плодотворную работу по коммунистическому воспитанию молодежи, почетной грамотой ВГПИ им. С.М.Кирова за активное участие в организации научно-исследовательской работы студентов, Почетной грамотой ВГПИ им. С.М.Кирова в связи с 60-летием, почетная грамота Железнодорожного отдела образования за большой вклад в преподавании математики и оказание методической помощи учителям, граматой Министерства образования Республики Беларусь за многолетнюю добросовестную научно-педагогическую деятельность, Почетной грамотой Министерства образования Республики Беларусь.</h6>\r\n <br>\r\n <h>Автор пяти книг, четыре из которых опубликованы в издательстве \"Просвещение\".</h6>\r\n<br>\r\n <h>Тема кандидатской диссертации: Обучение обобщению и конкретизации при изучении геометрических понятий.</h6>\r\n <p><img src=\"/images/fL2CqiPt0OTFNKb.jpg\" /><br> </p>\r\n <h6>Воробьев Николай Николаевич</h6>\r\n  <p>\r\n <h>Доцент, доктор физико-математических наук, профессор кафедры алгебры и методики преподавания математики.</h6>\r\n <br>\r\n <h>Автор одной монографии и более 70 научных работ.</h6>\r\n <br>\r\n <h>Тема докторской диссертации: Алгебраические решетки классов конечных групп.</h6>\r\n <br>\r\n <h>Научные интересы: теория конечных групп и их классов: формации конечных групп, классы Фиттинга конечных групп, решетки формаций, решетки классов Фиттинга, частично насыщенные и частично композиционные формация, локальные классы Фиттинга.</h6>\r\n <br>\r\n  <p><img src=\"/images/t9PX7MRJxOTQsyw.jpg\" /> </p>\r\n  <br>\r\n  <h6>Михасев Геннадий Иванович</h6>\r\n  <p>\r\n <h>Профессор, доктор физико-математических наук, профессор кафедры прикладного и системного программирования.</h6>\r\n<br>\r\n  <h>Член экспертного совета ВАК Республики Беларусь, член ред. коллегий научных журналов «Facta Universitatis, Series: Mechanical Engineering», «Вестник БГУ. Серия 1», «Механика машин, механизмов и материалов», «Вестник Полоцкого государственного университета. Серия Е», Республиканского сборника «Теоретическая и прикладная механика», а также международного сборника «Численные методы в механике» (Санкт-Петербург), член международного общества прикладной математики и механики (GAMM, с 2001г), Европейского общества механиков (EUROMECH, с 2003г).</h6>\r\n <br>\r\n  <h>Награды: Грамоты МО РБ (2002) и Витебского областного исполнительного комитета (2007) за вклад в развитие белорусской науки и подготовку специалистов высшей квалификации.</h6>\r\n <br>\r\n <h>Тема докторской диссертации: Волновые пакеты в тонких оболочках.</h6>\r\n <br>\r\n <h>Геннадий Иванович является автором более 200 научных работ.</h6>\r\n  <br>\r\n <h>Научные интересы: общие вопросы биомеханики, математическое моделирование биомеханических систем человека (слуховая система, кровеносная система и др.), теория тонких изотропных и слоистых композитных оболочек: устойчивость, колебания, волны, гашение вибраций, нелокальные континуальные модели наноразмерных структур, локализованные волновые процессы в упругих средах, асимптотические методы.</h6>\r\n <p> <img src=\"/images/LpFBNoVUDmKMCS8.jpg\" /><br> </p>\r\n <h6>Корниенко Алексей Александрович</h6>\r\n  <p> \r\n  <h>Профессор, доктор физико-математических наук, профессор кафедры информатики и информационных технологий.</h6>\r\n <br>\r\n <h>Являясь специалистом по теории спектров лазерных материалов, активированных редкоземельными ионами, Корниенко А.А. совместно с профессором А.А. Каминским (Институт кристаллографии, г. Москва) и доцентом Е.Б.Дуниной разработал модифицированную теорию интенсивностей спектральных линий, которая широко применяется исследователями из Испании, Франции, Англии, США, Японии, Китая для описания экспериментальных результатов.</h6>\r\n <br>\r\n <h>Является автором более 160 научных работ, многие из которых напечатаны в ведущих физических журналах РБ, России и дальнего зарубежья, индекс Хирша по SCOPUS – 8, рецензент журналов “Journal of Applied Spectroscopy”, “Optical Materials”, “Spectrochimica Acta Part A: Molecular and Biomolecular Spectroscopy”, участвует в работе «Optical Society of America».</h6>\r\n  <br>\r\n  <h>Научные интересы: компьютерное и математическое моделирование физических процессов и свойств твердых тел, разработка новых моделей оптических центров лазерных материалов с последующим их тестированием, исследование взаимосвязи интенсивности межмультиплетных переходов и штарковской структуры мультиплетов, исследования по моделированию оптических центров люминофоров для источников квазибелого света, разработка численных методов расчета электромагнитных полей в объектах контроля, построение математических моделей первичных измерительных преобразователей с целью внедрения высокоэффективных методов диагностики и средств неразрушающего контроля.</h6>\r\n </p>\r\n </div>\r\n  <br><br>", "/assets/for_new/img/icons/profi.svg", "Чьи навыки может перенять Ваш ребенок", "Опытные преподаватели" },
                    { 3L, "<p>\r\n <h>Полноценное планомерное обучение, включающее в себя изучение естественных наук совокупно с инженерией, технологией и математикой, представляет собой STEM образование. По сути, это учебный план, который спроектирован на основе идеи обучения учащихся с применением междисциплинарного и прикладного.</h6>   \r\n    <br>\r\n  <h>Современная прогрессивная система, в отличие от традиционного обучения, представляет собой смешанную среду, которая позволяет на практике продемонстрировать, как данный изучаемый научный метод может быть применен в повседневной жизни. Учащиеся помимо математики и физики исследуют робототехнику и программирование. Дети воочию видят применение знаний точных дисциплин.</h6><br><br>\r\n   <p> <img src=\"/images/AC4lMeuSbyqK5vW.jpg\" /><br><br>\r\n       <h><b>Преимущества STEM технологий в образовании:</b></h6>\r\n    <ul>\r\n      <li><p><h>Активация коммуникативных навыков. Внедрение данной системы в основном включает в себя командную работу. Ведь большую часть времени дети совместно исследуют и развивают свои модели. Они учатся строить диалог с инструкторами и своими друзьями.</h6></p></li>\r\n    <li><p><h>Совершенствование навыков критического мышления. Учащиеся и студенты учатся преодолевать нестандартные задачи путем тестирования и проведения различных опытов. Все это позволяет им подготовиться ко взрослой жизни, где они могут столкнуться с необычными, нестандартными проблемами.</h6></p></li>\r\n  <li><p><h>STEM-образование является своеобразным мостом, соединяющий учебный процесс, карьеру и дальнейший профессиональный рост. Инновационная образовательная концепция позволит на профессиональном уровне подготовить детей к технически развитому миру.</h6></p></li>\r\n  </p>\r\n </ul>  </p>  \r\n  <br><br>", "/assets/for_new/img/icons/grow.svg", "Каждый ребенок может достичь своей цели", "STEM образование" },
                    { 4L, "<h3 style=\"display: flex;\">Учащиеся курсов IT-академии “МИР будущего” могут принимать участие в следующих мероприятиях: </h3>\r\n\r\n     <ul>\r\n      <li><p><h>Международный математический Турнир городов и Республиканский турнир юных математиков</h6></p></li>\r\n    <li><p><h>Районные и областные этапы республиканской олимпиады школьников по математике, физике и информатике</h6></p></li>\r\n  <li><p><h>Областная практическая конференция “Эврика” и республиканская практическая конференция (конкурс исследовательских работ) учащихся</h6></p></li>\r\n     <li><p><h>Республиканская летняя научно-исследовательская школа “Бригантина”</h6></p></li>\r\n  <li><p><h>Олимпиада по программированию в рамках недели факультета</h6></p></li>\r\n  <li><p><h>Областная научно-техническая конференция «Квант»</h6></p></li>\r\n   <li><p><h>Республиканский конкурс научно-технического творчества учащейся молодежи «ТехноИнтеллект»</h6></p></li>\r\n        <li><p><h>Республиканская олимпиада по робототехнике среди учащейся молодежи</h6></p></li>\r\n  <li><p><h>Областная олимпиада по программированию \"Информаша\"</h6></p></li>\r\n     <li><p><h>Областная олимпиада по информатике \"Юный программист\"</h6></p></li>\r\n    <li><p><h>Акция \"Час кода\"</h6></p></li>\r\n     </ul>    \r\n <br><br>", "/assets/for_new/img/icons/wins.svg", "В турнирах, как внутри коликтива, так и за его пределами", "Мероприятия" },
                    { 5L, "<p>\r\n  <h>В наше время наблюдается бурное развитие вычислительной техники и робототехники. Уже сейчас представители многих профессий могут быть эффективно заменены автоматическими устройствами. Как примеры можно назвать такие профессии, как: работник склада, экономист, бухгалтер, курьер, медработник, оператор колл-центра, продавец, водитель, военный, строитель, уборщик и многие другие.</h6>   \r\n  <br><br><p>\r\n  <img src=\"/images/ANDWthYmyce1O6v.jpg\" /></p>\r\n   <br><br>\r\n      <h>Однако вместо множества профессий и специальностей, востребованность в которых уменьшиться, появляются новые. Так например, нужны будут инженеры и техники, которые будут создавать эти устройства. Программисты, которые будут писать программное обеспечение. Тестировщики и специалисты по качеству ПО, бизнес-аналитики, дизайнеры и т.д.</h6> \r\n   <br><br><p>\r\n     <img src=\"/images/IF9ZGjAWdRe2VSx.jpg\" /></p>\r\n  <br><br>\r\n <h>В связи с этим, профессии связанные с IT-индустрией в течении следующих лет будут одними из самых востребованных и высокооплачиваемых как у нас, так и во всем мире. В IT-академии мы всегда ориентируемся на будущее и на обучение тем навыкам, которые необходимы для IT-специалистов высочайшего уровня.</h6> \r\n  <br><br><p>\r\n  <img src=\"/images/enNXbo0mUf5IlwQ.jpg\" /></p>", "/assets/for_new/img/icons/plau.svg", "В хорошей компании и знакомство с интересными людьми", "Ориентация на будущее" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Image", "Link", "Name" },
                values: new object[] { 1L, "/images/Shpakov.jpg", "https://vsu.by/universitet/ob-universitete/236-universitet/personalii/4140-shpakov-sergej-andreevich.html", "Шпаков С А" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1L, 1L });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_SchoolId",
                table: "Applications",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationTimes_ApplicationId",
                table: "ApplicationTimes",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationTimes_TimeId",
                table: "ApplicationTimes",
                column: "TimeId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AvaliableTimes_TimeId",
                table: "AvaliableTimes",
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
                name: "AboutUs");

            migrationBuilder.DropTable(
                name: "Administration");

            migrationBuilder.DropTable(
                name: "ApplicationTimes");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AvaliableTimes");

            migrationBuilder.DropTable(
                name: "CourseApplications");

            migrationBuilder.DropTable(
                name: "Info");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "SliderImages");

            migrationBuilder.DropTable(
                name: "SocialLinks");

            migrationBuilder.DropTable(
                name: "Squares");

            migrationBuilder.DropTable(
                name: "TeacherCourses");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Times");

            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Schools");
        }
    }
}
