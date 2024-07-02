using System.Reflection;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ShaurmaN0App.Data;
using ShaurmaN0App.Repositories;
using ShaurmaN0App.Repositories.Base;
using ShaurmaN0App.Services.Base;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ShaurmaDbContext>(dbContextOptionsBuilder => {
    var connectionString = builder.Configuration.GetConnectionString("SqlDb");
    dbContextOptionsBuilder.UseSqlServer(connectionString);
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

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();