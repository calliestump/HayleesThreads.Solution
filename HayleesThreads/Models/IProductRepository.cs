
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HayleesThreads.Models
{
  public interface IProductRepository
  {
    IEnumerable<Product> GetAllProducts { get; }
    Product GetProductById(int productId);
  }
}