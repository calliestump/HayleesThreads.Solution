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
  
  public class ProductsController : Controller
  {
    private readonly HayleesThreadsContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    public ProductsController(UserManager<ApplicationUser> userManager, HayleesThreadsContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    [HttpGet("/")]
    public ActionResult Index()
    {
      List<Product> model = _db.Products.ToList();
      return View(model);
    }
    public ActionResult Details(int id)
    {
      var thisProduct = _db.Products
          .Include(product => product.JoinTables)
          .ThenInclude(join => join.Category)
          .FirstOrDefault(product => product.ProductId == id);
      return View(thisProduct);
    }

    [Authorize]
    public ActionResult Create()
    {
      return View();
    }
    
    [HttpPost]
    public ActionResult Create(Product product)
    {
      _db.Products.Add(product);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    [Authorize]
    public ActionResult Edit(int id)
    {
      var thisProduct = _db.Products.FirstOrDefault(product => product.ProductId == id);
      return View(thisProduct);
    }

    [HttpPost]
    public ActionResult Edit(Product product)
    {
      _db.Entry(product).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
} 