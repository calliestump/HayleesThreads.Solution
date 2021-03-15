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
    }

    public static ShoppingCart GetShoppingCart(IServiceProvider services) // Passes service collection to have access to all of the services.
    {
      ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session; // Session that we are instanutaing. '?' = null check. If not null - it will try to access the session.

      var context = services.GetService<HayleesThreadsContext>(); // get the current db context from services.
      string shoppingCartId = session.GetString("ShoppingCartId") ?? Guid.NewGuid().ToString(); // Gets current session: Finds out if session already exists. If yes, we set it to the ShoppingCartId of that session, if not create a new one with a new id. 
      session.SetString("ShoppingCartId", shoppingCartId); // sets the string to the ShoppingCartId, and passing in the value of the session found in line 26.

      return new ShoppingCart(context) { ShoppingCartId = shoppingCartId }; // returns the current shopping cart session.
    }

    public void AddToShoppingCart(Product product, int quantity)
    {
      var shoppingCartProduct = _db.ShoppingCartProducts.SingleOrDefault( // selects the first product with id.
        s => s.Product.ProductId == product.ProductId && s.ShoppingCartId == ShoppingCartId); // checks to see if it matches the product id coming from the argument and if the shopping cart exists by comparing the s.ShoppingCartId to the ShoppingCartId property.

      if(shoppingCartProduct == null) // checks to see if it is null. If yes create new ShoppingCartProduct.
      {
        shoppingCartProduct = new ShoppingCartProduct 
        {
          ShoppingCartId = ShoppingCartId, // takes the id
          Product = product, // specific product
          Quantity = quantity // amount added.
        };

        _db.ShoppingCartProducts.Add(shoppingCartProduct); // Adds the ShoppingCartProduct to the database.
      }
      else // checks to see if ShoppingCartProduct exists. If yes, increase quantity.
      {
        shoppingCartProduct.Quantity++;
      }
      _db.SaveChanges(); // saves changes to database.
    }

    public int RemoveFromShoppingCart(Product product)
    {
      var shoppingCartProduct = _db.ShoppingCartProducts.SingleOrDefault( // selects the first product with id.
        s => s.Product.ProductId == product.ProductId && s.ShoppingCartId == ShoppingCartId); // checks to see if it matches the product id coming from the argument and if the shopping cart exists by comparing the s.ShoppingCartId to the ShoppingCartId property.

      var localAmount = 0; // Counter used to decrease quantity of specific product in the shopping cart.

      if(shoppingCartProduct != null) // checks to see if ShoppingCartProduct exists.
      {
        if(shoppingCartProduct.Quantity > 1) // check the quantity for ShoppinCartProduct and seeing if it is greater than one.
        {
          shoppingCartProduct.Quantity--; // if yes, decrease ShoppingCartProduct quantity.
          localAmount = shoppingCartProduct.Quantity; // sets local amount to be the new shopping cart amount.
        }
        else // if it's not greater than one, remove product entirely.
        {
          _db.ShoppingCartProducts.Remove(shoppingCartProduct);
        }        
      }

      _db.SaveChanges(); 
      return localAmount; // returns the new amount of Product in cart.
    }

    public List<ShoppingCartProduct> GetShoppingCartProducts()
    {
      // var unlistedShoppingCartProducts = _db.ShoppingCartProducts.Where(c
      //  => c.ShoppingCartId == ShoppingCartId)
      //     .Include(s => s.Product);
      // List<ShoppingCartProduct> shoppingCartProducts = unlistedShoppingCartProducts.ToList();
      // return shoppingCartProducts;
      return ShoppingCartProducts ?? (ShoppingCartProducts = _db.ShoppingCartProducts.Where(c //filters specific products that are in the current cart.
       => c.ShoppingCartId == ShoppingCartId) // Matches the ShoppingCartId created for class.
       .Include(s => s.Product) // Grabs all products
       .ToList()); // Puts it into list.
    }

    public void ClearShoppingCart()
    {

      var cartProducts = _db.ShoppingCartProducts.Where(c => c.ShoppingCartId == ShoppingCartId); // gets all products in database that belong to specific ShoppingCartId.
      _db.ShoppingCartProducts.RemoveRange(cartProducts); // Removes all products retrived from line 95.
      _db.SaveChanges(); 
    }

     public decimal GetShoppingCartTotalPrice()
    {
      decimal totalPrice = (decimal) _db.ShoppingCartProducts.Where(c => c.ShoppingCartId == ShoppingCartId) // retrives all products in specific ShoppingCartId.
        .Select(c => c.Product.ProductPrice * c.Quantity).Sum(); // Selects only the calculated total value.
      
      return totalPrice;
    }

  }
}