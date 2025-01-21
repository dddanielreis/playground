WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.AddServiceDefaults();

builder.AddKeyedNpgsqlDataSource("postgres");

builder.UseOrleans(sb =>
{
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
    sb.AddAdoNetStreams("Default", opt =>
    {
        opt.Invariant        = "Npgsql";
        opt.ConnectionString = builder.Configuration.GetConnectionString("postgres");
    });
});

WebApplication app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();
