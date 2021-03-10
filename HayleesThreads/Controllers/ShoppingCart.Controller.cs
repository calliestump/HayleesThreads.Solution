using Microsoft.AspNetCore.Mvc;
using HayleesThreads.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using HayleesThreads.ViewModels;

namespace HayleesThreads.Controllers
{
    public class ShoppingCartController : Controller
    {
      private readonly HayleesThreadsContext _db;
      private readonly UserManager<ApplicationUser> _userManager;

      public readonly ShoppingCart _shoppingCart;
      public readonly Product _product;
      public ShoppingCartController(UserManager<ApplicationUser> userManager, HayleesThreadsContext db, Product product, ShoppingCart shoppingCart)
      {
        _product = product;
        _shoppingCart = shoppingCart;
        _userManager = userManager;
        _db = db;
      }
      // public ActionResult Index()
      // {
      //   return View();
      // }

      public ViewResult Index()
      {
        _shoppingCart.JoinTables2 = _shoppingCart.GetAllShoppingCartProducts();
        var shoppingCartViewModel = new ShoppingCartViewModel
        {
          ShoppingCart = _shoppingCart,
          ShoppingCartTotalPrice = _shoppingCart.GetShoppingCartTotalPrice()
        };
        
        return View(shoppingCartViewModel);
      }

      // public void AddToShoppingCart(int id)
      // {
      //   var thisProduct = _db.Products.FirstOrDefault(product => product.ProductId == id);

      //   _db.SaveChanges();
      // }
    } 
}