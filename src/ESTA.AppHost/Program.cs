var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("postgres")
    .WithLifetime(ContainerLifetime.Persistent)
    .WithDataVolume("pgdata")
    .WithPgWeb();


var admindb = postgres.AddDatabase("admindb");
var apiAdimn = builder.AddProject<Projects.ESTA_Admin>("apiadmin")
                            .WithReference(admindb)
                            .WaitFor(admindb);


builder.AddProject<Projects.ESTA_OrderApi>("esta-orderapi");


builder.Build().Run();
