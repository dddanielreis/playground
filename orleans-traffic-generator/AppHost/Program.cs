using Projects;

IDistributedApplicationBuilder builder = DistributedApplication.CreateBuilder(args);

IResourceBuilder<PostgresServerResource> postgresServer = builder.AddPostgres("postgres-server")
                                                                 .WithImage("dddanielreis/orleans-postgres")
                                                                 .WithPgAdmin();

IResourceBuilder<PostgresDatabaseResource> postgresDb = postgresServer
   .AddDatabase("postgres");

builder.AddProject<TrafficGenerator_SiloHost>("traffic-generator-silo")
       .WithReference(postgresDb)
       .WaitFor(postgresDb)
       .WithExternalHttpEndpoints();

builder.Build().Run();
