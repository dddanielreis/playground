using Orleans.Concurrency;

namespace TrafficGenerator.Contracts.Grains;

/// <summary>
///     Most basic unit of work, responsible for making the actual HTTP requests.
/// </summary>
public interface ITrafficUnit : IGrainWithStringKey
{
    [OneWay]
    Task GenerateTraffic(TrafficConfiguration configuration);
}
