using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using ShaurmaN0App.Models;

namespace ShaurmaN0App.Data
{
    public class ShaurmaDbContext : DbContext
    {
        public ShaurmaDbContext(DbContextOptions<ShaurmaDbContext> options) : base(options)
        {
        }
        public DbSet<MenusCategory> MenusCategory { get; set; }
        public DbSet<Menus> Menus { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Menus>(m =>
            {
                m.HasIndex(m => m.Name).IsUnique();
            });
            modelBuilder.Entity<MenusCategory>(mC =>
            {
                mC.HasIndex(mC => mC.Name).IsUnique();
            });
            modelBuilder.Entity<Menus>()
            .HasOne(m => m.MenusCategory)
            .WithMany(mc => mc.Menus)
            .HasForeignKey(m => m.MenusCategoryId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MenusCategory>().Property(mC => mC.Id).HasDefaultValue(Guid.NewGuid());
            modelBuilder.Entity<Menus>().Property(m => m.Id).HasDefaultValue(Guid.NewGuid());

            var testMenusCategory = JsonSerializer.Deserialize<IEnumerable<MenusCategory>>(File.ReadAllText("Assets/MenusCategory.json"))?.ToArray() ?? null;
            var testMenus = JsonSerializer.Deserialize<IEnumerable<Menus>>(File.ReadAllText("Assets/Menus.json"))?.ToArray() ?? null;

            if (testMenusCategory != null)
                modelBuilder.Entity<MenusCategory>().HasData(testMenusCategory);
            if (testMenus != null)
                modelBuilder.Entity<MenusCategory>().HasData(testMenus);

            base.OnModelCreating(modelBuilder);
        }
    }
}