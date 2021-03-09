using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HayleesThreads.Models
{
  public class ShoppingCartProduct
  {
    public int ShoppingCartProductId { get; set; }
    public string ShoppingCartId { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public ShoppingCart ShoppingCart { get; set; }
    public int Quantity { get; set; }
  }
}