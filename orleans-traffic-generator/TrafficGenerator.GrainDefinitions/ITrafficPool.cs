using Orleans;

using TrafficGenerator.Contracts;

namespace TrafficGenerator.GrainDefinitions;

/// <summary>
///     Should manage a pool of traffic units, initializing them and finalizing them when asked.
/// </summary>
public interface ITrafficPool : IGrainWithStringKey
{
    Task Initialize(int unitCount, TrafficConfiguration configuration);

    Task Finalize(int unitCount);
}
