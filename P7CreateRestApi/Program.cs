using Dot.Net.WebApi.Data;
using Dot.Net.WebApi.Repositories;
using Microsoft.EntityFrameworkCore;
using P7CreateRestApi.Repositories;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<TradeRepository>();
builder.Services.AddScoped<RuleNameRepository>();
builder.Services.AddScoped<RatingRepository>();
builder.Services.AddScoped<CurvePointRepository>();
builder.Services.AddScoped<BidListRepository>();
builder.Services.AddScoped<DataRepository>();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LocalDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
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

app.MapControllers();

app.Run();
