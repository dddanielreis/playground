using TrafficGenerator.Contracts;
using TrafficGenerator.GrainDefinitions;

namespace TrafficGenerator.SiloHost.Grains;

public class TrafficSupervisor : Grain, ITrafficSupervisor
{
    public async Task Initialize(TrafficConfiguration configuration)
    {
        await GrainFactory.GetGrain<ITrafficPool>($"{IdentityString}/1")
                          .Initialize(configuration.RequestsPerSecond, configuration);
    }
}
