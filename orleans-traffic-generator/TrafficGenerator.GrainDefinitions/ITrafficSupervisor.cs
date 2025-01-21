﻿using Orleans;

using TrafficGenerator.Contracts;

namespace TrafficGenerator.GrainDefinitions;

/// <summary>
///     Manages a specific instance of traffic configuration. Is responsible for managing traffic pools, making sure the
///     requests per second are being satisfied.
/// </summary>
public interface ITrafficSupervisor : IGrainWithStringKey
{
    Task Initialize(TrafficConfiguration configuration);
}
