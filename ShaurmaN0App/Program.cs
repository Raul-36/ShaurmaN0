using System.Collections;
using System.Reflection;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShaurmaN0App.Data;
using ShaurmaN0App.Repositories;
using ShaurmaN0App.Repositories.Base;
using ShaurmaN0App.Services.Base;

var builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults();
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ShaurmaDbContext>((sp, options) =>
{
    var config = sp.GetRequiredService<IConfiguration>();
    var connectionString = config.GetConnectionString("ShaurmaN0Db");
    options.UseSqlServer(connectionString);
});


builder.Services.AddTransient<IMenusRepository, MenusSQLRepository>();
builder.Services.AddTransient<IMenusCategoryRepository, MenusCategorySQLRepository>();
builder.Services.AddTransient<IMenusService, MenusService>();
builder.Services.AddTransient<IMenusCategoryService, MenusCategoryService>();
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.MapDefaultEndpoints();     

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ShaurmaDbContext>();
    var pendingMigrations = db.Database.GetPendingMigrations();
    if (pendingMigrations.Any())
    {
        db.Database.Migrate();
    }
}

app.Run();