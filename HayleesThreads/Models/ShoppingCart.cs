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
    // public List<ShoppingCartProduct> ShoppingCartProduct { get; set; }
    public ShoppingCart(HayleesThreadsContext db)
    {
      _db = db;
      this.JoinTables2 = new HashSet<ShoppingCartProduct>();
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
      var shoppingCartProduct = _db.ShoppingCartProduct.SingleOrDefault(
        i => i.Product.ProductId == product.ProductId && i.ShoppingCartId == ShoppingCartId);

      if(shoppingCartProduct == null)
      {
        shoppingCartProduct = new ShoppingCartProduct
        {
          ShoppingCartId = ShoppingCartId,
          ProductId = product.ProductId,
          Quantity = quantity
        };
        _db.ShoppingCartProduct.Add(shoppingCartProduct);
      }
      else
      {
        shoppingCartProduct.Quantity++;
      }

      _db.SaveChanges();
    }

    public int RemoveFromShoppingCart(Product product)
    {
      var shoppingCartProduct = _db.ShoppingCartProduct.SingleOrDefault(
        i => i.Product.ProductId == product.ProductId && i.ShoppingCartId == ShoppingCartId);

      var quantity = 0;

      if(shoppingCartProduct != null)
      {
        if(shoppingCartProduct.Quantity > 1)
        {
          shoppingCartProduct.Quantity--;
          quantity = shoppingCartProduct.Quantity;
        }
        else
        {
          _db.ShoppingCartProduct.Remove(shoppingCartProduct);
        }        
      }

      _db.SaveChanges();
      return quantity;
    }

    public List<ShoppingCartProduct> GetAllShoppingCartProducts()
    {
      var shoppingCartProduct = JoinTables2.ToList() ?? (JoinTables2 = _db.ShoppingCartProduct.Where(s => s.ShoppingCartId == ShoppingCartId)
        .Include(p => p.Product)
        .ToList());
      
      return shoppingCartProduct.ToList();
    }

    public void ClearShoppingCart()
    {
      var shoppingCartProduct = _db.ShoppingCartProduct.Where(i => i.ShoppingCartId == ShoppingCartId);
      _db.ShoppingCartProduct.RemoveRange(shoppingCartProduct);
      _db.SaveChanges();
    }

    public long GetShoppingCartTotalPrice()
    {
      var totalPrice = (long) _db.ShoppingCartProduct.Where(i => i.ShoppingCartId == ShoppingCartId)
        .Select(p => p.Product.ProductPrice).Sum();
      
      return totalPrice;
    }

    public virtual ICollection<ShoppingCartProduct> JoinTables2 { get; set; }
  }
}