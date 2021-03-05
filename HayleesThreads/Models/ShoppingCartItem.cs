using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HayleesThreads.Models
{
  public class ShoppingCartItem
  {
    public int ShoppingCartItemId { get; set; }
    public string ShoppingCartId { get; set; }
    public Product Product { get; set; }
    public int Quantity { get; set; }
  }
}