using Microsoft.EntityFrameworkCore;
using ShaurmaN0App.Models;

namespace ShaurmaN0App.Data
{
    public class ShaurmaDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public ShaurmaDbContext(DbContextOptions<ShaurmaDbContext> options) : base(options)
        {
        }

        public DbSet<Log> Logs { get; set; }
        public DbSet<MenusCategory> MenusCategory { get; set; }
        public DbSet<Menus> Menus { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Menus>()
            .HasOne(m => m.MenusCategory)    
            .WithMany(mc => mc.Menus) 
            .HasForeignKey(m => m.MenusCategoryId); 

            modelBuilder.Entity<MenusCategory>().Property(mC => mC.Id).HasDefaultValue(Guid.NewGuid());
            modelBuilder.Entity<Menus>().Property(m => m.Id).HasDefaultValue(Guid.NewGuid());
            
            Dictionary<string,Guid> menusCategories = new Dictionary<string, Guid>();
            menusCategories["food"]= Guid.NewGuid();
            menusCategories["drinkables"]= Guid.NewGuid();

            modelBuilder.Entity<MenusCategory>().HasData( 
                
                    new MenusCategory{Id= menusCategories["food"], Name= "food"},
                    new MenusCategory{Id= menusCategories["drinkables"], Name= "drinkables"}
            );
            modelBuilder.Entity<Menus>().HasData(
                
                    new Menus{Id= Guid.NewGuid(), MenusCategoryId=menusCategories["food"],Name= "Shaurma", Price=5},
                    new Menus{Id= Guid.NewGuid(), MenusCategoryId=menusCategories["drinkables"],Name= "Cola", Price=1.5}
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}