using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace HayleesThreads.Models
{
  public class ProductRepository : IProductRepository 
  {
    private readonly HayleesThreadsContext _db;

    public ProductRepository(HayleesThreadsContext db)
    {
      _db = db;
    }

    public IEnumerable<Product> GetAllProducts
    {
      get
        {
          return _db.Products.Include(p => p.Category); 
        }
    }
    public Product GetProductById(int productId)
    {
      return _db.Products.FirstOrDefault(p => p.ProductId == productId);
    }
  }
}