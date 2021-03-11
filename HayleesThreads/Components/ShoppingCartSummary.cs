using Microsoft.AspNetCore.Mvc;
using System.Linq;
using HayleesThreads.Models;
using HayleesThreads.ViewModels;

namespace HayleesThreads.Components
{
  public class ShoppingCartSummary : ViewComponent
  {
    private readonly ShoppingCart _shoppingCart;

    public ShoppingCartSummary(ShoppingCart shoppingCart)
    {
      _shoppingCart = shoppingCart;
    }

    public IViewComponentResult Invoke()
    {
      _shoppingCart.ShoppingCartProducts = _shoppingCart.GetShoppingCartProducts();
      var shoppingCartViewModel = new ShoppingCartViewModel
      {
        ShoppingCart = _shoppingCart,
        ShoppingCartTotalPrice = _shoppingCart.GetShoppingCartTotalPrice()
      };

      return View(shoppingCartViewModel);
    }
  }
}