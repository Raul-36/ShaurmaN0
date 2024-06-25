using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using ShaurmaN0App.Data;
using ShaurmaN0App.Repositories;
using ShaurmaN0App.Repositories.Base;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IMenusRepository, MenusSQLRepository>();
builder.Services.AddTransient<IMenusCategoryRepository, MenusCategorySQLRepository>();
builder.Services.AddDbContext<ShaurmaDbContext>(dbContextOptionsBuilder => {
    var connectionString = builder.Configuration.GetConnectionString("SqlDb");
    dbContextOptionsBuilder.UseSqlServer(connectionString);
});
var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
//app.UseMiddleware<LoggingMiddleware>();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
