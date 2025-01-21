using Scalar.AspNetCore;

using TrafficGenerator.Contracts;
using TrafficGenerator.GrainDefinitions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.AddServiceDefaults();

builder.AddKeyedNpgsqlDataSource("postgres");

builder.UseOrleans(sb =>
{
    sb.AddActivityPropagation();
    sb.AddAdoNetGrainStorageAsDefault(opt =>
    {
        opt.Invariant        = "Npgsql";
        opt.ConnectionString = builder.Configuration.GetConnectionString("postgres");
    });
    sb.UseAdoNetClustering(opt =>
    {
        opt.Invariant        = "Npgsql";
        opt.ConnectionString = builder.Configuration.GetConnectionString("postgres");
    });
    sb.UseAdoNetReminderService(opt =>
    {
        opt.Invariant        = "Npgsql";
        opt.ConnectionString = builder.Configuration.GetConnectionString("postgres");
    });
    // sb.AddAdoNetStreams("Default", opt =>
    // {
    //     opt.Invariant        = "Npgsql";
    //     opt.ConnectionString = builder.Configuration.GetConnectionString("postgres");
    // });
});

WebApplication app = builder.Build();

app.MapDefaultEndpoints();

app.MapPost("/traffic", async (TrafficConfiguration configuration, IGrainFactory grainFactory) =>
{
    await grainFactory.GetGrain<ITrafficSupervisor>(Guid.NewGuid().ToString())
                      .Initialize(configuration);
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.Run();
