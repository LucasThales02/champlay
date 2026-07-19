using Champlay.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<SupabaseService>();
builder.Services.AddControllers();

var app = builder.Build();

app.MapGet("/", () => "ChamPlay API Online");

app.MapGet("/api/health", () => new
{
    status = "online",
    application = "ChamPlay API",
    version = "1.0.0"
});

app.MapControllers();

app.Run();