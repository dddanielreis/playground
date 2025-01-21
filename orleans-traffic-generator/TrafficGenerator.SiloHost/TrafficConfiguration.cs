namespace TrafficGenerator.Contracts;

[GenerateSerializer]
[Alias(nameof(TrafficConfiguration))]
public record TrafficConfiguration
{
    [Id(0)] public required Uri TargetUrl { get; init; }

    [Id(1)] public required int RequestsPerSecond { get; init; }

    //public required JsonDocument RequestSchema { get; init; }
}
