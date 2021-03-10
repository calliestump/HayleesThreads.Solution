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
        
  

        // Products
        // modelBuilder.Entity<Product>().HasData(new Product
        // {
        //   ProductId = 1,
        //   ProductName = "Tree of Life",
        //   ProductPrice = 14.99m,
        //   ProductDescription = "Embroided 'Tree of Life'",
        //   ProductImage = "\\img\\appa.jpg",
        //   Featured = true,
        //   AllEars = false,
        //   CategoryId = 1
        // });

        // modelBuilder.Entity<Product>().HasData(new Product
        // {
        //   ProductId = 2,
        //   ProductName = "Appa",
        //   ProductPrice = 12.99m,
        //   ProductDescription = "Hand-Embroided 'Appa' from Avatar: The Last Airbender",
        //   ProductImage = "\\img\\appa.jpg",
        //   Featured = true,
        //   AllEars = true,
        //   CategoryId = 2
        // });

        // // CategoryProduct
        // modelBuilder.Entity<CategoryProduct>().HasData(new CategoryProduct
        // {
        //   CategoryProductId = 1,
        //   CategoryId = 1,
        //   ProductId = 1,
        // });

        // modelBuilder.Entity<CategoryProduct>().HasData(new CategoryProduct
        // {
        //   CategoryProductId = 2,
        //   CategoryId = 2,
        //   ProductId = 2,
        // });
      }   
  }
}