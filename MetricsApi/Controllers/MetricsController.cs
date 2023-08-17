using MetricsApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace MetricsApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MetricsController : ControllerBase
{
    public MetricsController(IMetricsService metricsService)
    {
        _metricsService = metricsService;
    }


    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_metricsService.GetCount());
    }


    private readonly IMetricsService _metricsService;
}