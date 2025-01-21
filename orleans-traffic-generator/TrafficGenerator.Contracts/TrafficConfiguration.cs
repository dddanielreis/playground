using System.Text.Json;

namespace TrafficGenerator.Contracts;

public record TrafficConfiguration
{
    public required Uri TargetUrl { get; init; }

    public required int RequestsPerSecond { get; init; }

    public required JsonDocument RequestSchema { get; init; }
}
