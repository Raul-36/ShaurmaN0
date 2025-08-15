var builder = DistributedApplication.CreateBuilder(args);

var sql = builder.AddSqlServer("sql")
                 .WithLifetime(ContainerLifetime.Persistent);

var db = sql.AddDatabase("ShaurmaN0Db");

builder.AddProject<Projects.ShaurmaN0App>("ShaurmaN0AppMvc")
    .WithReference(db);

builder.Build().Run();
