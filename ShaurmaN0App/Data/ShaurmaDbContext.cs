using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShaurmaN0App.Models;
using System.Text.Json;

namespace ShaurmaN0App.Data
{
    public class ShaurmaDbContext : IdentityDbContext<IdentityUser>
    {
        public ShaurmaDbContext(DbContextOptions<ShaurmaDbContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<MenusCategory> MenusCategory { get; set; }
        public DbSet<Menus> Menus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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

            modelBuilder.Entity<Order>(o =>
            {
                o.HasKey(x => x.Id);

                o.Property(x => x.Total)
                    .IsRequired();

                o.HasMany(x => x.OrderItems)
                    .WithOne()
                    .HasForeignKey(oi => oi.OrderId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<OrderItem>(oi =>
            {
                oi.HasKey(x => x.Id);

                oi.Property(x => x.Total)
                    .IsRequired();

                oi.HasOne(x => x.Menus)
                    .WithMany()
                    .HasForeignKey(x => x.MenusId)
                    .OnDelete(DeleteBehavior.Restrict);
            });


            modelBuilder.Entity<MenusCategory>().Property(mC => mC.Id).HasDefaultValue(Guid.NewGuid());
            modelBuilder.Entity<Menus>().Property(m => m.Id).HasDefaultValue(Guid.NewGuid());

            var testMenusCategory = JsonSerializer.Deserialize<IEnumerable<MenusCategory>>(File.ReadAllText("Assets/MenusCategory.json"))?.ToArray() ?? null;
            var testMenus = JsonSerializer.Deserialize<IEnumerable<Menus>>(File.ReadAllText("Assets/Menus.json"))?.ToArray() ?? null;

            if (testMenusCategory != null)
                modelBuilder.Entity<MenusCategory>().HasData(testMenusCategory);
            if (testMenus != null)
                modelBuilder.Entity<Menus>().HasData(testMenus);

        }
    }
}
