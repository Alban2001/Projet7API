using Dot.Net.WebApi.Data;
using Dot.Net.WebApi.Domain;
using Dot.Net.WebApi.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using P7CreateRestApi.Domain;
using P7CreateRestApi.Repositories;
using System.Text;
using P7CreateRestApi.Services;
using Microsoft.OpenApi.Models;
using System.Xml.Linq;
using Microsoft.Extensions.Options;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();
builder.Host.UseSerilog();

ConfigurationManager configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITradeRepository, TradeRepository>();
builder.Services.AddScoped<IRuleNameRepository, RuleNameRepository>();
builder.Services.AddScoped<IRatingRepository, RatingRepository>();
builder.Services.AddScoped<ICurvePointRepository, CurvePointRepository>();
builder.Services.AddScoped<IBidListRepository, BidListRepository>();
builder.Services.AddScoped<IDataRepository, DataRepository>();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LocalDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<User, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<LocalDbContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings.
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 8;
    options.Password.RequiredUniqueChars = 1;

    // Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // User settings.
    options.User.AllowedUserNameCharacters =
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = false;
});

var jwtSettings = builder.Configuration.GetSection("Jwt");

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]))
    };
});

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "API : Findexium", Version = "v1" });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        In = ParameterLocation.Header,
        Description = "Veuillez entrer un jeton valide",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
        {
            {
                new OpenApiSecurityScheme()
                {
                    Reference = new OpenApiReference()
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[]{}
            }
        });
});

builder.Services.AddTransient<IAuthenticationService, AuthenticationService>();

builder.Services.AddAuthorization();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;


    var userManager = services.GetRequiredService<UserManager<User>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

    string roleName = "ADMIN";
    string roleUser = "USER";
    string adminEmail = "admin@findexium.fr";
    string adminPassword = "Admin126754?!";

    // 1. Création du rôle Admin s’il n’existe pas
    if (!await roleManager.RoleExistsAsync(roleName))
    {
        await roleManager.CreateAsync(new IdentityRole(roleName));
    }
    if (!await roleManager.RoleExistsAsync(roleUser))
    {
        await roleManager.CreateAsync(new IdentityRole(roleUser));
    }

    // 2. Création de l'utilisateur admin s’il n’existe pas
    var adminUser = await userManager.FindByEmailAsync(adminEmail);
    if (adminUser == null)
    {
        var newAdmin = new User
        {
            UserName = "admin2",
            Fullname = "Administrateur",
            Email = adminEmail,
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
            TwoFactorEnabled = false,
            LockoutEnabled = false,
            AccessFailedCount = 0
        };

        var createResult = await userManager.CreateAsync(newAdmin, adminPassword);

        if (createResult.Succeeded)
        {
            // 3. Ajouter l'utilisateur au rôle Admin
            var user = await userManager.FindByEmailAsync(adminEmail);
            await userManager.AddToRoleAsync(user, roleName);
        }
        else
        {
            foreach (var error in createResult.Errors)
            {
                Console.WriteLine($"Erreur création compte admin : {error.Description}");
            }
        }
    }

    var context = services.GetRequiredService<LocalDbContext>();

    // Crée la base si elle n'existe pas
    context.Database.EnsureCreated();

    // Remplit avec des données de test
    LocalDbContext.Initialize(context);
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseSerilogRequestLogging();

app.MapControllers();

app.Run();
