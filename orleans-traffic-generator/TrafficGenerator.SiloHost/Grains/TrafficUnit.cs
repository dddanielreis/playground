using TrafficGenerator.Contracts;
using TrafficGenerator.Contracts.Grains;

namespace TrafficGenerator.SiloHost.Grains;

public class TrafficUnit(ILogger<TrafficUnit> logger) : Grain, ITrafficUnit
{
    public async Task GenerateTraffic(TrafficConfiguration configuration)
    {
        while (!GrainContext.Deactivated.IsCompleted)
        {
            logger.LogInformation("{GrainId}: If I was fully implemented, I would do an HTTP request right now!",
                                  this.GetGrainId().ToString());

            await Task.Delay(TimeSpan.FromSeconds(1));
        }
    }

    public static string FromPool(TrafficPool pool, int number)
    {
        return $"{pool.IdentityString}/{number}";
    }
}
