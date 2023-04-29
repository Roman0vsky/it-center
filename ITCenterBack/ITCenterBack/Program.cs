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

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ITCenterContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseConnection")));

//Repositories
builder.Services.AddScoped<IRepository<Course>, CourseRepository>();
builder.Services.AddScoped<IRepository<Teacher>, TeacherRepository>();
builder.Services.AddScoped<IRepository<News>, NewsRepository>();

//Services
builder.Services.AddAutoMapper(typeof(MapperProfiles));
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();
builder.Services.AddScoped<IAccountService, AccountService>();

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

app.UseStaticFiles();

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
