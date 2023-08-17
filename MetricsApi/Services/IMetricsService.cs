namespace MetricsApi.Services
{
    public interface IMetricsService
    {
        void AddCount(string endpointName);
        Dictionary<string, int> GetCount();
    }
}