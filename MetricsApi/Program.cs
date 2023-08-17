using MetricsApi.Middlewares;
using MetricsApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IMetricsService, MetricsService>();

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.UseMiddleware<MetricsMiddleware>();

app.Run();
