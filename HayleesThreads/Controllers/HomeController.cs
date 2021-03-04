using Microsoft.AspNetCore.Mvc;

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
      
    }
}