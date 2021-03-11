using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HayleesThreads.Models;
namespace HayleesThreads.Controllers
{
    public class HomeController : Controller
    {
      public ActionResult Index()
      {
        return View();
      }

      [HttpGet("/Privacy")]
      public IActionResult Privacy()
      {
          return View();
      }
      
    }
}