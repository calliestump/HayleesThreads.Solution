using Microsoft.AspNetCore.Mvc;
using HayleesThreads.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace HayleesThreads.Controllers
{
    public class CartController : Controller
    {
      private readonly HayleesThreadsContext _db;
      private readonly UserManager<ApplicationUser> _userManager;
      public CartController(UserManager<ApplicationUser> userManager, HayleesThreadsContext db)
      {
        _userManager = userManager;
        _db = db;
      }
      public ActionResult Index()
      {
        return View();
      }

      // public void AddToShoppingCart(int id)
      // {
      //   var thisProduct = _db.Products.FirstOrDefault(product => product.ProductId == id);

      //   _db.SaveChanges();
      // }
    } 
}