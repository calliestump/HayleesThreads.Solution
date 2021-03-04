using Microsoft.AspNetCore.Mvc;

namespace HayleesThreads.Controllers
{
    public class OrderController : Controller
    {
      public ActionResult Index()
      {
        return View();
      }
    }
}