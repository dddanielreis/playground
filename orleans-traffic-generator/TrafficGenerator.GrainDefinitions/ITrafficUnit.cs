using Orleans;

using TrafficGenerator.Contracts;

namespace TrafficGenerator.GrainDefinitions;

/// <summary>
///     Most basic unit of work, responsible for making the actual HTTP requests.
/// </summary>
public interface ITrafficUnit : IGrainWithStringKey
{
    Task Initialize(TrafficConfiguration configuration);
}
