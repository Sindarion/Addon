using api.Models;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();

//var config = builder.Configuration.Get<AppConfiguration>();

//builder.Services.Configure<AppConfiguration>(builder.Configuration);

// Add services to the container.

var optionsPath = "/data/options.json";

if (!File.Exists(optionsPath))
{
    //throw new Exception("Home Assistant options file not found");
    Console.WriteLine($"config file not found");
}
else
{
    Console.WriteLine("FILE EXISTS!!!!");
}

var optionsJson = File.ReadAllText(optionsPath);
var appConfig = JsonSerializer.Deserialize<AppConfiguration>(optionsJson) ?? throw new InvalidOperationException("Failed to deserialize AppConfiguration from options.json.");

Console.WriteLine($"DB from HA DATABASE_CONNECTION_STRING: {appConfig.DATABASE_CONNECTION_STRING}");

builder.Services.AddSingleton(appConfig);

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.WebHost.UseUrls("http://0.0.0.0:5000");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();
app.UseStaticFiles();
app.MapControllers();

// fallback all other routes to index.html (Angular router support)
app.MapFallbackToFile("index.html");

app.Run();
