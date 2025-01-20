var builder = DistributedApplication.CreateBuilder(args);

var postgresServer = builder.AddPostgres("postgres-server")
                            .WithImage("dddanielreis/orleans-postgres")
                            .WithPgAdmin();

var postgresDb = postgresServer
   .AddDatabase("postgres");

builder.AddProject<Projects.TrafficGenerator_Api>("traffic-generator-api")
       .WithReference(postgresDb)
       .WaitFor(postgresDb)
       .WithExternalHttpEndpoints();

builder.Build().Run();
