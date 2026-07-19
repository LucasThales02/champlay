var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/", () => "ChamPlay API Online");

app.MapGet("/api/health", () => new
{
    status = "online",
    application = "ChamPlay API",
    version = "1.0.0"
});

app.Run();