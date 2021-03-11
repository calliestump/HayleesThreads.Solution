using Microsoft.AspNetCore.Mvc;
using HayleesThreads.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using HayleesThreads.ViewModels;
using System;

namespace HayleesThreads.Controllers
{
    public class ShoppingCartController : Controller
    {
      private readonly HayleesThreadsContext _db;
      private readonly UserManager<ApplicationUser> _userManager;

      public readonly ShoppingCart _shoppingCart;
      public readonly IProductRepository _productRepository;
      public ShoppingCartController(UserManager<ApplicationUser> userManager, HayleesThreadsContext db, IProductRepository productRepository, ShoppingCart shoppingCart)
      {
        _productRepository = productRepository;
        _shoppingCart = shoppingCart;
        _userManager = userManager;
        _db = db;
      }

      public ViewResult Index()
      {
        _shoppingCart.ShoppingCartProducts = _shoppingCart.GetShoppingCartProducts();
        var shoppingCartViewModel = new ShoppingCartViewModel
        {
          ShoppingCart = _shoppingCart,
          ShoppingCartTotalPrice = _shoppingCart.GetShoppingCartTotalPrice()
        };
        
        return View(shoppingCartViewModel);
      }

      public RedirectToActionResult AddToShoppingCart(int productId) 
      {
        var selectedProduct = _db.Products.FirstOrDefault(c => c.ProductId == productId);

        if(selectedProduct != null)
        {
          _shoppingCart.AddToShoppingCart(selectedProduct, 1);
        }

        return RedirectToAction("Index");
      }

      public RedirectToActionResult RemoveFromShoppingCart(int productId) 
      {
        var selectedProduct = _productRepository.GetAllProducts.FirstOrDefault(c => c.ProductId == productId);
        
        if(selectedProduct != null)
        {
          _shoppingCart.RemoveFromShoppingCart(selectedProduct);
          // Console.WriteLine("Removed Product");
        }

        return RedirectToAction("Index");
      }

      public RedirectToActionResult ClearShoppingCart()
      {
        _shoppingCart.ClearShoppingCart();
        return RedirectToAction("Index");
      }
    } 
}