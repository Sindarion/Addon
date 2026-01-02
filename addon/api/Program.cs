using api.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();

//var db = Environment.GetEnvironmentVariable("DB");

var config = builder.Configuration.Get<AppConfiguration>();
Console.WriteLine($"DB from config: {config.Db}");

builder.Services.Configure<AppConfiguration>(builder.Configuration);

var db = Environment.GetEnvironmentVariable("DB") ?? "default.db";
Console.WriteLine($"Using database2: {db}");

//Console.WriteLine($"Using database: {db}");

// Add services to the container.

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
