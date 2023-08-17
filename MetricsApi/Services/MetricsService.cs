using System.Collections.Concurrent;

namespace MetricsApi.Services;

public class MetricsService : IMetricsService
{
    public void AddCount(string endpointName)
    {
        _pathCounts.AddOrUpdate(endpointName, 1, (_, val) => val+= 1);
    }


    public Dictionary<string, int> GetCount()
    {
        return _pathCounts.ToDictionary(x => x.Key, x => x.Value);
    }


    private readonly static ConcurrentDictionary<string, int> _pathCounts = new();
}
