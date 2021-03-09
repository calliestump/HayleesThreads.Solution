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
    public List<ShoppingCartProduct> ShoppingCartProducts { get; set; }
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
      var shoppingCartProduct = _db.ShoppingCartProducts.SingleOrDefault(
        i => i.Product.ProductId == product.ProductId && i.ShoppingCartId == ShoppingCartId);

      if(shoppingCartProduct == null)
      {
        shoppingCartProduct = new ShoppingCartProduct
        {
          ShoppingCartId = ShoppingCartId,
          ProductId = product.ProductId,
          Quantity = quantity
        };
        _db.ShoppingCartProducts.Add(shoppingCartProduct);
      }
      else
      {
        shoppingCartProduct.Quantity++;
      }

      _db.SaveChanges();
    }

    public int RemoveFromShoppingCart(Product product)
    {
      var shoppingCartProduct = _db.ShoppingCartProducts.SingleOrDefault(
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
          _db.ShoppingCartProducts.Remove(shoppingCartProduct);
        }        
      }

      _db.SaveChanges();
      return quantity;
    }

    public List<ShoppingCartProduct> GetAllShoppingCartProducts()
    {
      var shoppingCartProducts = ShoppingCartProducts ?? (ShoppingCartProducts = _db.ShoppingCartProducts.Where(s => s.ShoppingCartId == ShoppingCartId)
        .Include(p => p.Product)
        .ToList());
      
      return shoppingCartProducts;
    }

    public void ClearShoppingCart()
    {
      var shoppingCartProducts = _db.ShoppingCartProducts.Where(i => i.ShoppingCartId == ShoppingCartId);
      _db.ShoppingCartProducts.RemoveRange(shoppingCartProducts);
      _db.SaveChanges();
    }

    public long GetShoppingCartTotalPrice()
    {
      var totalPrice = (long) _db.ShoppingCartProducts.Where(i => i.ShoppingCartId == ShoppingCartId)
        .Select(p => p.Product.ProductPrice).Sum();
      
      return totalPrice;
    }
    public virtual ICollection<ShoppingCartProduct> JoinTables2 { get; set; }

  }
}