using api.Models;
using api.Services;
using api.Services.Interfaces;
using Supabase;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();

var optionsPath = builder.Environment.IsDevelopment()
    ? "dev.options.json"
    : "/data/options.json";

var optionsJson = File.ReadAllText(optionsPath);
var appConfig = JsonSerializer.Deserialize<AppConfiguration>(optionsJson) ?? throw new InvalidOperationException("Failed to deserialize AppConfiguration from options.json.");

builder.Services.AddSingleton<Client>(sp =>
{
    var client = new Supabase.Client(
        appConfig.SUPABASE_URL,
        appConfig.SUPABASE_KEY,
        new SupabaseOptions
        {
            AutoRefreshToken = true,
            AutoConnectRealtime = false
        });

    // IMPORTANT: Initialize
    client.InitializeAsync().GetAwaiter().GetResult();

    return client;
});

builder.Services.AddScoped<ITaskService, TaskService>();

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin() // Angular dev server
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

if (builder.Environment.IsProduction())
{
    builder.WebHost.UseUrls("http://0.0.0.0:5000");
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors();

app.UseAuthorization();
app.UseStaticFiles();
app.MapControllers();

// fallback all other routes to index.html (Angular router support)
app.MapFallbackToFile("index.html");

app.Run();
