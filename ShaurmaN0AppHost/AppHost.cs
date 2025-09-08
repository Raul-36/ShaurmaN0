using Aspire.Hosting;
using Aspire.Hosting.ApplicationModel;


var builder = DistributedApplication.CreateBuilder(args);

// var sql = builder.AddSqlServer("sql").WithConnectionString("Server=localhost;Database=ShaurmaN0;Integrated Security=SSPI;TrustServerCertificate=True;");
//                 //  .WithLifetime(ContainerLifetime.Session);

// var db = sql.AddDatabase("ShaurmaN0Db");

// builder.AddProject<Projects.ShaurmaN0App>("ShaurmaN0AppMvc")
//     .WithReference(db);

builder.AddProject<Projects.ShaurmaN0App>("ShaurmaN0AppMvc")
    .WithEnvironment("ConnectionStrings__ShaurmaN0Db", "Server=localhost;Database=ShaurmaN0;Integrated Security=SSPI;TrustServerCertificate=True;");


builder.Build().Run();
