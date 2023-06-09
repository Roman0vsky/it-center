using Microsoft.EntityFrameworkCore;
using ITCenterBack.Data;
using ITCenterBack.Interfaces;
using ITCenterBack.Models;
using ITCenterBack.Repositories;
using ITCenterBack.Services;
using ITCenterBack.Constants;
using ITCenterBack.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ITCenterContext>(opt =>
    opt.UseMySql(
        builder.Configuration.GetConnectionString("DatabaseConnection"),
        new MySqlServerVersion(new Version(10, 11, 3)))
    );

builder.Services.AddSession();

//Repositories
builder.Services.AddScoped<IRepository<Course>, CourseRepository>();
builder.Services.AddScoped<IRepository<Teacher>, TeacherRepository>();
builder.Services.AddScoped<IRepository<News>, NewsRepository>();
builder.Services.AddScoped<IRepository<School>, SchoolRepository>();
builder.Services.AddScoped<IRepository<Schedule>, ScheduleRepository>();
builder.Services.AddScoped<IRepository<SocialLink>, SocialLinkRepository>();
builder.Services.AddScoped<IRepository<Time>, TimeRepository>();
builder.Services.AddScoped<IRepository<AvaliableTime>, AvaliableTimeRepository>();
builder.Services.AddScoped<IRepository<Application>, ApplicationRepository>();
builder.Services.AddScoped<IApplicationTimeRepository, ApplicationTimeRepository>();
builder.Services.AddScoped<ICourseApplicationRepository, CourseApplicationRepository>();
builder.Services.AddScoped<IRepository<Section>, SectionRepository>();
builder.Services.AddScoped<IRepository<Square>, SquareRepository>();

//Services
builder.Services.AddAutoMapper(typeof(MapperProfiles));
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();
builder.Services.AddScoped<INewsService, NewsService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ISchoolService, SchoolService>();
//builder.Services.AddScoped<IScheduleService, ScheduleService>();
builder.Services.AddScoped<ISocialLinkService, SocialLinkService>();
builder.Services.AddScoped<IImagesService, ImagesService>();
builder.Services.AddScoped<ITimeService, TimeService>();
builder.Services.AddScoped<IAvaliableTimeService, AvaliableTimeService>();
builder.Services.AddScoped<IApplicationService, ApplicationService>();
builder.Services.AddScoped<IAboutUsService, AboutUsService>();
builder.Services.AddScoped<IInfoService, InfoService>();
builder.Services.AddScoped<ISectionService, SectionService>();
builder.Services.AddScoped<ISquareService, SquareService>();
//builder.Services.AddScoped<IApplicationTimeService, ApplicationTimeService>();


builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation();
builder.Services.AddMvc();

//Auth section
builder.Services.Configure<JwtConfigurationModel>(builder.Configuration.GetSection("Authentication").GetSection("Jwt"));

builder.Services.AddIdentity<User, IdentityRole<long>>(options =>
{
    options.Password.RequiredLength = 5;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireDigit = true;
    options.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<ITCenterContext>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(opt =>
    {
        opt.SaveToken = true;
        opt.TokenValidationParameters = new()
        {
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Authentication:Jwt:Issuer"],
            ValidAudience = builder.Configuration["Authentication:Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Authentication:Jwt:Key"]))
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(AccountPolicies.ElevatedRights, policy =>
        policy.RequireRole(AccountRoles.Administrator));
});

builder.Services.AddControllers(); 

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "ITCenter", Version = "v1" });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n " +
                      "Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345\"",
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseSession();
app.Use(async (context, next) =>
{
    var token = context.Session.GetString("Token");
    if (!string.IsNullOrEmpty(token))
    {
        context.Request.Headers.Add("Authorization", "Bearer " + token);
    }
    await next();
});

app.UseStaticFiles();

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
