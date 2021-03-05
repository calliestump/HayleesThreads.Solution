using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HayleesThreads.Models
{
  public class ShoppingCart
  {
    private readonly HayleesThreadsContext _db;
    public string ShoppingCartId { get; set; }
    public List<ShoppingCartItem> ShoppingCartItems { get; set; }
    public ShoppingCart(HayleesThreadsContext db)
    {
      _db = db;
    }

    public static ShoppingCart GetShoppingCart(IServiceProvider services)
    {
      ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

      var context = services.GetService<HayleesThreadsContext>();
      string shoppingCartId = session.GetString("ShoppingCartId") ?? Guid.NewGuid().ToString();
      session.SetString("ShoppingCartId", shoppingCartId);

      return new ShoppingCart(context) { ShoppingCartId = shoppingCartId };
    }

    public void AddToShoppingCart(Product product, int quantity)
    {
      var shoppingCartItem = _db.ShoppingCartItems.SingleOrDefault(
        i => i.Product.ProductId == product.ProductId && i.ShoppingCartId == ShoppingCartId);

      if(shoppingCartItem == null)
      {
        shoppingCartItem = new ShoppingCartItem
        {
          ShoppingCartId = ShoppingCartId,
          Product = product,
          Quantity = quantity
        };
        _db.ShoppingCartItems.Add(shoppingCartItem);
      }
      else
      {
        shoppingCartItem.Quantity++;
      }

      _db.SaveChanges();
    }

    public int RemoveFromShoppingCart(Product product)
    {
      var shoppingCartItem = _db.ShoppingCartItems.SingleOrDefault(
        i => i.Product.ProductId == product.ProductId && i.ShoppingCartId == ShoppingCartId);

      var quantity = 0;

      if(shoppingCartItem != null)
      {
        if(shoppingCartItem.Quantity > 1)
        {
          shoppingCartItem.Quantity--;
          quantity = shoppingCartItem.Quantity;
        }
        else
        {
          _db.ShoppingCartItems.Remove(shoppingCartItem);
        }        
      }

      _db.SaveChanges();
      return quantity;
    }

    public List<ShoppingCartItem> GetAllShoppingCartItems()
    {
      var shoppingCartItems = ShoppingCartItems ?? (ShoppingCartItems = _db.ShoppingCartItems.Where(s => s.ShoppingCartId == ShoppingCartId)
        .Include(p => p.Product)
        .ToList());
      
      return shoppingCartItems;
    }

    public void ClearShoppingCart()
    {
      var shoppingCartItems = _db.ShoppingCartItems.Where(i => i.ShoppingCartId == ShoppingCartId);
      _db.ShoppingCartItems.RemoveRange(shoppingCartItems);
      _db.SaveChanges();
    }

    public long GetShoppingCartTotalPrice()
    {
      var totalPrice = (long) _db.ShoppingCartItems.Where(i => i.ShoppingCartId == ShoppingCartId)
        .Select(p => p.Product.ProductPrice).Sum();
      
      return totalPrice;
    }
  }
}