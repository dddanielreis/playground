var builder = DistributedApplication.CreateBuilder(args);

var postgresServer = builder.AddPostgres("postgres-server")
                            .WithImage("dddanielreis/orleans-postgres")
                            .WithPgAdmin();

var postgresDb = postgresServer
   .AddDatabase("postgres-db");

var orleans = builder.AddOrleans("traffic-generator-cluster")
                     .WithReminders(postgresDb)
                     .WithClustering(postgresDb)
                     .WithGrainStorage(postgresDb);

builder.AddProject<Projects.TrafficGenerator_Api>("traffic-generator-api")
       .WithReference(orleans)
       .WaitFor(postgresDb)
       .WithExternalHttpEndpoints();

builder.Build().Run();
