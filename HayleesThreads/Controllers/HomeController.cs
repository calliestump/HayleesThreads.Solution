using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HayleesThreads.Models;
namespace HayleesThreads.Controllers
{
    public class HomeController : Controller
    {
      // [HttpGet("/")]
      public ActionResult Index()
      {
        return View();
      }

      [HttpGet("/Privacy")]
      public IActionResult Privacy()
      {
          return View();
      }

      // public ActionResult AddToCart(int productId)
      // {
      //   var cart = new List<Item>();

      //   return View();
      // }
      
    }
}