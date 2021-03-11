using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HayleesThreads.Models
{
  public class HayleesThreadsContext : IdentityDbContext<ApplicationUser>
  {
    public HayleesThreadsContext(DbContextOptions<HayleesThreadsContext> options)
      : base(options)
      {
      }
    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<ShoppingCartProduct> ShoppingCartProducts { get; set; }
    
    public virtual DbSet<CategoryProduct> CategoryProduct { get; set; }
     public virtual DbSet<Order> Orders { get; set; }
    
    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
        base.OnModelCreating(modelBuilder);
        
        // Categories
        modelBuilder.Entity<Category>().HasData(new Category 
        { 
          CategoryId = 1,
          CategoryName = "Hoodie", 
          CategoryDescription = "Explore my custom Hoodies!",
          // CategoryImage = ""
        });
        modelBuilder.Entity<Category>().HasData(new Category
        {
          CategoryId = 2,
          CategoryName = "Crews",
          CategoryDescription = "Explore my custom Crews",
          // CategoryImage = ""
        });
        modelBuilder.Entity<Category>().HasData(new Category
        {
          CategoryId = 3,
          CategoryName = "T-Shirts",
          CategoryDescription = "Explore my custom T-Shirts",
          // CategoryImage = ""
        });
        modelBuilder.Entity<Category>().HasData(new Category
        {
          CategoryId = 4,
          CategoryName = "Sweats",
          CategoryDescription = "Explore my custom Sweats",
          // CategoryImage = ""
        });
        modelBuilder.Entity<Category>().HasData(new Category
        {
          CategoryId = 5,
          CategoryName = "Masks",
          CategoryDescription = "Explore my custom Masks",
          // CategoryImage = ""
        });
        modelBuilder.Entity<Category>().HasData(new Category
        {
          CategoryId = 6,
          CategoryName = "Hats",
          CategoryDescription = "Explore my custom Hats",
          // CategoryImage = ""
        });
      }   
  }
}