var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("postgres")
    .WithLifetime(ContainerLifetime.Persistent)
    .WithDataVolume("pgdata")
    .WithPgWeb();

var admindb = postgres.AddDatabase("admindb");

builder.AddProject<Projects.ESTA_OrderApi>("orderapi")
                            .WithReference(admindb)
                            .WaitFor(admindb);

var apiAdimn = builder.AddProject<Projects.ESTA_Admin>("apiadmin")
                            .WithReference(admindb)
                            .WaitFor(admindb);



builder.Build().Run();
