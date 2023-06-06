using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITCenterBack.Migrations
{
    public partial class seedupd : Migration
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
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CourseType = table.Column<int>(type: "int", nullable: false)
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
                    SliderBigText = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SliderSmallText = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NameOfTheCenter = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HeaderLogo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FooterLogo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NameOfUniversity = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AdressOfUniversity = table.Column<string>(type: "longtext", nullable: false)
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
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
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
                        .Annotation("MySql:CharSet", "utf8mb4")
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
                values: new object[] { 1L, "5d15f7d2-2f4b-43b3-b298-f3e0ed73b3f5", "Administrator", "Administrator" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1L, 0, "974e2ae3-0076-413c-8676-5c77f93c4668", null, false, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEDfmuwJUtfAKffzz8xO3eBZdE8SjWjIT6Ukd2F96Yyz21idrF6qDoojjqdY/iHfrAw==", null, false, null, false, "admin" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Age", "CourseType", "Description", "Image", "Name", "Requirements" },
                values: new object[,]
                {
                    { 4L, "10-15 лет", 2, "В индустрии компьютерной графики множество направлений: пространственный дизайн, обработка фотографий, дизайн логотипов, разработка трехмерных моделей, анимации и прочее. Цель данного курса – подготовить юных слушателей к знакомству с миром компьютерной графики, дизайна, композиции. Основным инструментом на курсе является всемирно известный редактор графики Adobe Photoshop, а также некоторые другие инструменты для творчества. Все эти навыки пригодятся для дальнейшей работы с самыми известными и полезными программами на других направлениях – Illustrator, Blender, Figma. В процессе обучения, слушатели смогут раскрыть в себе творческий потенциал и интерес к изучению определенной сферы графического дизайна. Знания, полученные на курсе «Основы компьютерной графики» обязательно пригодятся и в смежных сферах – разработке сайтов, игр, видеомонтаже, робототехнике", "/assets/for_new/img/courses/design/starter-graphics.svg", "Основы компьютерной графики", "уверенные навыки использования компьютера" },
                    { 5L, "8-11 лет", 1, "В современном мире, без навыков использования компьютера справиться с повседневными задачами в учебе и работе очень сложно. Курс «Мой компьютер» является первой ступеней в процессе подготовки будущего IT-специалиста, а также пригодится абсолютно любому современному человеку. На занятиях слушатели учатся уверенно использовать свой компьютер в качестве универсального инструмента для решения задач, обслуживать и настраивать операционную систему, изучают основные пакеты офисных программ. В рамках курса затрагиваются такие темы, как основы обработки графики, информационной безопасности и алгоритмизации", "/assets/for_new/img/courses/pk/my-pc.svg", "Мой компьютер - для начинающих", "нет" },
                    { 6L, "12-17 лет", 2, "Мир трехмерной графики охватывает множество направлений - геймдизайн и разработка игр, архитектурная визуализация и рендеринг, анимация и визуальные эффекты, 3D - печать и . На направлении \"3D-графика\" студенты изучают один из самых известных и гибких редакторов - Blender. Редактор Blender - мощный инструмент для создания трехмерных моделей, обладающий огромным сообществом фанатов и профессионалов, а также наличием большого количества модулей и плагинов, которые позволяют решить абсолютно любую задачу - от симуляции трехмерной виртуальной одежды, до просчетов физики жидкостей! Навыки, полученные при прохождении курса, расширяют возможности юных дизайнеров в сфере графического дизайна, а также открывают двери в такие направления, как разработка игр, архитектурную визуализацию и создание видеороликов с использованием 3D графики!", "/assets/for_new/img/courses/3d/graphics-3d.svg", "3D графика, анимация и рендеринг", "предварительное прохождение курса \"Компьютерная графика\"" }
                });

            migrationBuilder.InsertData(
                table: "Info",
                columns: new[] { "Id", "AdressOfUniversity", "FooterLogo", "HeaderLogo", "NameOfTheCenter", "NameOfUniversity", "SliderBigText", "SliderSmallText" },
                values: new object[] { 1L, "Республика Беларусь 210038, г. Витебск, Московский проспект 33", "/images/gllg.png", "/assets/for_new/img/icons/logo.svg", "IT-центр", "ВГУ имени П.М.Машерова", "IT-центр", "УЧРЕЖДЕНИЕ ОБРАЗОВАНИЯ \"ВГУ ИМЕНИ П.М.МАШЕРОВА\"" });

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
                table: "Teachers",
                columns: new[] { "Id", "Description", "Image", "Link", "Name" },
                values: new object[] { 1L, "Робототехника LEGO EV3", "/images/Shpakov.jpg", "https://vsu.by/universitet/ob-universitete/236-universitet/personalii/4140-shpakov-sergej-andreevich.html", "Шпаков С А" });

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
                name: "SliderImages");

            migrationBuilder.DropTable(
                name: "SocialLinks");

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
