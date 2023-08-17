using MetricsApi.Services;

namespace MetricsApi.Middlewares;

public class MetricsMiddleware
{
    public MetricsMiddleware(IMetricsService metricsService, RequestDelegate next)
    {
        _metricsService = metricsService;
        _next = next;
    }


    public async Task InvokeAsync(HttpContext context)
    {
        var path = context.Request.Path;
        if (!_auxiliaryPaths.Contains(path))
            _ = Task.Run(() => _metricsService.AddCount(path));

        await _next(context);
    }


    private readonly IMetricsService _metricsService;
    private readonly RequestDelegate _next;

    private readonly HashSet<string> _auxiliaryPaths = new()
    {
        "/metrics"
    };
}
