using TrafficGenerator.Contracts;
using TrafficGenerator.GrainDefinitions;

namespace TrafficGenerator.SiloHost.Grains;

[GenerateSerializer]
[Alias(nameof(TrafficPoolState))]
public record TrafficPoolState
{
    [Id(0)] public int ExpectedUnits { get; init; }

    [Id(1)] public int CurrentUnits { get; init; }

    [Id(2)] public int LifetimeUnits { get; init; }
}

public class TrafficPool(
    [PersistentState("pool")] IPersistentState<TrafficPoolState> pool) : Grain, ITrafficPool
{
    public async Task Initialize(int unitCount, TrafficConfiguration configuration)
    {
        pool.State = pool.State with { ExpectedUnits = pool.State.CurrentUnits + unitCount };

        (int expected, int current, int lifetime) =
            (pool.State.ExpectedUnits, pool.State.CurrentUnits, pool.State.LifetimeUnits);

        for (int i = current; i < expected; i++)
        {
            ITrafficUnit trafficUnit = GrainFactory.GetGrain<ITrafficUnit>(TrafficUnit.FromPool(this, i));

            await trafficUnit.GenerateTraffic(configuration);

            current++;
            lifetime++;
        }

        pool.State = pool.State with { CurrentUnits = current, LifetimeUnits = lifetime };

        await pool.WriteStateAsync();
    }

    public Task Finalize(int unitCount)
    {
        throw new NotImplementedException();
    }
}
